using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileManager : MonoBehaviour
{
    public TextMeshPro debugTxt;
    private bool flipped = false;
    public int value;
    private Animator myAnimator;
    private SpriteRenderer spRender;
    private Sprite noSprite;
    private Color startcolor;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        spRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //debugTxt.text = $"{value}";

    }


    private void OnMouseDown()
    {
        if (!flipped)
        {
            spRender.sprite = noSprite;
            flipped = true;
            switch (value)
            {
                case 0:
                    myAnimator.Play("bomb_flip");
                    break;
                case 1:
                    myAnimator.Play("one_flip");
                    break;
                case 2:
                    myAnimator.Play("two_flip");
                    break;
                default:
                    myAnimator.Play("three_flip");
                    break;
            }
        }
        if (value > 1)
        {
            SendMessageUpwards("MinusToWin", value);
        }
        else if (value == 0)
        {
            SendMessageUpwards("Lost");
        }
    }

    private void OnMouseEnter()
    {
        startcolor = spRender.material.color;
        spRender.material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        spRender.material.color = startcolor;
    }

}
