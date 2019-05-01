using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HengeController : MonoBehaviour {
	List<GameObject> henges = new List<GameObject> ();
	List<Material> colors = new List<Material> ();
	Material red;
	Material blue;
	Material green;
	Renderer rend;

	// Use this for initialization
	void Start () {
		red = Resources.Load ("Red", typeof(Material)) as Material;
		blue = Resources.Load ("Blue", typeof(Material)) as Material;
		green = Resources.Load ("Green", typeof(Material)) as Material;
		colors.Add (red);
		colors.Add (green);
		colors.Add (blue);
		henges.AddRange (GameObject.FindGameObjectsWithTag ("Henge"));
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = colors [Random.Range(0,3)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//replay the game
	public void Replay(){
		Start ();
	}

	void ChangeColor (Renderer rende){
		switch (rende.sharedMaterial.name.ToLower()) {
		case "red":
			rende.sharedMaterial = Resources.Load ("Green")as Material;
			break;
		case "blue":
			rende.sharedMaterial = Resources.Load ("Red")as Material;
			break;
		case "green":
			rende.sharedMaterial = Resources.Load ("Blue")as Material;
			break;
		default:
			break;
		}
	}
	void OnCollisionEnter(Collision col){
		print ("Play Audio");
		AudioData data;
		if (new System.Random().Next(0,10)>=5) {
			//play female ouch
			AudioClip clip = Resources.Load("Audio/FemaleOuch")as AudioClip;
			data = new AudioData (1, clip, 0, .7, false, 1f, 20);
		}else{
			//play male ouch
			AudioClip clip = Resources.Load("Audio/MaleOuch")as AudioClip;
			data = new AudioData (1, clip, 0, .5, false, 1f, 20);
		}
		print (data.Clip.samples);
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioEngine> ().PlayAudio (data);
		ChangeColor (GetComponent<Renderer>());
	}
}
