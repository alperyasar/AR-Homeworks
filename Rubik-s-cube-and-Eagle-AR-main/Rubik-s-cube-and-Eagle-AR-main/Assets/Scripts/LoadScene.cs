using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayScene()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void EagleScene()
    {
        SceneManager.LoadScene("EagleScene");
    }
    public void MappingScene()
    {
        SceneManager.LoadScene("MappingScene");
    }
}

