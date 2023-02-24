using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretGift : MonoBehaviour
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
        if (player.getState() == Player.State.HANDLING)
        {
            openBox();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (player.getState() == Player.State.HANDLING)
        {
            openBox();
        }
    }

    private void openBox()
    {
        Debug.Log("opened");
    }
}
