using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        Debug.Log("Start Level Menu..!!");
        SceneManager.LoadScene("Levels");
    }
    public void YesExitButton()
    {
        Debug.Log("Exit Game..");
        //Application.Quit();
    }
    public void NoExitButton()
    {
        SceneManager.LoadScene("Main");
    }

    internal void completeLevel()
    {
        throw new NotImplementedException();
    }
}
