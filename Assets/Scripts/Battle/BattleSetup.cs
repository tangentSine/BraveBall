using UnityEngine;
using System.Collections;

public class BattleSetup : MonoBehaviour {
	
	[SerializeField]ChangeScene			_changeScene;
	// Use this for initialization
	void Start () {
		
		Service.Init();
		Service.Get<HUDService> ().ShowTop (true);
		Service.Get<HUDService> ().ShowBottom (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnQuestStart(){
		
		_changeScene.ChangeToScene("BFBallV3");
	}
}
