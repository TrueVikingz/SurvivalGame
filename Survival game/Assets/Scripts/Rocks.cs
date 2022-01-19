using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : Collectable
{
    public Sprite smallRocks;
    public int rockAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = smallRocks;
            Debug.Log("Grant " + rockAmount + " stone");
        }
    }
}
