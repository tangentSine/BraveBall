using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteAssetList : ScriptableObject {

	public List<Sprite> spriteList;
	public List<string> sprite_id;

	private Dictionary<string, Sprite> map;

	public Dictionary<string, Sprite> SpriteMap
	{
		get{ return map;}
	}

	public void Init()
	{
		map = new Dictionary<string, Sprite>();

		foreach(string id in sprite_id)
		{
			Debug.Log("ID: " + id);
			foreach(Sprite spr in spriteList)
			{
				Debug.Log("spr: " + spr);
				map.Add(id, spr);
			}
		}
	}

}
