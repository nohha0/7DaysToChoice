using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene("Visual_Story");
    }

    public void ContinueGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
