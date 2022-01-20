using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : Collectable
{
    public Sprite stump;
    public int woodAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = stump;
            GameManager.instance.ShowText("+" + woodAmount + " wood!", 25, Color.green, transform.position, Vector3.up * 50, 3.0f);
        }
    }
}
