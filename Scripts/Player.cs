using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 12f;
    private float movement;
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private string DEAD_ANIMATION = "Dead";
    private string SLIDE_ANIMATION = "Slide";
    private string ATTACK_ANIMATION = "Attack";
    bool left,right,jumping,Dead,Attack,Slide,isGrounded,doublejump;
    private int canDoubleJump;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public GameObject bulletPrefab;
    public float shootSpeed = 20f;
    public Transform spawnPoint;
   
    // Awake is called first
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    //start is called after Awake method
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    private void Update()
    {
        PLayerMovement();
        AnimatePlayer();
        PlayerJump();
        if (left)       //player check move left side when button pressed
            rb.velocity = new Vector2(-moveForce, 0f);
        if (right)      //player check move right side when button pressed
            rb.velocity = new Vector2(moveForce, 0f);
        if(left == true)    //player play walk animation left side continuously when button pressed
            anim.Play(WALK_ANIMATION);
        if (right == true)  //player play walk animation right side continuously when button pressed
            anim.Play(WALK_ANIMATION);
        if(jumping == true)   //player play jump animation when button pressed continuously
            anim.Play(JUMP_ANIMATION);
        if (Dead == true)      //player play Dead animation when button pressed
            anim.Play(DEAD_ANIMATION);

        if (Input.GetKeyDown(KeyCode.J))
        {
            DamagePlayer(20);
        }
    }
    public void Shoot()
    {
        StartCoroutine(shootBullet());
    }
    private IEnumerator shootBullet()
    {

        // Spawn the bullet from the prefab.
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(2f);
        //destroy stone
        Destroy(bullet.gameObject, 2f);
    }
    //damage player
    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
    }
    //player move left side when button is pressed
    public void MoveLeft()
    {
        anim.Play(WALK_ANIMATION);
        sr.flipX = true;        //player face left side move
        left = true;
    }
    //player move right side when button is pressed
    public void MoveRight()
    {
        anim.Play(WALK_ANIMATION);
        sr.flipX = false;       //player face right side move
        right = true;
    }
    //player jump when button is pressed
    public void Jump()
    {
        jumping = true;
        anim.Play(JUMP_ANIMATION);
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
    //player stop left,right and jump method
    public void StopMoving()
    {
        left = false;
        right = false;
        jumping = false;
        Dead = false;
        Attack = false;
        rb.velocity = Vector2.zero;
    }
    //player attack enemy
    public void PlayerAttack()
    {
        Attack = true;
        anim.Play(ATTACK_ANIMATION);
    }
    public void PLayerMovement()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0f, 0f) * moveForce * Time.deltaTime;
    }
    void AnimatePlayer()
    {
        //we are going to right side
        if (movement > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        //we are going to left side
        else if (movement < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    //player jump
    public void  PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            doublejump = true;
            anim.Play(JUMP_ANIMATION);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        if(isGrounded == true)
        {
            canDoubleJump = 2;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && canDoubleJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            canDoubleJump--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && canDoubleJump == 0 && isGrounded == true)
        {
            anim.Play(JUMP_ANIMATION);
            rb.velocity = Vector2.up * jumpForce;
            doublejump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    
}
