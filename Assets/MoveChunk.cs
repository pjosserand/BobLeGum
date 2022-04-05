using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChunk : MonoBehaviour
{
    private float speed;
    public GameManager gameManagerInstance;
    private Transform _goTransform;
    private void Start()
    {
        gameManagerInstance = GameManager._instance;
        _goTransform = transform;
        Invoke("GetMoveSpeed",0.2f);
    }

     void GetMoveSpeed()
    {
        speed = gameManagerInstance.GetLevelMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        _goTransform.position = _goTransform.position + new Vector3(-1 * speed * Time.deltaTime, 0.0f, 0);
    }
}
