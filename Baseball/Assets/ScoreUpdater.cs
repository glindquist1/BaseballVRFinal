﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

	public Text DisplayText;

	public int currScoreVal;
	public Text currScoreDisplayer;

	public int currHighScoreVal;
	public Text currHighScoreDisplayer;

	public float TimeLeft = -1f;//please
	private float initialTime;

    public bool righty;

	public Text timer;

	public bool game_over = false;
    public bool restart = true;

	private bool busy = false;

	private bool alreadyDone = false;

    public bool handSelect = false;

	private Color yellowColor = new Color (255f / 255f, 242f / 255f, 62f / 255f, 1.0f);

	private float timeStop;
	// Use this for initialization
	void Start () {
		currScoreVal = 0;
		initialTime = 60F;
		DisplayText.color = yellowColor;
		currScoreDisplayer.color = yellowColor;
		currHighScoreDisplayer.color = yellowColor;
		timer.color = yellowColor;
        restart = true;
        righty = true;
        TimeLeft = -1f;
    }
	
	// Update is called once per frame
	void Update () {
		if (!restart) {
			TimeLeft -= Time.deltaTime;
			if (TimeLeft > 0) {
				timer.text = "" + (int)TimeLeft;

			} else {

				if (!busy && alreadyDone == false) {
					StartCoroutine (wasteTimeAtGameOver ());
				} else {

					if (game_over == true && !restart) {
						if (((int)TimeLeft) % 2 == 0) {
							DisplayText.text = "Game Over";
						} else {
							DisplayText.text = "Press 'A' to Restart";
						}
					}
				}

				/*game_over = true;
				gameOver();
				if (game_over == true) {
					if (((int)TimeLeft) % 2 == 0) {
						DisplayText.text = "Game Over";
					} else {
						DisplayText.text = "Press 'A' to Restart";
					}
				}
				*/
			}
		}
        else if (!handSelect)
        {
            //Debug.Log("handselect");
            alreadyDone = false;
            timer.text = "";
            TimeLeft -= Time.deltaTime;
            if (((int)TimeLeft) % 2 == 0)
            {
                DisplayText.text = "Press A for Righty";
            }
            else
            {
                DisplayText.text = "Press X for Lefty";
            }
            if (Input.GetKeyDown("r") || OVRInput.GetDown(OVRInput.RawButton.A))
            {
                righty = true;
                handSelect = true;
                TimeLeft = 60f;
            }
            if (Input.GetKeyDown("l") || OVRInput.GetDown(OVRInput.RawButton.X))
            {
                righty = false;
                handSelect = true;
                TimeLeft = 60f;
            }

        }
        else {
			alreadyDone = false;
			DisplayText.text = "Play Ball!";
			DisplayText.color = yellowColor;
			currScoreVal = 0;
			currScoreDisplayer.text = "" + currScoreVal;
			currScoreDisplayer.color = yellowColor;
			TimeLeft = initialTime;
			DisplayText.color = yellowColor;
			restart = false;
		}
	}

	public void increaseScore(){
		currScoreVal++;
		currScoreDisplayer.text = "" + currScoreVal;
		if (currScoreVal >= currHighScoreVal) {
			currScoreDisplayer.color = Color.green;
		}
	}

	IEnumerator wasteTimeAtGameOver(){

		busy = true;
		alreadyDone = true;
		Debug.Log ("start wasting time");
		yield return new WaitForSeconds (5f);

		Debug.Log ("end wasting time");



		DisplayText.color = Color.red;

		if (currScoreVal > currHighScoreVal) {
			currHighScoreVal = currScoreVal;
			currHighScoreDisplayer.text = "" + currHighScoreVal;
		}

		game_over = true;
        handSelect = false;
		busy = false;
	}
		
		
}
