using UnityEngine;
using System.Collections;

public class ZelDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (animation.isPlaying == false)
			animation.Play ();
	
	}	

	void OnTriggerEnter2D(Collider2D other)
	{
		GameManager.Get().AddGold (1000, transform.localPosition);
		Destroy (gameObject);
	}
}
