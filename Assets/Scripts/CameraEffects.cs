using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraEffects : MonoBehaviour {

	[SerializeField] private CinemachineVirtualCamera virtualCamera;

	[SerializeField] private CinemachineBasicMultiChannelPerlin multiChannelPerlin;
	//Shake length should not be higher than 10
	[Range(0,10)]
	public float shakeLength = 10;

	// Use this for initialization
	void Start () {
		NewPlayer.Instance.cameraEffect = this;
		virtualCamera = GetComponent<CinemachineVirtualCamera> ();
		multiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin> ();
		virtualCamera.Follow = NewPlayer.Instance.transform;
	}
		
	// Update is called once per frame
	void Update () {
		multiChannelPerlin.m_FrequencyGain += (0 - multiChannelPerlin.m_FrequencyGain) * Time.deltaTime * (10-shakeLength);
	}

	public void Shake(float shake, float length){
		shakeLength = length;
		multiChannelPerlin.m_FrequencyGain = shake;
	}


}
