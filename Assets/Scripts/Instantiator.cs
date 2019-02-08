using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

	[SerializeField] GameObject [] objects;
	//Amount can only be used if objects is one item
	[SerializeField] float amount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InstantiateObjects(){
		GameObject iObject;
		if (amount == 0) {
			for (int i = 0; i < objects.Length; i++) {
				iObject = Instantiate (objects [i], transform.position, Quaternion.identity, null);
				if (iObject.GetComponent<Bouncer> () != null) {
					iObject.GetComponent<Bouncer> ().launchOnStart = true;
					Debug.Log("Set" + iObject.name + "to Launch on start: " + 	iObject.GetComponent<Bouncer> ().launchOnStart);
				}
			}
		} else {
			for (int i = 0; i < amount; i++) {
				iObject = Instantiate (objects [0], transform.position, Quaternion.identity, null);
				if (iObject.GetComponent<Bouncer> () != null) {
					iObject.GetComponent<Bouncer> ().launchOnStart = true;
					Debug.Log("Set" + iObject.name + "to Launch on start: " + 	iObject.GetComponent<Bouncer> ().launchOnStart);
				}
			}
		}
	}

	void Launch(){
		
	}
}
