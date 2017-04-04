using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePlatform : MonoBehaviour {
	public int rowNumber;
	[HideInInspector]
	public GameObject platformPrefab;
	[HideInInspector]
	public GameObject floor;
	private GameObject newPlatform;
	
	public void createPlatform() {
		newPlatform = Instantiate(platformPrefab);
		newPlatform.GetComponent<movePlatform>().rowNumber = rowNumber;
		newPlatform.GetComponent<movePlatform>().floor = floor;
		newPlatform.GetComponent<movePlatform>().Start();
	}
}
