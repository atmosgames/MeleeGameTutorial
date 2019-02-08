using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	enum ItemType {InventoryItem, Gem};
	[SerializeField] ItemType itemType;
	[SerializeField] private AudioClip collectSound;
	[SerializeField] private AudioClip bounceSound;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private string itemName;
	[SerializeField] private int itemAmount;
	[SerializeField] private Sprite image;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject == NewPlayer.Instance.gameObject) {
			Collect ();
		}
	}

	void Collect(){
		if(itemType == ItemType.InventoryItem){
			if(itemName != ""){
				GameManager.Instance.GetInventoryItem(itemName, image);
			}
		}else if(itemType == ItemType.Gem){
			GameManager.Instance.gemAmount += itemAmount;
		}

		GameManager.Instance.audioSource.PlayOneShot (collectSound);
		if (transform.parent.GetComponent<Bouncer> () != null) {
			Destroy (transform.parent.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}
