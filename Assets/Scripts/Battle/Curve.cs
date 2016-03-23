using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Curve : MonoBehaviour {
	[SerializeField]Vector3[] anchorPoints;
	[SerializeField]int slices;
	[SerializeField]BuildMode currentBuildMode;

	public enum BuildMode
	{
		Normal,
		Bumper
	}


	// Use this for initialization
	void Start () {
		currentBuildMode = BuildMode.Normal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		foreach (Vector3 point in anchorPoints)
			Gizmos.DrawSphere (transform.localPosition+ point, 3f);

		GenerateCurve ();
	}

	void GenerateCurve(){

		List<Vector3> outputList = new List<Vector3> ();
		List<Vector3> list = new List<Vector3> ();
		for (int i = 0; i < transform.childCount; ++i){
			Transform child = transform.GetChild (i);
			list.Add (child.position);
		}

		for (int count = 0; count <= slices; ++count) {
			List<Vector3> pointList = new List<Vector3> ();
			pointList.AddRange (list);
			for (int iterations = list.Count; iterations > 1; --iterations) {
				for (int i = 0; i < iterations-1; ++i) {
					pointList.Add (Vector3.Lerp (pointList [i], pointList [i + 1], (float)count/slices));
				}

				for (int i = 0; i < iterations; ++i) {
					pointList.RemoveAt (0);
				}
			}

			outputList.Add (pointList[0]);
		}
		
		Gizmos.color = Color.red;
		for (int i = 0; i < outputList.Count-1; ++i) {
			Gizmos.DrawLine (outputList[i], outputList[i+1]);
		}
	}

	void GenerateCollision()
	{
		List<Vector3> outputList = new List<Vector3> ();
		List<Vector3> list = new List<Vector3> ();
		for (int i = 0; i < transform.childCount; ++i){
			Transform child = transform.GetChild (i);
			list.Add (child.localPosition);
		}
		
		for (int count = 0; count <= slices; ++count) {
			List<Vector3> pointList = new List<Vector3> ();
			pointList.AddRange (list);
			for (int iterations = list.Count; iterations > 1; --iterations) {
				for (int i = 0; i < iterations-1; ++i) {
					pointList.Add (Vector3.Lerp (pointList [i], pointList [i + 1], (float)count / slices));
				}
				
				for (int i = 0; i < iterations; ++i) {
					pointList.RemoveAt (0);
				}
			}
			
			outputList.Add (pointList [0]);
		}
		
		for (int i = 0; i < outputList.Count-1; ++i) {
			CreateWall (transform.localPosition+outputList[i], transform.localPosition+outputList[i+1], 4);
		}

	}

	public void Test()
	{
		GenerateCollision ();
//		CreateWall (transform.localPosition+anchorPoints [0], transform.localPosition+anchorPoints [1], 4);
	}

	void CreateWall(Vector3 from, Vector3 to, int thickness){
		GameObject obj;
		if (currentBuildMode == BuildMode.Normal)
			obj = Instantiate (Resources.Load ("Prefab/Battle/OverlapWall")) as GameObject;
		else
			obj = Instantiate (Resources.Load ("Prefab/Battle/BumperWall")) as GameObject;

		obj.transform.SetParent (transform.parent);
		Vector3 vec = to - from;

		RectTransform newRect = obj.GetComponent<RectTransform> ();

		newRect.sizeDelta = new Vector2(vec.magnitude, thickness);

		float angle = Mathf.Atan2 (-vec.y, vec.x);
		float angle1 = Vector3.Angle (from, to);

		obj.transform.localRotation = Quaternion.FromToRotation (Vector3.right, vec);
		obj.transform.localPosition = (from + to) / 2;

		BoxCollider2D collider = obj.GetComponent<BoxCollider2D> ();
		collider.size = newRect.sizeDelta;
	}
}

