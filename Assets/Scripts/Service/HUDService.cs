using UnityEngine;
using System.Collections;

public class HUDService : CSingleton {

	HUDHandler	m_hudControl;

	// Use this for initialization
	void Awake () {
		GameObject obj = GameObject.Find("HUD");
		m_hudControl = obj.GetComponentInChildren<HUDHandler>();
	}

	public void ShowTop(bool animate = false)
	{
		m_hudControl.ShowTop(animate);
	}

	public void ShowBottom(bool show, bool animate = false)
	{
		m_hudControl.ShowBottom(show, animate);
	}


}
