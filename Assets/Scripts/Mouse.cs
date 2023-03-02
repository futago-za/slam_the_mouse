using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool isHeld;
    public event Action OnSlam = delegate { };

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        isHeld = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isHeld)
            {
                OnSlam();
            }
            isHeld = false;
        } else
        {
            isHeld = true;
        }
    }
}
