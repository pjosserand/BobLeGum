using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _runSpeed;
    private bool _onTop;
    private float _direction;
    // Start is called before the first frame update
    void Start()
    {
      _rb = GetComponent<Rigidbody2D>();
      _onTop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ReverseGravity();
            }
        }
    }

    void ReverseGravity()
    {
        _rb.gravityScale*=-1;
        Rotation();
    }
    void Rotation()
    {
        if (!_onTop)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
            _direction = -1;
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
            _direction = 1;
        }
        transform.localScale = new Vector3(1*_direction,1,1);
        _onTop = !_onTop;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Foe"))
        {
            Debug.Log("Loose");
        }

        if (other.CompareTag("Finish"))
        {
            Debug.Log("Win");
        }
    }
}
