using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour {

	private  AudioSource audioSource;
	[SerializeField] private  float fadeSpeed;
	[SerializeField] private  float volume;
	[SerializeField] private  AudioClip sound;
	[SerializeField] private bool loop;
	[SerializeField] private bool autoPlay;

	private bool start;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = 0f;
		audioSource.clip = sound;
	}
	
	// Update is called once per frame
	void Update () {
		audioSource.loop = loop;

		if (start || autoPlay) {
			if (audioSource.volume < volume) {
				if (!audioSource.isPlaying) {
					audioSource.Play ();
				}
				audioSource.volume += fadeSpeed * Time.deltaTime;
			}
		} else {
			if (audioSource.volume > 0) {
				audioSource.volume -= fadeSpeed * Time.deltaTime;
			} else {
				audioSource.Stop ();
			}
		}
	}	

	void OnTriggerEnter2D(Collider2D col)
	{
		start = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		start = false;
	}


}
