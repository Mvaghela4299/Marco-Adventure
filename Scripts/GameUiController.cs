using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiController : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Level01");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level01");
    }
    public void NextLevelButton()
    {
        Debug.Log("Level 2 is start..!!");
        SceneManager.LoadScene("Level02");
    }
    public void BackButton()
    {
        Debug.Log("Back Menu..!!");
        SceneManager.LoadScene("Levels");
    }
}
