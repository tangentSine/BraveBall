using UnityEngine;
using System.Collections;
using System;

public class HUDHandler : MonoBehaviour {

	[SerializeField]GameObject Top;
	[SerializeField]GameObject Bottom;

	[Flags]
	public enum HUDFlags
	{
		NONE = 0,
		SHOW_TOP = 1,
		SHOW_BOTTOM = 2
	};

	HUDFlags flag;


	// Use this for initialization
	void Awake () {
		flag = HUDFlags.SHOW_TOP | HUDFlags.SHOW_TOP;
	}

	bool HasFlag(HUDFlags left, HUDFlags right)
	{
		return (left & right) == left;
	}

	/// <summary>
	/// Method to allow multiple HUD to be configured as per HUDFlags 
	/// </summary>
	/// <param name="showflag">Showflag.</param>
	/// <param name="animate">If set to <c>true</c> animate.</param>
	public void Show(HUDFlags showflag, bool animate)
	{
		if(HasFlag(showflag, HUDFlags.SHOW_TOP))
			ShowTop(animate);

//		if(HasFlag(showflag, HUDFlags.SHOW_BOTTOM))
//			ShowBottom(animate);
	
	}

	public void ShowTop(bool animate)
	{
		HUDFlags origin = flag;
		origin |= HUDFlags.SHOW_TOP;


		Debug.Log("Flag: " + flag + " origin: " + origin);
		if(origin != flag)
		{
			if(HasFlag(origin, HUDFlags.SHOW_TOP))
			{ 
				if(animate && Top.activeSelf)
					StartCoroutine(Utility.translatePositionEaseInOut(Top.transform, Top.transform.localPosition, Top.transform.localPosition - new Vector3(0,233,0), 0.5f));  
				else
					Top.SetActive(true);
			}
			else
			{	
				if(animate && Top.activeSelf)
					StartCoroutine(Utility.translatePositionEaseInOut(Top.transform, Top.transform.localPosition, Top.transform.localPosition + new Vector3(0,233,0), 0.5f));  
				else
					Top.SetActive(false);
			}
		}

		flag = origin;
	}

	public void ShowBottom(bool show, bool animate)
	{
		if(Bottom != null)
		{
			Bottom.SetActive(show);
		}
	}
}
