using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileManager : MonoBehaviour
{
    public TextMeshPro debugTxt;
    private bool flipped = false;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        debugTxt.text = $"{value}";
    }


    private void ChangeText()
    {
        flipped = true;
        if (value > 1)
        {
            SendMessageUpwards("MinusToWin", value);
        }
        else if (value == 0)
        {
            SendMessageUpwards("Lost");
        }
    }

}
