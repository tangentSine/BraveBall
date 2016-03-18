using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int hp;

	public enum EnemyType
	{
		Slime,
		Skeleton,
	};


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Initialize()
	{

	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		TakeDamage (1);
	}

	protected virtual void TakeDamage(int dmg)
	{
		hp-= dmg;
		if (hp <= 0)
			Destroy (gameObject);
	}
}
