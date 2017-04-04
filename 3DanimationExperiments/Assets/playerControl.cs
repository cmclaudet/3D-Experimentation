using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
	private Animator animator;
	private bool isWalking;
	private bool weaponEquipped;
	private float walkSpeed;
	private float walkingMagnitude;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		walkSpeed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("up")) {
			isWalking = true;
			animator.SetInteger("walking", 1);
	//		transform.position += new Vector3(0, 0, walkSpeed*Time.deltaTime);
		} else if (Input.GetKey("down")) {
			isWalking = true;
			animator.SetInteger("walking", 1);
	//		transform.position += new Vector3(0, 0, -walkSpeed*Time.deltaTime);
		} else if (Input.GetKey("left")) {
			isWalking = true;
			animator.SetInteger("walking", 1);
	//		transform.position += new Vector3(-walkSpeed*Time.deltaTime, 0, 0);
		} else if (Input.GetKey("right")) {
			isWalking = true;
			animator.SetInteger("walking", 1);
	//		transform.position += new Vector3(walkSpeed*Time.deltaTime, 0, 0);
		} else {
			isWalking = false;
			animator.SetInteger("walking", 0);
		}

		switch(Input.inputString) {
			case "p":
				animator.SetTrigger("inPain");
				break;
			case "e":
				weaponEquipped = true;
				animator.SetBool("weaponEquipped", true);
				break;
			case "1":
				animator.SetInteger("Dead", 1);
				break;
			case "2":
				animator.SetInteger("Dead", 2);
				break;
			case "3":
				animator.SetInteger("Dead", 3);
				break;
		}

		if (isWalking && weaponEquipped) {
			if (walkingMagnitude <= 1.0f) {
				walkingMagnitude += 0.005f;
				animator.SetFloat("walkingMag", walkingMagnitude);
			} else {
				walkingMagnitude = 1.0f;
				animator.SetFloat("walkingMag", walkingMagnitude);
			}
		}		
	}
}
