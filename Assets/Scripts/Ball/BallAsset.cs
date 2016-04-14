using UnityEngine;
using System.Collections;

[System.Serializable]
public class BallAsset
{
	public string name = "New Ball";
	public int ball_id = 0;
	public Sprite icon = null;
	public Rigidbody2D rigidbody = new Rigidbody2D();
	public CircleCollider2D collider = null;
}
