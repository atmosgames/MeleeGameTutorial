using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

	[SerializeField] private GameObject deathParticles;
	[SerializeField] private Animator animator;
	[SerializeField] private int health;
	[SerializeField] private float recoveryCounter;
	[SerializeField] private float recoveryTime;
	[SerializeField] private Instantiator instantiator;

	private bool recovered;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject == NewPlayer.Instance.attackHit.gameObject) {
			Hit ();
			Debug.Log ("HIT ATTACK HIT!");
		}
	}
		
	public void Hit(){
		NewPlayer.Instance.cameraEffect.Shake (300, 1);
		health -= 1;
		animator.SetTrigger ("hit");
		if (health <= 0) {
			Die ();
		}
	}

	public void Die(){
		deathParticles.SetActive (true);
		deathParticles.transform.parent = transform.parent;
		if (instantiator != null) {
			instantiator.InstantiateObjects ();
		}
		Destroy (gameObject);
	}
}
