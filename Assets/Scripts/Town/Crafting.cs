using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Crafting : MonoBehaviour {

	public struct CBallDisplay
	{
		public string name;
		public string stats;
		public string desc;
		public int ball_id;

		public CBallDisplay(string _name,  string _stats, string _desc, int _id)
		{
			name = _name;
			stats = _stats;
			desc = _desc;
			ball_id = _id;
		}
	};

	public Transform m_Grid;

	Town m_town;

	List<CBallDisplay> m_displayList;

	void Awake()
	{
		m_displayList = new List<CBallDisplay>();
		m_displayList.Add(new CBallDisplay("Vargas", "Fire DMG +1", "More damage to Earth Enemies", 1));
		m_town = GameObject.Find("Town").GetComponent<Town>();

		foreach(CBallDisplay disp in m_displayList)
		{
			// Create 
			GameObject obj = Instantiate(Resources.Load("Prefab/Town/Recipe")) as GameObject;
			obj.transform.SetParent(m_Grid, false);
			obj.GetComponent<RecipeListItem>().Init(disp.name, disp.stats, disp.desc, disp.ball_id, m_town);
		}




	}

}
