using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCapsule : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private BatCapsuleFollower _batCapsuleFollowerPrefab;

    private void SpawnBatCapsuleFollower()
    {
        var follower = Instantiate(_batCapsuleFollowerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }

	void Start () {
        SpawnBatCapsuleFollower();
	}

}
