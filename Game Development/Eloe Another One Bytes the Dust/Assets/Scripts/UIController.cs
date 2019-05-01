using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("zero");
		Time.timeScale = 1;
	}

	public void Quit(){
		Application.Quit ();
	}
}
