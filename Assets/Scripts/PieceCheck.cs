using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieceCheck : MonoBehaviour
{
    public string name;
    public bool placed = false;
    public GameObject stud;
    public GameObject interactable;

    public GameObject target;
    public List<GameObject> potentialTargets;

    private Vector3 finalPos;


    

    void Start()
    {
        if (stud != null)
        {
            stud.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Freezes if in final pos
        if (placed)
        {
            this.transform.position = finalPos;

            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.rotation = Quaternion.identity;
            potentialTargets.Clear();
            interactable.SetActive(false);
        }


        if (potentialTargets.Count > 0) // Theres a valid stud nearby
        {
            GameObject targetPos = GetClosestPosition(potentialTargets);
            target.transform.position = targetPos.transform.position;
            target.transform.rotation = Quaternion.identity;

            target.SetActive(true);

        }
        else
        {
            target.SetActive(false);
        }

    }

    // Checks if the piece is placed on a stud
    public void DropPiece()
    {
        //Debug.Log("piece dropping");
        if (potentialTargets.Count > 0) // Theres a valid stud nearby
        {
            //Debug.Log("found closest");
            GameObject targetPos = GetClosestPosition(potentialTargets);
            finalPos = targetPos.transform.position;
            placed = true;

            targetPos.GetComponent<StudObject>().piece = this.gameObject;
            stud.SetActive(true);
        }
    }

    private GameObject GetClosestPosition(List<GameObject> objects)
    {
        GameObject closestPos = null;
        float distance = 100f;
        foreach (GameObject obj in objects)
        {
            if (Vector3.Distance(obj.transform.position, this.gameObject.transform.position) < distance)
            { 
                distance = Vector3.Distance(obj.transform.position, this.gameObject.transform.position);
                closestPos = obj;
            }
        }

        return closestPos;
    }


    public List<string> GetNext()
    {
        List<string> result = new List<string>();
        result.Add(name);
        if (stud != null)
        {
            if (stud.GetComponent<StudObject>().GetNext() != null)
            {
                result.Concat(stud.GetComponent<StudObject>().GetNext());
            }
        }
        return result;
    }
}
