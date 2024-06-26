using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public bool isEscapeToExit;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                KembaliKeMenu();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            MulaiPermainan();
        }
    }

    public void Keluar()
    {
        Application.Quit();
    }


    public void MulaiPermainan()
    {
        SceneManager.LoadScene("PlayScane");
    }
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
