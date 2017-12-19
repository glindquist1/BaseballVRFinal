using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpeed : MonoBehaviour {

    private Vector3 oldPos;
    private Vector3 newPos;
    private Vector3 velocity;

    private void Start()
    {
        oldPos = gameObject.transform.position;

    }

    private void FixedUpdate()
    {
        //Vector3 destination = _batFollower.transform.position;
        //_rigidbody.transform.rotation = transform.rotation;

        //_velocity = (destination - _rigidbody.transform.position) * _sensitivity;

        //_rigidbody.velocity = _velocity;
    }

    public Vector3 getVelocity()
    {
        return velocity;
    }
}
