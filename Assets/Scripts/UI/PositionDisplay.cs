using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PositionDisplay : MonoBehaviour
{
    public Player player;
    private Text text;
    // Start is called before the first frame update

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + player.getPosition().ToString();
    }
}
