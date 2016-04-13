using UnityEngine;
using System.Collections;
using System;

[Flags]
public enum HUDFlags
{
	NONE = 0,
	SHOW_TOP = 1,
	SHOW_BOTTOM = 2
};

public class HUDHandler : MonoBehaviour {

	[SerializeField]GameObject Top;
	[SerializeField]GameObject Bottom;



	HUDFlags flag;


	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this);
		flag = HUDFlags.SHOW_TOP | HUDFlags.SHOW_BOTTOM;
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
		if(!HasFlag(showflag, HUDFlags.SHOW_TOP))
			ShowTop(true, animate);

//		if(HasFlag(showflag, HUDFlags.SHOW_BOTTOM))
//			ShowBottom(animate);
	
	}

	public void ShowTop(bool show, bool animate)
	{
		HUDFlags origin = flag;

		if(show)
			origin |= HUDFlags.SHOW_TOP;
		else
			origin &= ~HUDFlags.SHOW_TOP;

		Debug.Log("Origin: " + origin + " flag: " +flag); 
		if(origin != flag)
		{
			if(HasFlag(origin, HUDFlags.SHOW_TOP))
			{ 
				if(animate && Top.activeSelf)
					StartCoroutine(Utility.translatePositionEaseInOut(Top.transform, Top.transform.localPosition, Top.transform.localPosition - new Vector3(0,233,0), 0.5f, null));  
				else
				{
					Top.SetActive(true);
					Top.transform.localPosition -= new Vector3(0,233,0);
				}
			}
			else
			{	
				if(animate && Top.activeSelf)
					StartCoroutine(Utility.translatePositionEaseInOut(Top.transform, Top.transform.localPosition, Top.transform.localPosition + new Vector3(0,233,0), 0.5f, null));  
				else
				{
					Top.SetActive(false);
					Top.transform.localPosition += new Vector3(0,233,0);
				}
			}
		}

		flag = origin;
	}

	public void ToggleBottom(bool show, bool animate)
	{
		if(Bottom != null)
		{
			Bottom.SetActive(show);
		}
	}
}
