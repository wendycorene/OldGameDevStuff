using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private GameObject one;
	private GameObject zero;
	private int numBits=21;
	public GameObject resetButton;
	public GameObject quitButton;
	int score = 0;
	public Text scoreTXT;
	public Text targetTXT;
	public Text endTXT;
	int target;

	// Use this for initialization
	void Start () {
		SpawnBits ();
		resetButton.gameObject.SetActive (false);
		quitButton.gameObject.SetActive (false);
		target = Random.Range(-15, 10);
		targetTXT.text = string.Format ("{0}", target);
	}
	
	// Update is called once per frame
	void Update () {
		if (score == target) {
			targetReached ();
		}
	}

	void SpawnBits(){
		List<GameObject> bitList = new List<GameObject> ();
		one = Resources.Load("One") as GameObject;
		zero = Resources.Load("Zero") as GameObject;
		float xLocation = -12.5f;
		bitList.Add (one);
		bitList.Add (zero);
		for (int i=0; i<numBits; i++){
			int randomBit = UnityEngine.Random.Range (0, 2);
			Instantiate (bitList[randomBit], new Vector3(xLocation,3.4f,0f), Quaternion.identity);
			xLocation += 1.25f;
		}
	}

	public void AnotherBitDestroyed(){
		numBits -= 1;
		if (numBits == 0) {
			resetButton.gameObject.SetActive (true);
			quitButton.gameObject.SetActive (true);
			endTXT.text = "YOU LOSE";
		}
	}

	public void IncreaseScore(int amount){
		score += amount;
		scoreTXT.text = string.Format ("{0}", score);
	}

	void targetReached(){
			List<GameObject> oneBits = new List<GameObject>(GameObject.FindGameObjectsWithTag ("One"));
			List<GameObject> zeroBits = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Zero"));
			foreach (GameObject bit in oneBits) {
				Destroy (bit);
			}
			foreach (GameObject bit in zeroBits) {
				Destroy (bit);
			}
		resetButton.gameObject.SetActive (true);
		quitButton.gameObject.SetActive (true);
		endTXT.text = "YOU WIN";
	}
}
