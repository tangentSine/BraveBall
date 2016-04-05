using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

	int m_curScene = 0;
	[SerializeField]Animator m_anim;


	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	public void ChangeToScene(int scene)
	{
		if(scene == m_curScene)
		{
			Debug.Log("No Scene Change");
			return;
		}
		else
			m_curScene = scene;

		if(m_anim != null)
		{
			
			m_anim.Play("PanelFadeIn");
		}

		StartCoroutine(LevelLoad(scene));
		
	}
	IEnumerator LevelLoad(int scene)
	{
		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel(scene);
		if(m_anim != null)
			m_anim.Play("PanelFadeOut");
	}
}
