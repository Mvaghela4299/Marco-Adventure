using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoement : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    private string DEAD_NIMATION = "Dead";
    private Animator anim;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            sr.flipX = false;
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            sr.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Turn"))
        {
            if(moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
