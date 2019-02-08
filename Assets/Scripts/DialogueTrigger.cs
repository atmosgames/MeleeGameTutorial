using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	[SerializeField] private bool autoHit;
	[SerializeField] private string fileName;
	[SerializeField] private string fileNamePhase2;
	[SerializeField] private string characterName;
	[SerializeField] private string requiredItem;
	[SerializeField] private int requiredGems;
	[SerializeField] private string getWhichItem;
	[SerializeField] private int getGemAmount;
	[SerializeField] private Sprite getItemSprite;
	[SerializeField] private AudioClip getSound;
	[SerializeField] private Animator useItemAnimator;
	[SerializeField] private string useItemAnimatorBool;
	[SerializeField] private bool sleeping;
	[SerializeField] private bool repeat;
	[SerializeField] private Animator icon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject == NewPlayer.Instance.gameObject && !sleeping) {
			icon.SetBool ("active", true);
			if (autoHit || (Input.GetAxis ("Submit") > 0)) {
				icon.SetBool ("active", false);
				if (requiredItem == "" && requiredGems == 0 || !GameManager.Instance.inventory.ContainsKey(requiredItem) &&  requiredGems == 0 || (requiredGems != 0 && GameManager.Instance.gemAmount < requiredGems)) {
					GameManager.Instance.dialogueBox.Appear (fileName, characterName, this, false);
				} else if(requiredGems == 0 && GameManager.Instance.inventory.ContainsKey(requiredItem) || (requiredGems != 0 && GameManager.Instance.gemAmount >= requiredGems)){
					if (fileNamePhase2 != "") {
						GameManager.Instance.dialogueBox.Appear (fileNamePhase2, characterName, this, true);
					} else {
						UseItem();
					}
				}

				sleeping = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject == NewPlayer.Instance.gameObject && sleeping) {

			if (repeat) {
				sleeping = false;
			}
		}

		icon.SetBool ("active", false);
	}

	public void UseItem(){
		if (useItemAnimatorBool != "") {
			useItemAnimator.SetBool (useItemAnimatorBool, true);
		}

		Collect ();


		if (GameManager.Instance.inventory.ContainsKey (requiredItem)) {
			GameManager.Instance.RemoveInventoryItem (requiredItem);
		} else {
			GameManager.Instance.gemAmount -= requiredGems;
		}
		repeat = false;
	}

	public void Collect(){
		
		if(getWhichItem != ""){
			GameManager.Instance.GetInventoryItem(getWhichItem, getItemSprite);
		}

		if(getGemAmount != 0){
			GameManager.Instance.gemAmount += getGemAmount;
		}

		if (getSound != null) {
			GameManager.Instance.audioSource.PlayOneShot (getSound);
		}

	}
}