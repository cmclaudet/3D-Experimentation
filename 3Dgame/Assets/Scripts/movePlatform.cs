using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour {
	public GameObject floor;
	public float desiredHeight;
	public float moveSpeed;
	public float pauseTime;
	public int rowNumber;
	public float spaceBetweenRows;
	private Vector3 boundSize;
	private bool movingRight;
	private float MaxX;
	private float MinX;
	private bool isPaused;
	private float timeSincePause;
	// Use this for initialization
	public void Start () {
		boundSize = GetComponentInChildren<MeshRenderer>().bounds.size;
		getMinMaxX();

		movingRight = (rowNumber%2 == 0) ? true:false;
		float startXpos = movingRight ? MinX : MaxX;

		transform.position = new Vector3(
			startXpos,
			desiredHeight,
			floor.GetComponent<MeshRenderer>().bounds.min.z + boundSize.z*(0.5f + rowNumber) + rowNumber*spaceBetweenRows);
	}
	
	void getMinMaxX() {
		MaxX = floor.GetComponent<MeshRenderer>().bounds.max.x - boundSize.x/2;
		MinX = floor.GetComponent<MeshRenderer>().bounds.min.x + boundSize.x/2;
	}

	// Update is called once per frame
	void Update () {
		if (!isPaused) {
			if (movingRight) {
				movePlatformRight();
			} else {
				movePlatformLeft();
			}
		} else {
			updatePause();
		}
	}

	void movePlatformRight() {
		transform.position += new Vector3(moveSpeed*Time.deltaTime, 0);
		if (transform.position.x > MaxX) {
			isPaused = true;
			transform.position = new Vector3(MaxX, transform.position.y, transform.position.z);
			movingRight = false;
		}
	}

	void movePlatformLeft() {
		transform.position -= new Vector3(moveSpeed*Time.deltaTime, 0);
		if (transform.position.x < MinX) {
			isPaused = true;
			transform.position = new Vector3(MinX, transform.position.y, transform.position.z);
			movingRight = true;
		}
	}

	void updatePause() {
		timeSincePause += Time.deltaTime;
		if (timeSincePause > pauseTime) {
			isPaused = false;
			timeSincePause = 0;
		}
	}
}
