using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour {

	[SerializeField] enum AttacksWhat {EnemyBase, NewPlayer};
	[SerializeField] AttacksWhat attacksWhat;
	private int launchDirection = 1;
	[SerializeField] private GameObject parent;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.GetComponent(attacksWhat.ToString()) != null) {
			if (parent.transform.position.x < col.transform.position.x) {
				launchDirection = 1;
			} else {
				launchDirection = -1;
			}
			col.gameObject.GetComponent(attacksWhat.ToString()).SendMessage("Hit", launchDirection);
		}

	}
}
