using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class followPlayer : MonoBehaviour {
	public GameObject player;
	public Vector3 offset;
	public bool isFollowing {get {return true;}}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.TransformPoint(offset);
		transform.LookAt(player.transform);
	}
}
