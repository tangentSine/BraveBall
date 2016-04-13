using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecipeListItem : MonoBehaviour 
{
	[SerializeField]Text name;
	[SerializeField]Text stats;
	[SerializeField]Text desc;
	[SerializeField]Image img;
	[SerializeField]Button btn;

	SpriteAssetList RecipeSprites;
	int ball_id;
	Town town;

	public void Init(string _name, string _stats, string _desc, int id, Town twn)
	{
		name.text = _name;
		stats.text = _stats;
		desc.text = _desc;
		town = twn;
		ball_id = id;

		RecipeSprites = Resources.Load("Data/TownAssetData") as SpriteAssetList;
		RecipeSprites.Init();

		Debug.Log("Ball_ID: " + id);

		img.sprite = RecipeSprites.SpriteMap["id_" + id];

		btn.onClick.AddListener( ()=>twn.SwitchCrafting(_name, _stats, _desc,  id));

	}

}
