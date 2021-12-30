﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool _goingDown = false;

    [SerializeField]
    private Transform _origin, _target;

    private float _speed = 2.0f;


    void FixedUpdate()
    {
        if(_goingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else if(_goingDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _origin.position, _speed * Time.deltaTime);
        }
    }

    public void callElevator()
    {
        _goingDown = !_goingDown;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
