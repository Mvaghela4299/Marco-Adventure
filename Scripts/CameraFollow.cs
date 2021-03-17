using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 camPos;
    [SerializeField] private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        camPos = transform.position;
        camPos.x = player.position.x;

        //Minimum Camera's position
        if (camPos.x < minX)
            camPos.x = minX;

        //Maximum Camera's position
        if (camPos.x > maxX)
            camPos.x = maxX;

        transform.position = camPos;
    }
}
