using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
    public Player player;
    Saw()
    {
        this.damage = 5;
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
        player.rgbd2d().velocity = new Vector2(player.rgbd2d().velocity.x, 10f);
    }
}
