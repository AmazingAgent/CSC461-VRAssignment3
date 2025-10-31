using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject pieceParent;
    public GameObject piece;

    public GameObject spawnPos;

    void Start()
    {

        piece.SetActive(false);
    }
    void Update()
    {

    }
    public void SpawnObject()
    {
        Debug.Log("spawning");
        GameObject newPiece = Instantiate(piece);
        newPiece.transform.position = spawnPos.transform.position;
        newPiece.gameObject.transform.parent = pieceParent.transform;
        newPiece.SetActive(true);
    }
}
