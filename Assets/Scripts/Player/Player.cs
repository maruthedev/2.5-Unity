using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public enum State
    {
        IDLE, RUNNING, JUMPING, DOUBLEJUMPING, FALLING, HANDLING,
        TAKINGDMG
    };
    private State state;
    private new Rigidbody2D rigidbody2D;
    private readonly float speed = 5f;
    private SpriteRenderer spriteRenderer;
    private bool onGround;
    private bool doubleJump;
    private Animator animator;
    private int HP;
    private readonly int maxHP = 5;
    public GameObject StartPoint;
    public EnterGate gate;
    private int TotalScore;
    private bool clear;

    // Start is called before the first frame update
    void Start()
    {
        state = State.IDLE;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        onGround = true;
        doubleJump = false;
        animator = gameObject.GetComponent<Animator>();
        HP = maxHP;
        this.transform.position = StartPoint.transform.position;
        TotalScore = 0;
        clear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!clear)
        {
            Movement();
            Handle();
        }
    }

    private void Movement()
    {
        bool inp;
        // movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inp = true;
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            inp = true;
            rigidbody2D.velocity = new Vector2(+speed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
        }
        else inp = false;

        // jump
        if (onGround && Input.GetKeyDown(KeyCode.UpArrow))
        {
            onGround = false;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 2.5f * speed);
        }
        else if (!onGround && !doubleJump && Input.GetKeyDown(KeyCode.UpArrow))
        {
            doubleJump = true;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 2.5f * speed);
        }


        // animation
        if (onGround && !inp)
        {
            state = State.IDLE;
        }
        else if (onGround && inp)
        {
            state = State.RUNNING;
        }
        if (!onGround && !doubleJump && rigidbody2D.velocity.y > 0)
        {
            state = State.JUMPING;
        }
        else if (!onGround && doubleJump && rigidbody2D.velocity.y > 0)
        {
            state = State.DOUBLEJUMPING;
        }
        else if (!onGround && rigidbody2D.velocity.y <= 0)
        {
            state = State.FALLING;
        }
        updateAnimation();

        // dead
        if (HP <= 0 || (this.transform.position.y <= -6.5 && !gate.getEnter()) ||
        this.transform.position.y <= -20)
        {
            respawn();
        }
    }

    private void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Handle()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            state = State.HANDLING;
        }
    }

    public void updateAnimation()
    {
        animator.SetInteger("state", (int)this.state);
    }

    public void setBoolOnGround(bool b)
    {
        onGround = b;
    }

    public void setBoolDoubleJump(bool b)
    {
        doubleJump = b;
    }

    public int getHP()
    {
        return HP;
    }

    public void decHP(Trap trap)
    {
        state = State.TAKINGDMG;
        HP -= trap.damage;
    }

    public void decHP(Enemy enemy)
    {
        state = State.TAKINGDMG;
        HP -= enemy.damage;
    }

    public void incHP()
    {

    }

    public string getPosition()
    {
        return "x: " + this.transform.position.x + " - y:" + this.transform.position.y;
    }

    public Rigidbody2D rgbd2d()
    {
        return rigidbody2D;
    }

    public State getState()
    {
        return state;
    }

    public void setState(Player.State s)
    {
        this.state = s;
    }

    public void incScore(Fruit fruit)
    {
        TotalScore += fruit.Score;
    }

    public string getScore()
    {
        return "" + this.TotalScore.ToString();
    }

    public void setClear(bool b)
    {
        this.clear = b;
    }
}
