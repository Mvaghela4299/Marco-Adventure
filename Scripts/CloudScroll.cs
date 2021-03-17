using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScroll : MonoBehaviour
{
    private float _speed;
    private float _endPos;

    public void startFloating(float speed, float endPos)
    {
        _speed = speed;
        _endPos = endPos;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * _speed));

        if(transform.position.x < _endPos)
        {
            Debug.Log("2");
            Destroy(gameObject);
        }
    }
}
