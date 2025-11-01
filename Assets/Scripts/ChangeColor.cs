using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public int colorID;
    public Material red;
    public Material blue;
    public Material green;
    public Material yellow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag == "1x1") // 1x1 Piece
        {
            Debug.Log("coloring 1x1");
            switch (colorID)
            {
                case 1: // Red
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = red;
                    other.gameObject.GetComponent<PieceCheck>().name = "red1x1";
                    break;
                case 2: // Blue
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = blue;
                    other.gameObject.GetComponent<PieceCheck>().name = "blue1x1";
                    break;
                case 3: // Green
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = green;
                    other.gameObject.GetComponent<PieceCheck>().name = "green1x1";
                    break;
                case 4: // Yellow
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = yellow;
                    other.gameObject.GetComponent<PieceCheck>().name = "yellow1x1";
                    break;
                default:
                    break;
            }
        }
        if (other.tag == "1x1Top") // 1x1 Piece
        {
            Debug.Log("coloring 1x1 top");
            switch (colorID)
            {
                case 1: // Red
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = red;
                    other.gameObject.GetComponent<PieceCheck>().name = "redtop1x1";
                    break;
                case 2: // Blue
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = blue;
                    other.gameObject.GetComponent<PieceCheck>().name = "bluetop1x1";
                    break;
                case 3: // Green
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = green;
                    other.gameObject.GetComponent<PieceCheck>().name = "greentop1x1";
                    break;
                case 4: // Yellow
                    other.gameObject.GetComponentInChildren<MeshRenderer>().material = yellow;
                    other.gameObject.GetComponent<PieceCheck>().name = "yellowtop1x1";
                    break;
                default:
                    break;
            }
        }
    }
}
