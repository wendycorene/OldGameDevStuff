using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellController : MonoBehaviour {
	List<Material> colors = new List<Material> ();
	Material red;
	Material blue;
	Material green;
	GameObject well;
	Renderer rend;

	// Use this for initialization
	void Start () {
		red = Resources.Load ("Red", typeof(Material)) as Material;
		blue = Resources.Load ("Blue", typeof(Material)) as Material;
		green = Resources.Load ("Green", typeof(Material)) as Material;
		colors.Add (red);
		colors.Add (green);
		colors.Add (blue);
		well = GameObject.FindGameObjectWithTag ("Well");
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = colors [Random.Range(0,3)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Replay(){
		Start ();
	}
	public bool HasWon(){
		foreach (var item in GameObject.FindGameObjectsWithTag("Henge")) {
			if (item.GetComponent<Renderer>().sharedMaterial.name!=rend.sharedMaterial.name) {
				return false;
			}
		}
		return true;
	}
}
