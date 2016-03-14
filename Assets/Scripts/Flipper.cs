using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	[SerializeField]float 					swingAngle;
	[SerializeField]float					normalAngle;

	private	bool							isSwinging;
	private float							counter = 0;

	float outAngle;
	float inAngle;

	// Use this for initialization
	void Start () {
		isSwinging = false;
		outAngle = rigidbody2D.rotation + swingAngle;
		inAngle = rigidbody2D.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float def = swingAngle - normalAngle;
		if (isSwinging) {
			rigidbody2D.MoveRotation (outAngle);
		} else {
			rigidbody2D.MoveRotation(inAngle);
		}
//		float min = Mathf.Min (rigidbody2D.rotation+swingAngle, rigidbody2D.rotation+normalAngle);
//		float max = Mathf.Max (rigidbody2D.rotation+swingAngle, rigidbody2D.rotation+normalAngle);
//		rigidbody2D.rotation = Mathf.Clamp (rigidbody2D.rotation, min, max);
		//isSwinging = false;
	
//		counter += Time.deltaTime;
//		if (counter >= 0.25f)
//			isSwinging = false;
	}

	public void Swing()
	{
		isSwinging = true;
		Debug.Log ("Swing l");
	}

	public void SwingBack()
	{
		isSwinging = false;
		Debug.Log ("Swing back");
	}
}
