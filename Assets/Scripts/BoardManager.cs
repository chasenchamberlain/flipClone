using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    private int rows = 5;
    private int cols = 5;
    [SerializeField]
    private float padding = 1.05f;

    private int winWhenIHit0;
    private Point[] columnData;
    private int currentGlobalScore = 1;

    // Start is called before the first frame update
    void Start()
    {
        columnData = new Point[cols];
        CreateBoard();
    }

    private void CreateBoard()
    {
        GameObject tilePrefab = (GameObject)Instantiate(Resources.Load("Prefabs/tile"));
        GameObject infoPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/info"));


        // might not be necessary 
        // ---------------------
        FlipACoin(out bool rowHasA0);
        FlipACoin(out bool colHasA0);
        int rowIndexWith0 = GetIndexFor0Bombs(rowHasA0);
        int colIndexWith0 = GetIndexFor0Bombs(colHasA0);
        // ----------------------

        for (int row = 0; row < rows; row++)
        {
            //var tileData = BombSorting();
            int currentScore = 0;
            int currentBombs = 0;
            for (int col = 0; col <= cols; col++)
            {
                if (col == 5)
                {
                    GameObject info = (GameObject)Instantiate(infoPrefab, transform);
                    float posX = col * padding;
                    float posY = row * padding;

                    InfoManager infoTile = info.GetComponent(typeof(InfoManager)) as InfoManager;
                    if (infoTile != null)
                    {
                        infoTile.score = currentScore;
                        infoTile.bombCount = currentBombs;
                    }
                    info.transform.position = new Vector2(posX, posY);
                }
                else
                {
                    GameObject tile = (GameObject)Instantiate(tilePrefab, transform);
                    float posX = col * padding;
                    float posY = row * padding;

                    FlipACoin(out bool bombOrScore);
                    TileManager tileTile = tile.GetComponent(typeof(TileManager)) as TileManager;
                    if (tileTile != null)
                    {
                        if (bombOrScore) // true is bomb
                        {
                            tileTile.value = 0;
                            currentBombs++;
                            columnData[col].X++;
                        }
                        else // false is score
                        {
                            tileTile.value = UnityEngine.Random.Range(1, 4);
                            if (tileTile.value > 1)
                            {
                                winWhenIHit0++;
                            }
                            currentScore += tileTile.value;
                            columnData[col].Y += tileTile.value;
                        }
                    }
                    tile.transform.position = new Vector2(posX, posY);
                }
            }
        }
        Destroy(tilePrefab);

        // Do the bottom row of info tiles after the rows are done.
        for (int bCol = 0; bCol < rows; bCol++)
        {
            GameObject info = (GameObject)Instantiate(infoPrefab, transform);
            float posX = bCol * padding;
            float posY = -1 * padding;

            InfoManager infoTile = info.GetComponent(typeof(InfoManager)) as InfoManager;
            if (infoTile != null)
            {
                infoTile.score = columnData[bCol].Y;
                infoTile.bombCount = columnData[bCol].X;
            }
            info.transform.position = new Vector2(posX, posY);

        }

        Destroy(infoPrefab);

        transform.position = new Vector2(-2, -2);
    }

    private static int GetIndexFor0Bombs(bool rowOrColHasA0)
    {
        int indexWith0 = 666;
        if (rowOrColHasA0)
        {
            indexWith0 = UnityEngine.Random.Range(0, 5);
        }

        return indexWith0;
    }

    private static void FlipACoin(out bool rowOrCol)
    {
        if (UnityEngine.Random.Range(0, 2) < 1)
        {
            rowOrCol = true;
        }
        else
        {
            rowOrCol = false;
        }
    }

    public void MinusToWin(int value)
    {
        winWhenIHit0--;
        Debug.Log("Good click!" + winWhenIHit0);

        currentGlobalScore *= value;
        PlayerPrefs.SetInt("score", currentGlobalScore);
        PlayerPrefs.Save();
        Debug.Log("score = " + currentGlobalScore);
        if (winWhenIHit0 == 0)
        {
            Debug.Log("YOU WIN!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Lost()
    {
        Debug.Log("You lost Sorry");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
