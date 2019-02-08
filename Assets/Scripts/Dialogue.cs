using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour {

	public Dictionary<string, string []> dialogue  = new Dictionary<string, string []>();

	void Start(){
		dialogue.Add ("character1", new string[] {
		"Hey man how's it going?",
		"I'm thrilled to meet you!",
		"Got any ideas who jerry is?"
		
		});

		dialogue.Add ("character2a", new string[] {
			"Can you find me a big beautiful blue key?",
			"That way I'll open that door for you over there to the left!"
		});

		dialogue.Add ("character2b", new string[] {
			"Duuuuuude.... you found the key!",
			"Thanks man! Let me open that door for you!"
		});

		dialogue.Add ("character3a", new string[] {
			"Look in order to pass by this you need 15 Shapiro Shells...",
			"I'm not kidding dumbass..."
		});

		dialogue.Add ("character3b", new string[] {
			"Oh... wow. You found 15 Shapiro Shells...",
			"You may pass by without me killing you!"
		});

		dialogue.Add ("character4a", new string[] {
			"Hey priss head... I need 100 Shapiro Shells..."
		});

		dialogue.Add ("character4b", new string[] {
			"Whoa how'd you find so many!",
			"Thanks man! Here's the boss key!"
		});

		dialogue.Add ("lockedDoor1", new string[] {
			"A massive huge locked door...",
			"It's got an orange lock!"
		});
	}

}
