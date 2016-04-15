using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {
	
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
	
	public void OnClickMistral(){
		
		_changeScene.ChangeToScene("World2");
	}

	public void OnClickVolcano(){
		
		_changeScene.ChangeToScene("BattleSetup");
	}
}
