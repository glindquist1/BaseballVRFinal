using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStrike : MonoBehaviour {

    public Text ScoreBoardDisplay;
    public AudioClip strike;
    Mover ball;
    AudioSource src;
    // Use this for initialization
    void Start()
    {
        src = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        ball = other.GetComponent<Mover>();
        if (!ball.hit_bat)
        {
            ScoreBoardDisplay.text = "Strike";
            src.PlayOneShot(strike);
        }

        else
            ScoreBoardDisplay.text = "Foul Ball";
        StartCoroutine(ClearText());
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2f);
        ScoreBoardDisplay.text = "";
    }
}
