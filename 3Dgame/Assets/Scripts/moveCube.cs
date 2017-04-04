using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour {
	public float speed;
	private Vector3 spawnPosition;
	private Vector3 direction;
	
	// Use this for initialization
	void Start () {
		direction = new Vector3(-1f, 0, 0);
		spawnPosition = new Vector3(11f, 1, 0);
		transform.position = spawnPosition;
		GetComponent<Rigidbody>().AddForce(direction*speed);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
