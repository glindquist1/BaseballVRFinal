//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Controller : MonoBehaviour {


//	public GameObject gc;
//	private ScoreUpdater scr;

//    public OVRInput.Controller controller;
//    //bananas
//	void Start(){
//        gc = GameObject.Find("Game Controller");
//        scr = gc.GetComponent<ScoreUpdater>();
//	}
//	// Update is called once per frame
//	void Update () {
//        //OVRInput.Update();
//        transform.localPosition = OVRInput.GetLocalControllerPosition(controller);
//        transform.localRotation = OVRInput.GetLocalControllerRotation(controller);

//		if (scr.game_over) {
//            //listen for button press 'A' on controller
//            Debug.Log("Game over detected");
//			if (OVRInput.GetDown(OVRInput.Button.One)) {          //Input.GetKeyDown ("r")
//				Debug.Log ("A button (reset) input detected");
//                scr.restart = true;
//                scr.game_over = false;


//			}
//		}


//	}
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{


    public GameObject gc;
    private ScoreUpdater scr;

    public OVRInput.Controller controllerRight;
    public OVRInput.Controller controllerLeft;

    //bananas
    void Start()
    {
        gc = GameObject.Find("Game Controller");
        scr = gc.GetComponent<ScoreUpdater>();
        //hand = GameObject.Find("PitchSpawnPosition").GetComponent<PitchSpawner>();
    }
    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if (scr.righty)
        {
            //OVRInput.Update();
            transform.localPosition = OVRInput.GetLocalControllerPosition(controllerRight);
            transform.localRotation = OVRInput.GetLocalControllerRotation(controllerRight);

            if (scr.game_over)
            {
                //listen for button press 'A' on controller
                if (OVRInput.GetDown(OVRInput.RawButton.A) || Input.GetKeyDown("p"))
                {          //Input.GetKeyDown ("r")
                    Debug.Log("A button (reset) input detected");
                    scr.restart = true;
                    scr.game_over = false;
                    scr.handSelect = false;

                }
            }
        }
        else
        {
            //OVRInput.Update();
            transform.localPosition = OVRInput.GetLocalControllerPosition(controllerLeft);
            transform.localRotation = OVRInput.GetLocalControllerRotation(controllerLeft);

            if (scr.game_over)
            {
                //listen for button press 'A' on controller
                if (OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetKeyDown("p"))
                {          //Input.GetKeyDown ("r")
                    Debug.Log("X button (reset) input detected");
                    scr.restart = true;
                    scr.game_over = false;
                    scr.handSelect = false;
                }
            }
        }



    }
}