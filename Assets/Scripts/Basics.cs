using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Basics : MonoBehaviour
{
    public GameObject[] objs = new GameObject[3];
    public Transform[] targets = new Transform[3];
    public float speed = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < targets.Length; ++i)
        {
            targets[i].Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
    }
}
