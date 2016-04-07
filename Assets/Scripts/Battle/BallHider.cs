using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallHider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		other.GetComponent<Image> ().enabled = false;
	}

	
	void OnTriggerExit2D(Collider2D other)
	{
		other.GetComponent<Image> ().enabled = true;
	}
}
