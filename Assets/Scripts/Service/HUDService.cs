using UnityEngine;
using System.Collections;

public class HUDService : CSingleton {

	HUDHandler	m_hudControl;

	// Use this for initialization
	void Awake () {
		GameObject obj = GameObject.Find("HUD");
		if(obj != null)
			m_hudControl = obj.GetComponentInChildren<HUDHandler>();
		else{
			obj = GameObject.Instantiate(Resources.Load ("Prefab/Menu/HUD")) as GameObject;
			m_hudControl = obj.GetComponentInChildren<HUDHandler>();
		}
	}

	public void ShowTop(bool show, bool animate = false)
	{
		m_hudControl.ShowTop(show, animate);
	}

	public void ShowBottom(bool show, bool animate = false)
	{
		m_hudControl.ToggleBottom(show, animate);
	}



}
