using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadTrigger : MonoBehaviour {

	[SerializeField] string loadSceneName;
	[SerializeField] string spawnToObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject == NewPlayer.Instance.gameObject) {
			GameManager.Instance.playerUI.animator.SetTrigger ("coverScreen");
			GameManager.Instance.playerUI.loadSceneName = loadSceneName;
			GameManager.Instance.playerUI.spawnToObject = spawnToObject;
			enabled = false;
		}
	}


}
