using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimatorSpeed : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		animator.speed = Random.Range(.3f,1.5f);
	}
}
