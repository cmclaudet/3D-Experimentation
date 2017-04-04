using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(makePlatform))]
public class makePlatformEditor : Editor {

	// Use this for initialization
	public override void OnInspectorGUI() {
      makePlatform makePlatformScript = (makePlatform)target;
      DrawDefaultInspector();
	  if (GUILayout.Button("Make Platform")) {
		  makePlatformScript.createPlatform();
	  }
    }
	
	
}
