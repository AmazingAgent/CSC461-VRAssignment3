using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Baseplate : MonoBehaviour
{
    public GameObject[] studs = new GameObject[9];

    public string[] solution1 = new string[9];
    public bool solution1Solved = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        solution1Solved = true;




        int i = 0; // Index for checking solution

        foreach (var stud in studs)
        {
            List<string> result = new List<string>();
            if (stud.GetComponent<StudObject>().GetNext() != null)
            {
                result = stud.GetComponent<StudObject>().GetNext();
                string output = "";
                foreach (var name in result)
                {
                    output += name + "_";
                }

                
                // Check if solved solution 1
                if (!string.Equals(solution1[i], output)) { solution1Solved = false; }
                else {  }


                //Debug.Log(output);
            }
            else
            {
                if (!string.Equals(solution1[i], "")) { solution1Solved = false; }
                //Debug.Log("empty");
            }

            i++;
        }


        // Output for solution 1
        if (solution1Solved) { Debug.Log("solved solution 1"); }
    }
}
