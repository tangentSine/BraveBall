using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Utility : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		

	}

	public static IEnumerator translatePositionLinear(Transform trans, Vector3 from, Vector3 to, float duration, Action CallBack)
	{

		float timeElapsed = Time.time;
		while(timeElapsed < duration)
		{
	
			timeElapsed += Time.deltaTime;
			float frac = timeElapsed/duration;

			trans.localPosition = Vector3.Lerp(from, to, frac);
			yield return new WaitForEndOfFrame();
		}

		trans.localPosition = to;
		CallBack();
	}

	public static IEnumerator translatePositionEaseInOut(Transform trans, Vector3 from, Vector3 to, float duration, Action CallBack)
	{
		float time = 0.0f;
		while(time <= 1.0f)
		{
			time += Time.deltaTime/duration;

			trans.localPosition = Vector3.Lerp(from, to, Mathf.SmoothStep(0.0f, 1.0f, time));
			yield return new WaitForEndOfFrame();
		}

		trans.localPosition = to;
		CallBack();
	}


	public static IEnumerator translateAnchoredPosLinear(RectTransform trans, Vector2 from, Vector2 to, float duration, Action CallBack)
	{

		float timeElapsed = Time.time;
		while(timeElapsed < duration)
		{
	
			timeElapsed += Time.deltaTime;
			float frac = timeElapsed/duration;

			trans.localPosition = Vector2.Lerp(from, to, frac);
			yield return new WaitForEndOfFrame();
		}

		trans.anchoredPosition = to;
		CallBack();
	}


	public static IEnumerator translateAnchoredPosEaseInAndOut(RectTransform trans, Vector2 from, Vector2 to, float duration, Action CallBack)
	{
		float time = 0.0f;
		while(time <= 1.0f)
		{
			time += Time.deltaTime/duration;

			trans.anchoredPosition = Vector2.Lerp(from, to, Mathf.SmoothStep(0.0f, 1.0f, time));
			yield return new WaitForEndOfFrame();
		}

		trans.anchoredPosition = to;
		CallBack();
	}

}
