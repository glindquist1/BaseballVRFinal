using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggRandomizer : MonoBehaviour {


	public AnimationCurve myCurve;

	private float startHeight;

	private bool animated = false;
	private float heightMultiplier;
	private float timeDelay;

	private bool animationStarted = false;

	private Color[] colorlist = new Color[7];
	// Use this for initialization
	void Start () {
		colorlist [0] = new Color (19f/255f, 45f/255f, 71f/255f, 1.0f);
		colorlist [1] = new Color (232f/255f, 74f/255f, 39f/255f, 1.0f);
		colorlist [2] = new Color (25f/255f, 103f/255f, 229f/255f, 1.0f);
		colorlist [3] = new Color (86f/255f, 172f/255f, 247f/255f, 1.0f);
		colorlist [4] = new Color (247f/255f, 153f/255f, 86f/255f, 1.0f);
		colorlist [5] = new Color (255f/255f, 111f/255f, 28f/255f, 1.0f);
		colorlist [6] = new Color (237f/255f, 45f/255f, 45f/255f, 1.0f);

		if (Random.value > 0.8) {
			animated = true;
			heightMultiplier = Random.value;
			timeDelay = Random.value * 2;
			startHeight = transform.position.y;
		}
			
		GetComponent<Renderer>().material.color = colorlist[Random.Range(0, colorlist.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		if (animated) {
			transform.position = new Vector3 (transform.position.x, startHeight + heightMultiplier * myCurve.Evaluate (((Time.time + timeDelay) % myCurve.length)), transform.position.z);

		}
	}
}
