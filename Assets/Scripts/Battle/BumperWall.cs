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
		Debug.Log ("Bump");
		other.rigidbody2D.AddForce (transform.up*35000f, ForceMode2D.Impulse);
	}
}
