using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCubes : MonoBehaviour {
	public GameObject cubePrefab;
	public float cubeSpawnFrequency;
	private float timeSinceSpawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;

		if (timeSinceSpawn >= cubeSpawnFrequency) {
			Instantiate(cubePrefab);
			timeSinceSpawn = 0;
		}
	}

}
