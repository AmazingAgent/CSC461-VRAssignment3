using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudObject : MonoBehaviour
{
    public bool isActive = true;
    public bool occupied = false;
    public GameObject piece { get; set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (piece != null) { occupied = true; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            PieceCheck pieceCheck = other.gameObject.GetComponent<PieceCheck>();
            if (pieceCheck != null)
            {
                pieceCheck.potentialTargets.Add(this.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            PieceCheck pieceCheck = other.gameObject.GetComponent<PieceCheck>();
            if (pieceCheck != null)
            {
                pieceCheck.potentialTargets.Remove(this.gameObject);
            }
        }
    }


    public List<string> GetNext()
    {
        if (piece is not null)
        {
            return piece.gameObject.GetComponent<PieceCheck>().GetNext();
        }
        else
        {
            return null;
        }
    }

    public void Reset()
    {
        piece = null;
        isActive = true;
        occupied = false;
    }

}
