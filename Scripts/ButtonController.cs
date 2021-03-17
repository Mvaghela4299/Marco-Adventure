using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public float Speed;
    public bool moveRight;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight == true)
        { // Here I have tried methods like Addforce and velocity, but for some reason it wasn't working!!
            GetComponent<Rigidbody2D>().AddForce(transform.right * Speed);
        }
        else if (moveRight == false)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * Speed);
        }
    }
    public void Left()
    {
        transform.position -= transform.forward * Time.deltaTime * moveSpeed;
    }
    public void Right()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
    public void Up()
    {

    }
}
