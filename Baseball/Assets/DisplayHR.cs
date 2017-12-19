using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHR : MonoBehaviour {

    public Text ScoreBoardDisplay;

	public GameObject gc;

	private ScoreUpdater scoringScript;
	void Start(){
		scoringScript = (ScoreUpdater)gc.GetComponent (typeof(ScoreUpdater));
	}

    private void OnTriggerEnter(Collider other)
    {
		scoringScript.increaseScore ();
        ScoreBoardDisplay.text = "Home Run!";
        StartCoroutine(ClearText());
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2f);
        ScoreBoardDisplay.text = "";
    }
}
