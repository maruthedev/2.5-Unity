using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private Animator animator;
    private bool reach;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        reach = false;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("reach", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        reach = true;
        player.setClear(reach);
        animator.SetBool("reach", true);
    }

    public bool getReach()
    {
        return reach;
    }
}
