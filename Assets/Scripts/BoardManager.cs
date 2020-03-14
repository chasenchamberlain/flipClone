using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 5;
    [SerializeField]
    private int cols = 5;
    [SerializeField]
    private float padding = 1.05f;

    // Start is called before the first frame update
    void Start()
    {
        CreateBoard();    
    }

    private void CreateBoard()
    {
        GameObject tilePrefab = (GameObject)Instantiate(Resources.Load("Prefabs/tile"));
        GameObject infoPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/info"));
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(tilePrefab, transform);

                float posX = col * padding;
                float posY = row * padding;

                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(tilePrefab);
        Destroy(infoPrefab);

        //float gridW = cols * padding;
        //float gridH = rows * padding;
        //transform.position = new Vector2(-gridW / 2 + padding / 2, gridH / 2 - padding / 2);
        transform.position = new Vector2(-2, -2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
