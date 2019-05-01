using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : MonoBehaviour {
	public GameObject meteor;

	// Use this for initialization
	void Start () {
		//makeMeteor();
		Invoke("makeMeteor", .5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void makeMeteor(){
		int spot1 = Random.Range (-10, 50);
		Instantiate (meteor, new Vector3 (spot1, 10, 0), Quaternion.identity);
		//Instantiate (meteor, new Vector3 (0, 10, 0), Quaternion.identity);
	}

	}
