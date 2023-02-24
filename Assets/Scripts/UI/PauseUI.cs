using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    private HowToPlay howToPlay;
    private ClearUI clearUI;
    private bool acti;
    // Start is called before the first frame update
    void Start()
    {
        howToPlay = gameObject.GetComponentInParent<HowToPlay>();
        clearUI = gameObject.GetComponentInParent<ClearUI>();
        Time.timeScale = 1;
        acti = false;
        display();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !howToPlay.getActi() && !clearUI.getActi())
        {
            acti = !acti;
            display();
            Time.timeScale = (acti ? 0 : 1);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void howtoplay()
    {
        howToPlay.read();
    }

    public void quit()
    {
        Application.Quit();
    }

    public void display()
    {
        pauseUI.SetActive(acti);
    }
}
