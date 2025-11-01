using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Baseplate : MonoBehaviour
{
    public Material solvedMaterial;

    public GameObject pieceParent;

    public GameObject[] studs = new GameObject[9];
    

    public string[] solution1 = new string[9];
    public bool solution1Solved = false;
    public bool finishedSolution1 = false;
    public GameObject solution1Object;

    public string[] solution2 = new string[9];
    public bool solution2Solved = false;
    public bool finishedSolution2 = false;
    public GameObject solution2Object;

    public string[] solution3 = new string[9];
    public bool solution3Solved = false;
    public bool finishedSolution3 = false;
    public GameObject solution3Object;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        solution1Solved = true;
        solution2Solved = true;
        solution3Solved = true;




        int i = 0; // Index for checking solution

        foreach (var stud in studs)
        {
            string result = "";
            if (stud.GetComponent<StudObject>().GetNext() != null)
            {
                result = stud.GetComponent<StudObject>().GetNext();
                

                
                // Check if solved solution 1
                if (!string.Equals(solution1[i], result)) { solution1Solved = false; }
                // Check if solved solution 2
                if (!string.Equals(solution2[i], result)) { solution2Solved = false; }
                // Check if solved solution 3
                if (!string.Equals(solution3[i], result)) { solution3Solved = false; }



                //Debug.Log(result);
            }
            else
            {
                if (!string.Equals(solution1[i], "")) { solution1Solved = false; }
                if (!string.Equals(solution2[i], "")) { solution2Solved = false; }
                if (!string.Equals(solution3[i], "")) { solution3Solved = false; }
                //Debug.Log("empty");
            }

            i++;
        }


        // Output for solution 1
        if (solution1Solved && !finishedSolution1) {
            Debug.Log("solved solution 1");
            finishedSolution1 = true;
            solution1Object.GetComponent<MeshRenderer>().material = solvedMaterial;
            foreach (Transform piece in solution1Object.transform)
            {
                piece.GetComponent<MeshRenderer>().material = solvedMaterial;
            }
        }
        // Output for solution 2
        if (solution2Solved && !finishedSolution2) {
            Debug.Log("solved solution 2");
            finishedSolution2 = true;
            solution2Object.GetComponent<MeshRenderer>().material = solvedMaterial;
            foreach (Transform piece in solution2Object.transform)
            {
                piece.GetComponent<MeshRenderer>().material = solvedMaterial;
            }
        }
        // Output for solution 3
        if (solution3Solved && !finishedSolution3) {
            Debug.Log("solved solution 3");
            finishedSolution3 = true;
            solution3Object.GetComponent<MeshRenderer>().material = solvedMaterial;
            foreach (Transform piece in solution3Object.transform)
            {
                piece.GetComponent<MeshRenderer>().material = solvedMaterial;
            }
        }
    }


    public void Reset()
    {
        foreach (var stud in studs)
        {
            stud.GetComponent<StudObject>().Reset();
        }
        foreach (Transform piece in pieceParent.transform)
        {
            Destroy(piece.gameObject);
        }
    }
}
