﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileManager : MonoBehaviour
{
    public TextMeshPro debugTxt;
    private bool flipped;
    private int value;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void ChangeText()
    {
        Debug.Log("clicky in parent");
        debugTxt.text = "ouch";
    }

}
