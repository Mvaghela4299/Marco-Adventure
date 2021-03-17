﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRiver : MonoBehaviour
{
    public float speed = 0.5f;
    public MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        renderer.material.mainTextureOffset = offset;
    }
}
