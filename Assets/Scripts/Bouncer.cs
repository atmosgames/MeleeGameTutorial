using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {
	[SerializeField] private AudioClip bounceSound;
	[SerializeField] private AudioSource audioSource;
	public bool launchOnStart;
	[SerializeField] private BoxCollider2D collectableTrigger;
	private Rigidbody2D rb;
	private float launchCounter ;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
		if (launchOnStart) {
			Launch (new Vector2 (300, 300));
			collectableTrigger.enabled = false;
		} else {
			rb.isKinematic = true;
			GetComponent<Collider2D> ().enabled = false;
			collectableTrigger.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (collectableTrigger != null && launchCounter > 1) {
			collectableTrigger.enabled = true;
		} else if(collectableTrigger != null ){
			launchCounter += Time.deltaTime;
		}
	}

	// called when the cube hits the floor
	void OnCollisionEnter2D(Collision2D col)
	{
		if(launchOnStart && collectableTrigger.enabled){
			audioSource.PlayOneShot (bounceSound, rb.velocity.magnitude/10*audioSource.volume);
		}
	}

	public void Launch(Vector2 launchPower){
		rb.AddForce(new Vector2 (launchPower.x*Random.Range(-1f,1f), launchPower.y*Random.Range(1f,1.5f)));
	}

}
