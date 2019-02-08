using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	PolygonCollider2D collider;

	// Use this for initialization
	void Start () {
		collider = GetComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (NewPlayer.Instance.ground.collider != null && NewPlayer.Instance.ground.collider.gameObject != gameObject) {
				collider.isTrigger = true;

		} else if (NewPlayer.Instance.velocity.y < 0) {
				collider.isTrigger = false;

		}
	}
}
