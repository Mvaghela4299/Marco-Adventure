using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject panel;
    public string nextLevel = "Level2";
    public int levelUnlock = 1;

    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            panel.gameObject.SetActive(true);
            Debug.Log("Level Completed..!!");
            PlayerPrefs.SetInt("LevelReached", levelUnlock);
        }
    }
}
