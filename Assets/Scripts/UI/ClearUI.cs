using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    public GameObject clearUI;
    public EndPoint endPoint;
    private bool acti;
    // Start is called before the first frame update
    void Start()
    {
        acti = false;
        display();
    }

    // Update is called once per frame
    void Update()
    {
        if (endPoint.getReach())
        {
            acti = true;
            display();
            Time.timeScale = 0.2f;
        }
    }

    private void display()
    {
        clearUI.SetActive(acti);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
    }

    public bool getActi(){
        return acti;
    }
}
