using UnityEngine;
using System.Collections;

public class ScoreAdder : MonoBehaviour {

	
	Vector3 startPos;
	
	[SerializeField]int scoreToAdd;
	
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
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, transform.GetChild (0).position);
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		Vector3 v = other.transform.localPosition - startPos;
		
		Vector3 myDir = transform.GetChild (0).localPosition;
		
		if (Vector3.Dot (v, myDir) > 0) {
			GameManager.Get().AddScore (scoreToAdd, transform.localPosition);
		} 
	}

}
