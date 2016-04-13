using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeSpriteAssetList {

	[MenuItem("Assets/Create/SpriteAssetList")]
    public static void CreateMyAsset()
    {
		SpriteAssetList asset = ScriptableObject.CreateInstance<SpriteAssetList>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
