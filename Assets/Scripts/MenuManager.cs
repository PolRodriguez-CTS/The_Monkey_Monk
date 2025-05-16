using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
    }
}
