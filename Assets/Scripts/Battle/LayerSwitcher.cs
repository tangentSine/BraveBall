using UnityEngine;
using System.Collections;

public class LayerSwitcher : MonoBehaviour {

	Vector3 startPos;

	[SerializeField]GameObject fromLayer;
	[SerializeField]GameObject toLayer;
	[SerializeField]float waitInterval;

	bool _switch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		startPos = other.transform.localPosition;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.GetChild (0).position);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Vector3 v = other.transform.localPosition - startPos;

		Vector3 myDir = transform.GetChild (0).localPosition;

		if (Vector3.Dot (v, myDir) > 0) {
			StartCoroutine(SwitchLayers(true));
//			if (fromLayer != null)
//				fromLayer.SetActive (false);
//			if (toLayer != null)
//				toLayer.SetActive (true);
		} else {
			StartCoroutine(SwitchLayers(false));
//			if (fromLayer != null)
//				fromLayer.SetActive (true);
//			if (toLayer != null)
//				toLayer.SetActive (false);
		}
	}

	public IEnumerator SwitchLayers(bool direction)
	{
		yield return new WaitForSeconds (waitInterval);
		
		if (fromLayer != null)
			fromLayer.SetActive (!direction);
		if (toLayer != null)
			toLayer.SetActive (direction);
	}
}
