using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalSound : MonoBehaviour {

	[SerializeField] AudioSource audioSource;
	[SerializeField] float range;
	[SerializeField] float normalizedDistance;
	[SerializeField] float volume;

	// Use this for initialization
	void Start () {
		if (audioSource == null) {
			audioSource = GetComponent<AudioSource> ();
		}
	}

	void OnDrawGizmosSelected()
	{
		// Draw a yellow sphere at the transform's position
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, range);
	}
	
	// Update is called once per frame
	void Update () {
		normalizedDistance = range/(Mathf.Abs(NewPlayer.Instance.transform.position.x - transform.position.x));
		if(normalizedDistance <= 1){
			audioSource.volume = normalizedDistance;
		}
	}
}
