using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class BtnHandlerStart : MonoBehaviour
{
    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
