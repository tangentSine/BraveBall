using UnityEngine;
using System.Collections;

public class Town : MonoBehaviour {

	HUDService m_HUD;

	[SerializeField]TweenPos header;
	[SerializeField]Transform m_CanvasParent;

	TweenPos list;
	TweenPos Recipe;

	void Awake()
	{
		m_HUD = Service.Get<HUDService>();
	}
	void Start()
	{
		//m_HUD.Show(HUDFlags.SHOW_TOP | HUDFlags.SHOW_BOTTOM , true);
		//m_HUD.ShowTop(false, false);
		// Do not Show Top HUD
	}
	#region Button CallBacks
	public void ShowCrafting()
	{
		GameObject obj = Instantiate(Resources.Load("Prefab/Town/List")) as GameObject;
		if(obj != null)
		{
			obj.transform.SetParent(m_CanvasParent, false);
			list = obj.GetComponent<TweenPos>();
			if(list != null)
				list.Play(true);
		}
		
		if(header != null)
			header.Play(true);

	}

	public void CloseCrafting()
	{
		if(header != null)
		{
			header.Play(false);
		}

		if(Recipe != null)
			return;

		if(list != null)
		{
			list.Play(false);
			list.endOfEventCallBack = OnCloseCrafting;
		}
		
	}

	public void SwitchCrafting(string name, string stats, string desc, int id)
	{
		if(header != null)
		{
			header.Play(false);
		}

		if(list != null)
		{
			list.Play(false);
			list.endOfEventCallBack = OnSwitchToRecipe;
		}

		GameObject obj = Instantiate(Resources.Load("Prefab/Town/RecipePage")) as GameObject;
		if(obj != null)
		{
			obj.transform.SetParent(m_CanvasParent, false);
			obj.GetComponent<Recipe>().Init(name, stats, desc, id);
			Recipe = obj.GetComponent<TweenPos>();
			
		}

	}
	#endregion

	#region EventCallBacks
	void OnCloseCrafting()
	{
		if(list != null)
		{
			Destroy(list.gameObject);
			list = null;
		}
		if(Recipe != null)
		{
			Destroy(Recipe.gameObject);
			Recipe = null;
		}
	}

	void OnSwitchToRecipe()
	{
		OnCloseCrafting();
		if(header != null)
		{
			header.Play(true); 
		}

		if(Recipe != null)
		{
			Recipe.Play(true);
		}


	}
	#endregion
}
