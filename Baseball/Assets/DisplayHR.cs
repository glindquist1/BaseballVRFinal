using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHR : MonoBehaviour {

    public Text ScoreBoardDisplay;

	public GameObject gc;
    public GameObject firework;
    public GameObject spawn1, spawn2, spawn3;
    private ScoreUpdater scoringScript;
	void Start(){
		scoringScript = (ScoreUpdater)gc.GetComponent (typeof(ScoreUpdater));
        spawn1 = GameObject.Find("FireworkSpawn1");
        spawn2 = GameObject.Find("FireworkSpawn2");
        spawn3 = GameObject.Find("FireworkSpawn3");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Home Run Registered");
		scoringScript.increaseScore ();
        ScoreBoardDisplay.text = "Home Run!";
        StartCoroutine(ClearText());
        Debug.Log("home runs collision detected");
        GameObject f1 = Instantiate(firework, spawn1.transform.position, spawn1.transform.rotation);
        GameObject f2 = Instantiate(firework, spawn2.transform.position, spawn2.transform.rotation);
        GameObject f3 = Instantiate(firework, spawn3.transform.position, spawn3.transform.rotation);
        StartCoroutine(kill(f1, f2, f3));
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2f);
        ScoreBoardDisplay.text = "";
    }
    IEnumerator kill(GameObject f1, GameObject f2, GameObject f3)
    {
        Debug.Log("wait to kill");
        
        yield return new WaitForSeconds(2f);
        Debug.Log("killing");
        Destroy(f1);
        Destroy(f2);
        Destroy(f3);
    }
}
