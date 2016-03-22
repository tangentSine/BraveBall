using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public int layer;
	public int damage;

	public Element element;

	// Use this for initialization
	void Start () {
		layer = 0;
		damage = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
