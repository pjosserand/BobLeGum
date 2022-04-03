using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCollider : MonoBehaviour
{
    private EndlessMap EndlessMap;

    private void Start()
    {
        EndlessMap = transform.parent.parent.GetComponent<EndlessMap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(("Player")))
        {
            //Debug.Log("player passed a checkpoint");
            EndlessMap.DrawNewGround();
        }
    }
}
