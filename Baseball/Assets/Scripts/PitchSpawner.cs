using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchSpawner : MonoBehaviour {

    // Use this for initialization
    public Transform spawnPoint;
    public GameObject baseball;
    public GameObject player;
	public GameObject gc;
	ScoreUpdater scr;

	private bool pitched = false;
	void Start () {
        //scr = (ScoreUpdater)gc.GetComponent (typeof(ScoreUpdater));
        gc = GameObject.Find("Game Controller");
        scr = gc.GetComponent<ScoreUpdater>();
        InvokeRepeating ("pitch", 2f, 5f);
    }

    void Update()
    {
        /*        if (Input.GetKeyDown("p"))
                {
                    //Vector3 spot = new Vector3(10, 2, -9);
                    Instantiate(baseball, spawnPoint.position, spawnPoint.rotation);
                }    
                */
        if (scr.handSelect)
        {
            if (!scr.righty)
            {
                player.transform.position = new Vector3(20F, 1.51F, -17F);
            }
            else
            {
                player.transform.position = new Vector3(18.551F, 1.51F, -18.406F);
            }
        }
    }

        private void pitch(){
		if (scr.TimeLeft > 0) {
			Instantiate (baseball, spawnPoint.position, spawnPoint.rotation);
		} else {
			//do nothing
		}
	}
		
}
