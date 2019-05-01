using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer_Spawn_Zone : MonoBehaviour {

    private System.Random rnd;
    private GameObject Deer;
    private Bounds SpawnZone;



    void Start () {
        rnd = new System.Random();
        Deer = Resources.Load("Deer") as GameObject;
        SpawnZone = GameObject.FindGameObjectWithTag("DeerSpawnZone").GetComponent<BoxCollider2D>().bounds;

        int num = 5;
        while (num > 0) {
            SpawnDeer();
            num--;
        }
        
    }
	
	void FixedUpdate () {
       
    }

    void SpawnDeer() {
        GameObject spawnedDeer = Instantiate(Deer, new Vector3(Random.Range(SpawnZone.min.x, SpawnZone.max.x),
            SpawnZone.max.y + Deer.GetComponent<SpriteRenderer>().bounds.size.y / 2f, 0), Quaternion.identity);

    }
}