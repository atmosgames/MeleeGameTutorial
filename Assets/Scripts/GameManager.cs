using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Singleton instantiation
	public AudioSource audioSource;
	public DialogueBox dialogueBox;
	public PlayerUI playerUI;
	public int gemAmount;
	public Dictionary<string, Sprite> inventory  = new Dictionary<string, Sprite>();
	private static GameManager instance;

	public static GameManager Instance{
        get { 
            if (instance == null) instance = GameObject.FindObjectOfType<GameManager>(); 
            return instance;
        }
    }

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	public void GetInventoryItem (string name, Sprite image) {
		inventory.Add (name, image);
		playerUI.SetInventoryImage(inventory[name]);
	}

	public void RemoveInventoryItem (string name) {
		inventory.Remove (name);
		playerUI.SetInventoryImage(playerUI.blankUI);
	}

	public void ClearInventory () {
		inventory.Clear ();
		playerUI.SetInventoryImage(playerUI.blankUI);
	}

}
