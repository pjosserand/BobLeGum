using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChunk : MonoBehaviour
{
    public float speed=2.0f;
    private Transform _goTransform;
    private void Start()
    {
        _goTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _goTransform.position = _goTransform.position + new Vector3(-1 * speed * Time.deltaTime, 0.0f, 0);
    }
}
