using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text time, count,end;
	float getTime = 0.0f;
	int monoliths ;
	GameObject player;
	bool hasWon=false;
	bool blocker=true;
	// Use this for initialization
	void Start () {
		monoliths = (GameObject.FindGameObjectsWithTag ("Henge").Length);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (blocker) {
			if (getTime < 30.00f) {
				getTime = getTime + Time.deltaTime;
				time.text = Mathf.Round (getTime).ToString () + "sec";
			} else {
				hasWon = GameObject.FindGameObjectWithTag ("Well").GetComponent<WellController> ().HasWon ();
				blocker = false;
				//stop this if branch
				if (hasWon) {
					end.text = "Congratulations, you have won!!!!!!";
					Camera.main.GetComponent<AudioEngine> ().PlayBackgroundSound (Resources.Load ("Audio/Win")as AudioClip);
				} else {
					Camera.main.GetComponent<AudioEngine> ().PlayBackgroundSound (Resources.Load ("Audio/Failure")as AudioClip);
					end.text = "Oh dear you have lost.";
				}
			}
		} else {
			StartCoroutine ("ChangeColor");
		}
		count.text = (GameObject.FindGameObjectsWithTag ("Henge").Length).ToString ();
	}

	public void replayGame(){
		count.text = monoliths.ToString ();
		getTime = 0.0f;
		foreach (var item in GameObject.FindGameObjectsWithTag ("Henge")) {
			item.GetComponent<HengeController> ().Replay ();
		}
		GameObject.FindGameObjectWithTag ("Well").GetComponent<WellController>().Replay ();
	}
	IEnumerator ChangeColor(){
		end.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
		yield return new WaitForSeconds (2f);
	}
}
