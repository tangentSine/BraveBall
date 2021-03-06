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
	[SerializeField]Text				_zelText;
	[SerializeField]Text				_enemyText;

	[SerializeField]GameObject			_buttonItemClose;
	[SerializeField]GameObject			_buttonItemOpen;
	[SerializeField]TweenPos			_itemTween;
	[SerializeField]Text				_itemAmtText;

	[SerializeField]ZelSpawner[]		_scoreZelSpawners;
	[SerializeField]int[]				_scoresForZel;

	int 								_scoreLv;

	[SerializeField]ChangeScene			_changeScene;

	int 								_score;
	int									_zel;

	int 								_lastEnemyCount;

	int 								_itemCount;

	bool								_isPaused;

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
		ResetLayers ();

		_score = _zel = _scoreLv = 0;

		_scoreText.text = _score.ToString();
		_zelText.text = _zel.ToString ();

		_lastEnemyCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		Service.Get<HUDService> ().ShowTop (false);
		Service.Get<HUDService> ().ShowBottom (false);

		_buttonItemClose.SetActive (false);

		_itemCount = 99;
		_itemAmtText.text = "x" + _itemCount;

		_isPaused = false;
	}

	// Update is called once per frame
	void Update () {
		int newCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		if (newCount != _lastEnemyCount) {
//			_enemyText.text = "Enemies Left: " + newCount;
			if (newCount == 0){
				ResultScene.SetTargetValues(_score, _zel, 20000, 2);
				_changeScene.ChangeToScene("Result");
				//Show battle end here
			}
		}

		if (_scoreLv < _scoresForZel.Length && _score > _scoresForZel [_scoreLv]) {
			_scoreZelSpawners[_scoreLv].CreateZel ();
			_scoreLv++;
		}
		_lastEnemyCount = newCount;
	
	}

	void Pause(bool pause)
	{
		Time.timeScale = pause ? 0 : 1f;
		_isPaused = pause;
	}

	public void OnLeftFlipperDown()
	{
		_flipperLeft.Swing ();
//		_flipperLeftTop.Swing ();
	}

	public void OnLeftFlipperUp()
	{
		_flipperLeft.SwingBack ();
//		_flipperLeftTop.SwingBack ();
	}

	public void OnRightFlipperDown()
	{
		_flipperRight.Swing ();
//		_flipperRightTop.Swing ();
	}

	public void OnRightFlipperUp()
	{
		_flipperRight.SwingBack ();
//		_flipperRightTop.SwingBack ();
	}

	public void OnSpringUp()
	{
		_ballObject.rigidbody2D.AddForce (new Vector2(0,_launchForce), ForceMode2D.Impulse);
		Debug.Log ("Launching");
	}

	public void OnItemOpen()
	{
		_buttonItemClose.SetActive (true);
		_buttonItemOpen.SetActive (false);

		_itemTween.Play (true);
		Pause (true);
	}

	public void OnItemClose()
	{
		_buttonItemClose.SetActive (false);
		_buttonItemOpen.SetActive (true);

		_itemTween.Play (false);
		Pause (false);
	}

	public void OnItemUse()
	{
		_itemAmtText.text = "x" + --_itemCount;
		
		GameObject obj = Instantiate (Resources.Load ("Prefab/Battle/BallBlocker")) as GameObject;
		obj.transform.SetParent (_fxLayer.transform);
		obj.transform.localPosition = new Vector3 (0, -340);
		//Create wall here
	}

	public void OnPause()
	{
		Pause (!_isPaused);
	}

	public void AddScore(int score, Vector3 pos)
	{
		_score += score;
		_scoreText.text = _score.ToString ();

		GameObject scoreObj = Instantiate (Resources.Load ("Prefab/Battle/AddScore")) as GameObject;
		scoreObj.transform.localPosition = pos;
		scoreObj.transform.SetParent (_fxLayer.transform, false);

		ScoreFx scoreFx = scoreObj.GetComponent<ScoreFx>();
		scoreFx.Initialize (1f, score);
	}

	public void AddGold(int gold, Vector3 pos)
	{
		_zel += gold;
		_zelText.text = _zel.ToString ();
		
		GameObject scoreObj = Instantiate (Resources.Load ("Prefab/Battle/AddScore")) as GameObject;
		scoreObj.transform.localPosition = pos;
		scoreObj.transform.SetParent (_fxLayer.transform, false);
		
		ScoreFx scoreFx = scoreObj.GetComponent<ScoreFx>();
		scoreFx.Initialize (1f, gold, true);
	}

	void ResetLayers()
	{
		foreach (GameObject obj in _layerObjects)
			obj.SetActive (false);
		_layerObjects [0].SetActive (true);
//		_layerObjects [1].SetActive (false);
//		_layerObjects [2].SetActive (false);
	}
}
