using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StaticEnemy : Enemy {

	[SerializeField]RawImage image;
	[SerializeField]EnemyType enemyType;

	bool isDefault = true;
	bool isPlayingAnimation;

	void Start () {
	
		isPlayingAnimation = false;
		if (isDefault)
			Initialize (enemyType);
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayingAnimation == true && animation.isPlaying == false) {
			ZelSpawner.CreateZelAt(new Vector3[]{transform.localPosition});
			Destroy (gameObject);
		}
	}

	public void Initialize(EnemyType enemyType)
	{
		if (enemyType == EnemyType.Skeleton) {
			image.texture = Resources.Load ("Textures/skeleton") as Texture;
			hp = 3;
			invincibleTime = 2f;
		} else if (enemyType == EnemyType.Bozdell) {
			image.texture = Resources.Load ("Textures/Unit_ills_full_10262") as Texture;
			hp = 3;
			invincibleTime = 2f;
		}
		isDefault = false;
	}

	protected override void TakeDamage(int dmg){
		Debug.Log ("Take dmg: " + dmg); 
		base.TakeDamage (dmg);
		image.color = Color.red;
	}

	protected override IEnumerator EnableCollider(float time)
	{
		yield return new WaitForSeconds (time);
		StartCoroutine (base.EnableCollider (0));
		image.color = Color.white;
	}

	protected override void OnDestroyed(){
		animation.Play ();
			isPlayingAnimation = true;
	}
}

