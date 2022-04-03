using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMap : MonoBehaviour
{
    public float _speed;
    public GameObject prefab;
    public float width=1.0f;

    public Queue<GameObject> queue = new Queue<GameObject>();

    public void Start()
    {
        queue.Enqueue(transform.GetChild(0).gameObject);
        queue.Enqueue(transform.GetChild(1).gameObject);
        queue.Enqueue(transform.GetChild(2).gameObject);
    }
    void Update()
    {
        transform.position = transform.position + new Vector3(-1 * _speed * Time.deltaTime, 0.0f, 0);
    }
    public void DrawNewGround()
    {
        Debug.Log("Draw new ground");
        GameObject oldGround = queue.Dequeue();
        oldGround.transform.position += new Vector3(width / 2, 0, 0);
        queue.Enqueue(oldGround);
    }
}
