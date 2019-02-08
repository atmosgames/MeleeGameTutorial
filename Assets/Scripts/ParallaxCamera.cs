using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParallaxCamera : MonoBehaviour 
{
	public delegate void ParallaxCameraDelegate(float deltaMovementX, float deltaMovementY);
	public ParallaxCameraDelegate onCameraTranslate;
	private float oldPositionX;
	private float oldPositionY;
	private float tilt;

	void Start()
	{
		oldPositionX = transform.position.x;
		oldPositionY = transform.position.y+tilt;
	}
	void Update()
	{
		if (transform.position.x != oldPositionX || (transform.position.y+tilt) != oldPositionY )
		{
			if (onCameraTranslate != null)
			{
				float deltaX = oldPositionX - transform.position.x;
				float deltaY = oldPositionY - (transform.position.y+tilt);
				onCameraTranslate(deltaX, deltaY);
			}
			oldPositionX = transform.position.x;
			oldPositionY = transform.position.y+tilt;
			if (tilt == 0) {
				tilt = 2;
			}
		}
	}
}