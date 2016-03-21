using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	protected int hp;

	protected Element element;

	protected float invincibleTime;

	public enum EnemyType
	{
		Slime,
		Skeleton,
	};

	public enum Element
	{
		Fire,
		Water,
		Thunder,
		Earth,
		Light,
		Dark
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
	
	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		TakeDamage (1);
	}

	protected virtual void TakeDamage(int dmg)
	{
		hp-= dmg;
		if (hp <= 0)
			Destroy (gameObject);
		else {
			if (collider2D != null){
				collider2D.enabled = false;
				StartCoroutine (EnableCollider(invincibleTime));
			}
		}
	}

	
	protected virtual IEnumerator EnableCollider(float time)
	{
		yield return new WaitForSeconds (time);

		if (collider2D != null){
			collider2D.enabled = true;
		}
	}
}
