using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour {


	[SerializeField] private AudioClip[] sounds;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private ParticleSystem particleSystem1;
	[SerializeField] private int particleSystem1Amount;

	// Use this for initialization
	void Start () {
		if (audioSource == null) {
			audioSource = NewPlayer.Instance.audioSource;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UnfreezePlayer(){
		NewPlayer.Instance.Freeze (false);
	}

	void PlaySound(AudioClip whichSound){
		GameManager.Instance.audioSource.PlayOneShot(whichSound);
	}

	public void EmitParticles1(){
		particleSystem1.Emit (particleSystem1Amount);
	}

	public void ScreenShake(float power){
		NewPlayer.Instance.cameraEffect.Shake (power, 1f);
	}
		
}
