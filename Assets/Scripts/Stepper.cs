using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stepper : MonoBehaviour {

	[SerializeField] enum GroundType {Grass, Stone};
	[SerializeField] GroundType groundType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.GetComponent<NewPlayer> () != null) {
			NewPlayer.Instance.groundType = groundType.ToString ();
			NewPlayer.Instance.SetGroundType ();
		}else if(col.gameObject.GetComponent<EnemyBase> () != null){
			col.gameObject.GetComponent<EnemyBase>().groundType = groundType.ToString ();
			col.gameObject.GetComponent<EnemyBase>().SetGroundType ();
		}
	}

	void OnCollisionEnter2D(Collision2D col){

	}

}
