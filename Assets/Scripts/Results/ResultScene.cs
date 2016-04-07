using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour {
	
	[SerializeField]Text 					scoreText;
	[SerializeField]Text					zelText;
	[SerializeField]Text					timeText;

	[SerializeField]Image					starsImage;

	[SerializeField]float					animationTime;

	static int targetScoreValue;
	static int targetZelValue;
	static int targetTimeValue;

	static int objectivesCount;

	int currentScoreValue;
	int currentZelValue;
	int currentTimeValue;

	float time;

	int objectives;

	// Use this for initialization
	void Start () {
//		SetTargetValues (20000, 10000, 30000, 2);

		time = 0;

//		Vector3 scale = starsImage.transform.localScale;
//		scale.x = starsImage.sprite.bounds.size.x * objectivesCount;
//		Rect rect = starsImage.rectTransform.rect;
		float width = 52 * objectivesCount;
		starsImage.rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, width);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = string.Format("{0:n0}", currentScoreValue);
		zelText.text = string.Format("{0:n0}", currentZelValue);
		timeText.text = string.Format("{0:n0}", currentTimeValue);


		time += Time.deltaTime;
		currentScoreValue = System.Convert.ToInt32(Mathf.Lerp (0, targetScoreValue, time/animationTime));
		currentZelValue = System.Convert.ToInt32(Mathf.Lerp (0, targetZelValue, time/animationTime));
		currentTimeValue = System.Convert.ToInt32(Mathf.Lerp (0, targetTimeValue, time/animationTime));
	
	}

	static public void SetTargetValues(int score, int zel, int time, int objectivesCleared){
		targetScoreValue = score;
		targetZelValue = zel;
		targetTimeValue = time;

		objectivesCount = objectivesCleared;
	}
}
