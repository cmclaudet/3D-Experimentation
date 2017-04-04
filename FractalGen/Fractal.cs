using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {
	public int maxDepth;
	private int depth;
	public float childScale;
	public float maxTwist;
	public Mesh[] meshes;
	public Material material;
	public float spawnProbability;
	private Material[,] materials;
	private Color[] possibleColors;
	private int totalColors = 3;
	private static Vector3[] directions = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back
	};
	private static Quaternion[] orientations = {
		Quaternion.identity,
		Quaternion.Euler(0, 0, -90f),
		Quaternion.Euler(0, 0, 90f),
		Quaternion.Euler(90f, 0, 0),
		Quaternion.Euler(-90f, 0, 0)
	};

	void initializeMaterial() {
		possibleColors = new Color[3] {Color.yellow, Color.blue, Color.magenta};
		materials = new Material[maxDepth + 1, totalColors];

		for (int i = 0; i <= maxDepth; i++) {
			for (int j = 0; j < totalColors; j++) {
				materials[i,j] = new Material(material);
				materials[i,j].color = Color.Lerp(Color.white, possibleColors[j], (float)i/maxDepth);
			}
		}
	}

	// Use this for initialization
	void Start () {
		if (materials == null) {
			initializeMaterial();
		}
		gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0,meshes.Length)];
		gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0, totalColors)];

		transform.Rotate(Random.Range(-maxTwist, maxTwist), 0, 0);
		if (depth < maxDepth) {
			StartCoroutine(createChild());
		}
	}

	IEnumerator createChild() {
		for (int i = 0; i < directions.Length; i++) {
			yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
			if (Random.value <= spawnProbability) {
				new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
			}
		}
	}

	void Initialize(Fractal parent, int childIndex) {
		spawnProbability = parent.spawnProbability;
		maxTwist = parent.maxTwist;
		meshes = parent.meshes;
		materials = parent.materials;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one*childScale;
		transform.localPosition = directions[childIndex]*(0.5f+0.5f*childScale);
		transform.localRotation = orientations[childIndex];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
