using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFoulBall : MonoBehaviour {

    public Text ScoreBoardDisplay;


    private void OnTriggerEnter(Collider other)
    {
        ScoreBoardDisplay.text = "Foul Ball";
        StartCoroutine(ClearText());
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2f);
        ScoreBoardDisplay.text = "";
    }
}
