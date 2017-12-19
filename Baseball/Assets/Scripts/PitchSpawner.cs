using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchSpawner : MonoBehaviour {

    // Use this for initialization
    public Transform spawnPoint;
    public GameObject baseball;

	public GameObject gc;
	ScoreUpdater scr;

	private bool pitched = false;
	void Start () {
		scr = (ScoreUpdater)gc.GetComponent (typeof(ScoreUpdater));
		InvokeRepeating ("pitch", 2f, 3f);
    }

    void Update()
    {
/*        if (Input.GetKeyDown("p"))
        {
            //Vector3 spot = new Vector3(10, 2, -9);
            Instantiate(baseball, spawnPoint.position, spawnPoint.rotation);
        }    
        */
    }

	private void pitch(){
		if (scr.TimeLeft > 0) {
			Instantiate (baseball, spawnPoint.position, spawnPoint.rotation);
		} else {
			//do nothing
		}
	}
		
}
