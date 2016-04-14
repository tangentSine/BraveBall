using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// For Testing Only

public class Recipe : MonoBehaviour {

	public struct MaterialsRequired
	{
		public int amt;
		public daItem item;

		public MaterialsRequired(int _amt)
		{
			amt = _amt;
			item = new daItem();
		}
	};
	[SerializeField]Text name;
	[SerializeField]Text stats;
	[SerializeField]Text desc;
	[SerializeField]Image img;

	SpriteAssetList RecipeSprites;
	List<MaterialsRequired> requirement;


	int id;
	PlayerService player;

	void Awake()
	{
		player = Service.Get<PlayerService>();
	}

	public void Init(string _name, string _stats, string _desc, int _id)
	{
		name.text = _name;
		stats.text = _stats;
		desc.text = _desc;
		RecipeSprites = Resources.Load("Data/TownAssetData") as SpriteAssetList;
		RecipeSprites.Init();
		id = _id;
		img.sprite = RecipeSprites.SpriteMap["id_" + id];

		// HACK
		requirement = new List<MaterialsRequired>();
		MaterialsRequired grass = new MaterialsRequired(3);
		grass.item.name = "grass";
		grass.item.item_id = 50;
		grass.item.type = 1;
		grass.item.skill_id = 0;

		requirement.Add(grass);

		CreateMaterialRequired();
	}

	void CreateMaterialRequired()
	{
		foreach(MaterialsRequired item in requirement)
		{
			GameObject obj = Instantiate(Resources.Load("Prefab/Town/ItemsRequired")) as GameObject;
			obj.transform.SetParent(this.transform, false);
			RectTransform trans = GetComponent<RectTransform>();
			Vector2 vec = new Vector2(trans.anchoredPosition.x, trans.anchoredPosition.y + 30);
			trans.anchoredPosition = vec;
			MaterialRequired mat = obj.GetComponent<MaterialRequired>();
			mat.Init(item.item.name, item.amt.ToString(), "10");
		}
	}

	public void Craft()
	{
		// Reduce Player materials
		player.AddBall(id);
	}

}
