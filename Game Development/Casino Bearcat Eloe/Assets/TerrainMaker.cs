using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMaker : MonoBehaviour {
	public List<float> towerLocations = new List<float> ();
	//GameObject die;
	//ArrayList<GameObject> diceOptions = new ArrayList<GameObject> ();

	// Use this for initialization
	void Start () {
		generateTerrain ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateTerrain(){
		//die.AddComponent<BoxCollider2D>();
		//diceOptions = GameObject.FindGameObjectWithTag("dice");
		//<gameObject> diceList = Resources.LoadAll<gameObject>("dice");
		//List <GameObject> diceList = new List <GameObject>();
		//diceList.Add(GameObject.FindGameObjectWithTag("dice"));
		var diceOptions = GameObject.FindGameObjectsWithTag("dice");

		for (int i = 0; i < 9; i++) {
			int height = Random.Range (0, 10);
			float nums = -3.45f;
			for (int j = 0; j <= height; j++){
				//int randDie = Random.Range (0, diceList.Count-1);
				Instantiate (diceOptions[Random.Range(0, diceOptions.Length)], new Vector3 (towerLocations[i], nums, 0.0f), Quaternion.identity);
				nums = nums + .68f;
			}
		}
	}
}