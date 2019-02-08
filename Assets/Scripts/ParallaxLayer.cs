	using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxLayer : MonoBehaviour
{
	public float parallaxFactor;


	void Start()
	{
		if(parallaxFactor < 0){
			transform.localScale *= 1+Mathf.Abs(parallaxFactor*1.1f);
		}
	}

	public void Move(float deltaX, float deltaY)
	{
		Vector3 newPos = transform.localPosition;
		newPos.x -= deltaX * parallaxFactor;
		newPos.y -= deltaY * parallaxFactor;
		transform.localPosition = newPos;
	}
}