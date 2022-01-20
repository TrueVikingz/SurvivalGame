using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Collectable
{
    public Sprite stump;
    public int woodAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = stump;
            Debug.Log("Grant " + woodAmount + " wood");
        }
    }
}
