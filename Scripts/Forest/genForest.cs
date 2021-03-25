using UnityEngine;
using System.Collections;

public class genForest : MonoBehaviour {

	public Color treeColor = Color.black;
	public Color groundColor = Color.gray;
	public float minDistance = 30.0f;
	public float size = 300.0f;
	public int numTrees = 100;
	private GameObject ground;
	Collider[] neighbors;

	Vector3 FindNewPos(){
		Vector3 position = new Vector3 (300, 150, 300);
		do {
			// draw a new position
			position = new Vector3 (Random.Range (-size, size), 150.0f, Random.Range (-size, size));
			//Vector3 position = Vector3(10,10,10);
			// get neighbours inside minDistance:
			neighbors = Physics.OverlapSphere (position, minDistance);
			// if there's any neighbour inside range, repeat the loop:
		} while(neighbors.Length > 0);
			return position; // otherwise return the new position
	}
	
	// Update is called once per frame
	void Start () {
		for (int a = 0; a < numTrees; a++) {
			Vector3 newPos = FindNewPos ();
			float diam = Random.Range (5,minDistance-2);
			GameObject cylinder = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			cylinder.transform.localScale += new Vector3(diam, 150.0f, diam);
			cylinder.transform.position = newPos;
			cylinder.AddComponent<Rigidbody>();

			//Change the color of the trees
			cylinder.GetComponent<MeshRenderer>().material.SetColor("_Color", treeColor);
			//Turn off shadows
			cylinder.GetComponent<Renderer>().shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.Off;
		}
		
		//Change the color of the ground
		ground = GameObject.Find ("Plane");
		ground.GetComponent<MeshRenderer>().material.SetColor("_Color", groundColor);
		//TODO: Store locations and diameters of trees for recreation/stats
	}
}
