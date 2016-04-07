using UnityEngine;
using System.Collections;

public class ZelSpawner : MonoBehaviour {

	public Vector3[] zelLocations;

	public float interval = 0;

	float elapsed = 0;


	int index;
	bool isCreating;
	// Use this for initialization
	void Start () {
	
//		CreateZel ();
	}

	public void Initialize(Vector3[] locations){
		locations.CopyTo (zelLocations, 0);
	}

	void OnDrawGizmos() {
		if (zelLocations.Length <= 0)
			return;
		Gizmos.color = Color.yellow;

		foreach (Vector3 pos in zelLocations)
			Gizmos.DrawSphere (transform.position+pos, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
		elapsed += Time.deltaTime;
		if (isCreating && elapsed > interval) {
			elapsed = 0;
			GameObject obj = Instantiate (Resources.Load ("Prefab/Battle/ZelDrop")) as GameObject;
			obj.transform.SetParent(transform.parent);
			obj.transform.localPosition = zelLocations[index++] + transform.localPosition;

			if (index >= zelLocations.Length){
				isCreating = false;
				Destroy(gameObject);
			}
		}
	}

	public void CreateZel()
	{
		isCreating = true;
		index = 0;
	}

	static public void CreateZelAt(Vector3[] locs){
		foreach (Vector3 pos in locs) {
			GameObject obj = Instantiate (Resources.Load ("Prefab/Battle/ZelDrop")) as GameObject;
			obj.transform.localPosition = pos;
		}
	}
}
