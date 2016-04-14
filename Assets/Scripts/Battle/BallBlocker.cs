using UnityEngine;
using System.Collections;

public class BallBlocker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		other.rigidbody2D.AddForce (new Vector2(0,50000), ForceMode2D.Impulse);
		Destroy (gameObject);
	}
}
