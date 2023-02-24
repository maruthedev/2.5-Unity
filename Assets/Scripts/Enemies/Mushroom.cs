using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    public Player player;
    private enum Direction { LEFT, RIGHT, DEATH };
    private Direction dir;
    private SpriteRenderer spriteRenderer;
    private new Collider2D collider2D;
    Mushroom()
    {
        this.damage = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        dir = Direction.RIGHT;
        animator.SetBool("alive", true);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        collider2D = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(dir);
    }

    void Movement(Direction dir)
    {
        if (dir == Direction.LEFT)
        {
            spriteRenderer.flipX = false;
            rigidbody2D.velocity = new Vector2(-4f, 0);
        }
        else if (dir == Direction.RIGHT)
        {
            spriteRenderer.flipX = true;
            rigidbody2D.velocity = new Vector2(4f, 0);
        }
        else
        {
            this.rigidbody2D.velocity = new Vector2(0, 10f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player.getState() == Player.State.FALLING)
            {
                death();
            }
            else
            {
                player.decHP(this);
                push(player);
            }
        }
        else if (other.tag == "Platform")
        {
            if (dir == Direction.LEFT) dir = Direction.RIGHT;
            else dir = Direction.LEFT;
        }
    }

    private void death()
    {
        dir = Direction.DEATH;
        Destroy(collider2D);
        rigidbody2D.gravityScale = 100;
        animator.SetBool("alive", false);

        if (this.transform.position.y <= -7f)
        {
            Destroy(gameObject);
        }
    }

    private void push(Player player)
    {
        if (player.transform.position.x <= this.transform.position.x)
        {
            player.rgbd2d().velocity = new Vector2(-15f, 0);
        }
        else
        {
            player.rgbd2d().velocity = new Vector2(+15f, 0);
        }
    }
}
