using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsuleFollower : MonoBehaviour {


    private BatCapsule leader;
    private Rigidbody follower_rigidbody;
    private Vector3 _velocity;

    [SerializeField]
    private float _sensitivity = 100f;
    // Use this for initialization

    private void Awake()
    {
        follower_rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        //_velocity = (leader.transform.position - follower_rigidbody.transform.position) * _sensitivity;//temp instead?
        //follower_rigidbody.velocity = _velocity;
        //follower_rigidbody.transform.rotation = leader.transform.rotation;


        //follower_rigidbody.transform.position = leader.transform.position;


        Vector3 destination = leader.transform.position;
        follower_rigidbody.transform.rotation = leader.transform.rotation;
        _velocity = (destination - follower_rigidbody.transform.position) * _sensitivity;
        follower_rigidbody.transform.position = leader.transform.position;
        follower_rigidbody.velocity = _velocity;



        //Vector3 destination = leader.transform.position;
        //follower_rigidbody.transform.rotation = transform.rotation;

        //_velocity = (destination - follower_rigidbody.transform.position) * _sensitivity;

        //follower_rigidbody.velocity = _velocity;
        //transform.rotation = leader.transform.rotation;

    }

    public void SetFollowTarget(BatCapsule ldr)
    {
        leader = ldr;
    }
}
