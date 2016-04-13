using UnityEngine;
using System.Collections;

public class BumperWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Vector3 pos = gameObject.transform.localPosition;
		Transform transform = gameObject.transform.parent;

		while (transform.GetComponent<Canvas>() == null) {
			pos += transform.localPosition;
			transform = transform.parent;
		}

		GameManager.Get().AddScore (3000, pos);
	}
}
