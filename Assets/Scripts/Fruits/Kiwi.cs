using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : Fruit
{
    public Player player;

    Kiwi()
    {
        this.Score = 10;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        player.incScore(this);
    }
}
