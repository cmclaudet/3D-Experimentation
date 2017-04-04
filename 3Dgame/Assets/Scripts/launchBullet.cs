using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchBullet : MonoBehaviour {
	public GameObject bulletPrefab;
	public float launchForce;
	public Vector3 spawnPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject bullet = Instantiate(bulletPrefab);
			Vector3 direction = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y).normalized;
			bullet.transform.position = spawnPosition;
			bullet.GetComponent<Rigidbody>().AddForce(direction*launchForce);
		}
	}
}
