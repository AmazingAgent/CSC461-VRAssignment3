using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject pieceParent;
    public GameObject piece;

    public void SpawnObject()
    {
        Debug.Log("spawning");
        GameObject newPiece = Instantiate(piece);
        newPiece.gameObject.transform.parent = pieceParent.transform;
    }
}
