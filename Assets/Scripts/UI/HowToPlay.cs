using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject howtoplay;
    private bool acti;
    // Start is called before the first frame update
    void Start()
    {
        acti = false;
        howtoplay.SetActive(acti);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void read()
    {
        acti = true;
        howtoplay.SetActive(acti);
    }

    public void gotIt()
    {
        acti = false;
        howtoplay.SetActive(acti);
    }

    public bool getActi(){
        return acti;
    }
}
