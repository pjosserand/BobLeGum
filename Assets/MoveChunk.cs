using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChunk : MonoBehaviour
{
    public float _speed=2.0f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(-1 * _speed * Time.deltaTime, 0.0f, 0);
    }
}
