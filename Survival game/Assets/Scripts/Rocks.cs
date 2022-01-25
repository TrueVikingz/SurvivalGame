using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : Collectable
{
    public Sprite smallRocks;
    public int stoneAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = smallRocks;
            GameManager.instance.ShowText("+" + stoneAmount + " stone!", 25, Color.white, transform.position, Vector3.up * 50, 3.0f);
            GameManager.instance.stone += stoneAmount;
        }
    }
}
