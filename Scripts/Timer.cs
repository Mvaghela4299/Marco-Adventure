using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float gameTimer = 101f;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }
        if(gameTimer < 0)
        {
            panel.gameObject.SetActive(true);
        }

        int seconds = (int)(gameTimer % 400);
        string time = string.Format("{0:00}", seconds);

        TimerText.text = time;
    }
}
