using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;

    public int maxHealth = 100;
    public int currentHealth;
    public bool GameOver;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageEnemy(int damage)
    {
        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameOver = true;
            panel.gameObject.SetActive(true);
            Debug.Log("Game Over..!!");
        }
    }
}
