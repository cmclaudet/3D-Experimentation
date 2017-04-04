using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class movePlayer : MonoBehaviour {
	public float playerSpeed;
	public float rotationSpeed;
	public float jumpHeight;
	private float initialJumpSpeed;
	private int playerScore;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		initialJumpSpeed = getInitialJumpSpeed();
		scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("up")) {
			transform.position += transform.forward*Time.deltaTime*playerSpeed;
		} if (Input.GetKey("down")) {
			transform.position -= transform.forward*Time.deltaTime*playerSpeed;
		} if (Input.GetKey("left")) {
			transform.Rotate(-Vector3.up * Time.deltaTime*rotationSpeed);
		} if (Input.GetKey("right")) {
			transform.Rotate(Vector3.up * Time.deltaTime*rotationSpeed);
		}

		if (Input.GetKeyDown("space")) {
			GetComponent<Rigidbody>().velocity = new Vector3(0, initialJumpSpeed, 0) ;
		}
	}

	float getInitialJumpSpeed() {
		return Mathf.Pow(2f*9.8f*jumpHeight, 0.5f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("pickup")) {
			other.gameObject.SetActive(false);
			playerScore += 1;
			scoreText.text = "Score: " + playerScore;
		}
	}

	void OnCollisionStay(Collision other){
    	if(other.gameObject.tag == "platform"){
        	transform.parent = other.transform;
        }
    }
 	void OnCollisionExit(Collision other){
    	if(other.gameObject.tag == "platform"){
        	transform.parent = null;   
        }
    }    
}
