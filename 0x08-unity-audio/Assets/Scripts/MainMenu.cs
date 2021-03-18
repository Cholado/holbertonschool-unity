using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public void LevelSelect(int level)
    {
        if (level == 1)
            SceneManager.LoadScene("Level01");

        if (level == 2)
            SceneManager.LoadScene("Level02");

        if (level == 3)
            SceneManager.LoadScene("Level03");

    }
    public void Options()
    {
        //PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options"); ;
    }
    public void QuitGame()
    {
        //PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        Debug.Log("Exited");
        Application.Quit();
    }
    public void PreviousScene()
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
    }

}
