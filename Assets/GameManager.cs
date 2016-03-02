using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[SerializeField]Flipper				_flipperLeft;
	[SerializeField]Flipper				_flipperRight;

	[SerializeField]GameObject			_ballObject;

	[SerializeField]float 				_launchForce;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void OnLeftFlipperDown()
	{
		_flipperLeft.Swing ();
	}

	public void OnLeftFlipperUp()
	{
		_flipperLeft.SwingBack ();
	}

	public void OnRightFlipperDown()
	{
		_flipperRight.Swing ();
	}

	public void OnRightFlipperUp()
	{
		_flipperRight.SwingBack ();
	}

	public void OnSpringUp()
	{
		_ballObject.rigidbody2D.AddForce (new Vector2(0,_launchForce), ForceMode2D.Impulse);
		Debug.Log ("Launching");
	}
}
