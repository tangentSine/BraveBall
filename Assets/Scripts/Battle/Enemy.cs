using UnityEngine;
using System.Collections;

public enum Element
{
	Fire,
	Water,
	Thunder,
	Earth,
	Light,
	Dark
};
public class Enemy : MonoBehaviour {

	protected int hp;

	protected Element element;

	protected float invincibleTime;

	[SerializeField]int layer;

	public enum EnemyType
	{
		Slime,
		Skeleton,
		Bozdell,
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
		Ball ball = other.GetComponent<Ball> ();
		if (ball != null && ball.layer == layer)
			TakeDamage (ball.damage);
	}

	protected virtual void TakeDamage(int dmg)
	{
		hp-= dmg;
		if (hp <= 0)
			OnDestroyed ();
		else {
			if (collider2D != null){
				collider2D.enabled = false;
				StartCoroutine (EnableCollider(invincibleTime));
			}
		}
	}

	protected virtual void OnDestroyed()
	{
		Destroy (gameObject);
	}
	
	protected virtual IEnumerator EnableCollider(float time)
	{
		yield return new WaitForSeconds (time);

		if (collider2D != null){
			collider2D.enabled = true;
		}
	}
}
