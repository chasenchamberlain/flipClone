using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public TextMeshPro debugTxt;
    public int bombCount = 0;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //debugTxt.text = "-\n-";    
    }

    // Update is called once per frame
    void Update()
    {
        debugTxt.text = $"s-{score}\nb-{bombCount}";   
    }
}
