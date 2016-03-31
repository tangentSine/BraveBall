using UnityEngine;
using System.Collections;

public class BallCatcher : MonoBehaviour {

	// Use this for initialization
	[SerializeField]Vector3 resetPos;
	[SerializeField]GameObject sceneObject;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		other.transform.localPosition = resetPos;
		sceneObject.SendMessage ("ResetLayers");
	}
}
