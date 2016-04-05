using UnityEngine;
using System.Collections;

public class HomeMenu : MonoBehaviour {

	HUDService m_HUD;
	// Use this for initialization
	void Start () {

		Service.Init();
		m_HUD = Service.Get<HUDService>();
//		StartCoroutine(Test());
	}

//	IEnumerator Test()
//	{
//		bool flag = false;
//		while(true)
//		{
//			m_HUD.ShowTop(true);
//			yield return new WaitForSeconds(1.0f);
//		}
//	}
	// Update is called once per frame
	void Update () {
	
	}
}
