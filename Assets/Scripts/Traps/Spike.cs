using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{
    public Player player;
    Spike()
    {
        this.damage = 1;
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
        dealDamage(player);
        push(player);
    }

    private void dealDamage(Player player)
    {
        player.decHP(this);
    }

    private void push(Player player)
    {
        if (player.transform.position.x <= this.transform.position.x)
        {
            player.rgbd2d().velocity = new Vector2(-3f, 12f);
        }
        else
        {
            player.rgbd2d().velocity = new Vector2(3f, 12f);
        }
    }
}
