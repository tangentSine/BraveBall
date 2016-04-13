using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreFx : MonoBehaviour {

	[SerializeField]Text scoreText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Initialize(float lifeTime, int score, bool isGold = false)
	{
		if (isGold)
			scoreText.color = Color.yellow;
		else
			scoreText.color = Color.white;
		scoreText.text = score.ToString ();
		Destroy (gameObject, lifeTime);
	}

}
