using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : Collectable
{
    public Sprite emptyChest;
    public int rockAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + rockAmount + " stone");
        }
    }
}
