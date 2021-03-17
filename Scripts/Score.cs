using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Mytext;
    public Text HighScoreText;
    private int score;
    int Highscore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Highscore = 0;
        Mytext.text = "X : " + score;
        HighScoreText.text = PlayerPrefs.GetInt("HighScore", score).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coins")
        {
            score += 5;
            Mytext.text = "X : " + score;
            other.GetComponent<ColnCollect>().CoinMove(other.transform.position);
            //other.gameObject.tag = "Untagged";
            //Destroy(other.gameObject);
        }
        if(other.tag == "Fruits")
        {
            score += 10;
            Destroy(other.gameObject);
            Mytext.text = "X : " + score;
        }
    }
}
