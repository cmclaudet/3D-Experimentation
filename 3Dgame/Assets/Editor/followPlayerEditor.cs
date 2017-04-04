using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(followPlayer))]
[CanEditMultipleObjects]
public class followPlayerEditor : Editor {

    public override void OnInspectorGUI() {
      followPlayer followPlayerScript = (followPlayer)target;
      followPlayerScript.offset = EditorGUILayout.Vector3Field("offset", followPlayerScript.offset);
      EditorGUILayout.LabelField("Following Player", followPlayerScript.isFollowing.ToString());
      DrawDefaultInspector();
    }
}
