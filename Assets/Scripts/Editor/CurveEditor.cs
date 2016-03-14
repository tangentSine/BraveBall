using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Curve))]
public class CurveEditor : Editor {

	public override void OnInspectorGUI () {
		DrawDefaultInspector();
		Curve curve = (Curve)target;

		if (GUILayout.Button("Create curve collision")){
			curve.Test ();
		}
	}
}