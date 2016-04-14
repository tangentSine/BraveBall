using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeBallList : MonoBehaviour {

	[MenuItem("Assets/Create/MakeBallList")]
    public static void CreateMyAsset()
    {
		BallList asset = ScriptableObject.CreateInstance<BallList>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Ball/Ball.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
