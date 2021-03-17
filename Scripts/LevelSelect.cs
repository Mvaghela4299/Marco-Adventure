using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached",0);

        for(int i=0; i < levelButtons.Length; i++)
        {
            if (i + 1 > LevelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void passLevel()
    {
        Debug.Log("Level" + PlayerPrefs.GetInt("LevelReached") + "Locked");
    }
    
    public void level_1_Button()
    {
        Debug.Log("Level 1 is start..!!");
        SceneManager.LoadScene("Level01");
    } 
    
    public void BackButton()
    {
        Debug.Log("Main Menu..!!");
        SceneManager.LoadScene("Main");
    }
}