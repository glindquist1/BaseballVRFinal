using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


	public GameObject gc;
	private ScoreUpdater scr;

    public OVRInput.Controller controller;
    //bananas
	void Start(){
        gc = GameObject.Find("Game Controller");
        scr = gc.GetComponent<ScoreUpdater>();
	}
	// Update is called once per frame
	void Update () {
        OVRInput.Update();
        transform.localPosition = OVRInput.GetLocalControllerPosition(controller);
        transform.localRotation = OVRInput.GetLocalControllerRotation(controller);

		if (scr.game_over) {
            //listen for button press 'A' on controller
			if (OVRInput.GetDown(OVRInput.Button.One)) {          //Input.GetKeyDown ("r")
				Debug.Log ("A button (reset) input detected");
                scr.restart = true;
                scr.game_over = false;
                
				
			}
		}


	}
}
