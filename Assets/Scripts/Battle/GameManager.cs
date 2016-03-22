﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField]Flipper				_flipperLeft;
	[SerializeField]Flipper				_flipperRight;
	[SerializeField]Flipper				_flipperLeftTop;
	[SerializeField]Flipper				_flipperRightTop;

	[SerializeField]GameObject			_ballObject;

	[SerializeField]GameObject			_fxLayer;

	[SerializeField]float 				_launchForce;

	[SerializeField]GameObject[]		_layerObjects;

	[SerializeField]Text				_scoreText;
	[SerializeField]Text				_enemyText;

	int 								_score;

	int 								_lastEnemyCount;

	static GameManager					_gameManager;

	static public GameManager Get()
	{
		return _gameManager;
	}

	void Awake()
	{
		if (_gameManager == null)
			_gameManager = this;
	}

	// Use this for initialization
	void Start () {
		_layerObjects [0].SetActive (true);
		_layerObjects [1].SetActive (false);
		_layerObjects [2].SetActive (false);
		
		_scoreText.text = "Score: " + _score;

		_lastEnemyCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		_enemyText.text = "Enemies Left: " + _lastEnemyCount;
	}

	// Update is called once per frame
	void Update () {
		int newCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		if (newCount != _lastEnemyCount) {
			_enemyText.text = "Enemies Left: " + newCount;
			if (newCount == 0){
				//Show battle end here
			}
		}
		_lastEnemyCount = newCount;
	
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

	public void AddScore(int score, Vector3 pos)
	{
		_score += score;
		_scoreText.text = "Score: " + _score;

		GameObject scoreObj = Instantiate (Resources.Load ("Prefab/Battle/AddScore")) as GameObject;
		scoreObj.transform.position = pos;
		scoreObj.transform.SetParent (_fxLayer.transform, false);

		ScoreFx scoreFx = scoreObj.GetComponent<ScoreFx>();
		scoreFx.Initialize (1f, score);
	}
}