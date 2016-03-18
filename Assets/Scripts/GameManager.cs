using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[SerializeField]Flipper				_flipperLeft;
	[SerializeField]Flipper				_flipperRight;
	[SerializeField]Flipper				_flipperLeftTop;
	[SerializeField]Flipper				_flipperRightTop;

	[SerializeField]GameObject			_ballObject;

	[SerializeField]float 				_launchForce;

	[SerializeField]GameObject[]		_layerObjects;

	// Use this for initialization
	void Start () {
		_layerObjects [0].SetActive (true);
		_layerObjects [1].SetActive (false);
		_layerObjects [2].SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void OnLeftFlipperDown()
	{
		_flipperLeft.Swing ();
		_flipperLeftTop.Swing ();
	}

	public void OnLeftFlipperUp()
	{
		_flipperLeft.SwingBack ();
		_flipperLeftTop.SwingBack ();
	}

	public void OnRightFlipperDown()
	{
		_flipperRight.Swing ();
		_flipperRightTop.Swing ();
	}

	public void OnRightFlipperUp()
	{
		_flipperRight.SwingBack ();
		_flipperRightTop.SwingBack ();
	}

	public void OnSpringUp()
	{
		_ballObject.rigidbody2D.AddForce (new Vector2(0,_launchForce), ForceMode2D.Impulse);
		Debug.Log ("Launching");
	}
}
