using UnityEngine;
using System.Collections;

public class TweenPos : MonoBehaviour {

	enum TransitionEffect
	{
		Linear = 0,
		EaseInAndOut
	}


	[SerializeField]TransitionEffect effect;

	[SerializeField]Vector2 from;
	[SerializeField]Vector2 to;
	[SerializeField]float duration;


	public delegate void TweenCallBack();
	public TweenCallBack endOfEventCallBack;

	RectTransform rectTrans;

	// Use this for initialization
	void Awake () {
		rectTrans = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Plays the tween
	/// </summary>
	/// <param name="forward">If set to <c>true</c> forward and <c>false</c> for reverse</param>
	public void Play(bool forward)
	{

		switch(effect)
		{
			case TransitionEffect.Linear:
				if(forward)
					StartCoroutine(Utility.translateAnchoredPosLinear(rectTrans, from, to, duration, ()=>{if(endOfEventCallBack != null)endOfEventCallBack();}));
				else
					StartCoroutine(Utility.translateAnchoredPosLinear(rectTrans, to, from, duration, ()=>{if(endOfEventCallBack != null)endOfEventCallBack();}));
			break;

			case TransitionEffect.EaseInAndOut:
				if(forward)
					StartCoroutine(Utility.translateAnchoredPosEaseInAndOut(rectTrans, from, to, duration, ()=>{if(endOfEventCallBack != null)endOfEventCallBack();}));
				else
					StartCoroutine(Utility.translateAnchoredPosEaseInAndOut(rectTrans, to, from, duration, ()=>{if(endOfEventCallBack != null)endOfEventCallBack();}));
			break;
		}

	}


}
