using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player.setBoolOnGround(true);
        player.setBoolDoubleJump(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        player.setBoolOnGround(true);
        player.setBoolDoubleJump(false);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        player.setBoolOnGround(false);
        player.setBoolDoubleJump(false);
    }
}
