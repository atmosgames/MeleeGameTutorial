using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour {

	public Animator animator;
	private int index = -1;
	private int cPos = 0;
	private string[] characterDiologue; 
	[SerializeField] private float typeSpeed = 0.5f;
	[SerializeField] private bool keyIsDown = true;
	[SerializeField] private bool ableToAdvance; 
	[SerializeField] private bool activated; 
	private bool typing = true;
	[SerializeField] TextMeshProUGUI textMesh;
	[SerializeField] TextMeshProUGUI nameMesh;
	[SerializeField] Dialogue dialogue;
	private DialogueTrigger currentDialogueTrigger;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (activated) {
			//Check for key press
			if (((Input.GetAxis ("Submit") > 0) || (Input.GetAxis ("Jump") > 0)) && !keyIsDown) {
				keyIsDown = true;
				if (!typing) {
					if (index < characterDiologue.Length - 1) {
						if (ableToAdvance) {
							Advance ();
						}
					} else {
						Close ();
					}
					if (index == 0) {
						ableToAdvance = true;
					}
				}
			}

			//Check for first release to ensure we can't spam
			if (keyIsDown && Input.GetAxis ("Submit") < .001 &&  Input.GetAxis ("Jump") < .001) {
				//animator.SetBool ("pressed", false);
				if (!typing) {

					keyIsDown = false;
					if (index == 0) {
						ableToAdvance = true;
					}
				}
			}
		}
	}

	public void Appear(string fileName, string characterName, DialogueTrigger dialogueTrigger, bool useItemAfterClose){
		if (useItemAfterClose) {
			currentDialogueTrigger = dialogueTrigger;
		}
		nameMesh.text = characterName;
		characterDiologue = dialogue.dialogue[fileName];
		animator.SetBool ("active", true);
		activated = true;
		NewPlayer.Instance.Freeze (true);
		Advance ();
	}

	public void Close(){
		//The dialogueTrigger will pass itself into this function only if you have the right items to close the diologue and complete the quest
		if (currentDialogueTrigger != null) {
			currentDialogueTrigger.UseItem ();
		}

		activated = false;
		animator.SetBool ("active", false);
		StopCoroutine ("TypeText");
		index = - 1;
		keyIsDown = false;
		ableToAdvance = false;
	}

	void Advance(){
		index ++;
		textMesh.text = "";
		typing = true;
		if(ableToAdvance){
			animator.SetTrigger ("press");
		}
		StartCoroutine ("TypeText");
	}

	IEnumerator TypeText()
	{
		foreach (char c in characterDiologue[index]) 
		{
			cPos++;
			if (cPos != 0 && cPos == characterDiologue[index].Length) {
				typing = false;
				cPos = 0;
				Debug.Log ("Set keyIsDown back to false!");
			}

			textMesh.text += c;
			yield return new WaitForSeconds (typeSpeed);
		}
	}
}
