using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MaterialRequired : MonoBehaviour {

	[SerializeField]Text material;
	[SerializeField]Text used;
	[SerializeField]Text owned;

	public void Init(string mat, string use, string own)
	{
		material.text = mat;
		used.text = use;
		owned.text = own;
	}
}
