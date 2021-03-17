using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<Player>() && collision.contacts[0].normal.y > 0.5f)
        {
            StartCoroutine(Break());
        }
    }
    private IEnumerator Break()
    {
        particle.Play();

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
