using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {

	[SerializeField] private GameObject startUp;
	public string spawnToObject;
	[SerializeField] private GameObject healthBar;
	[SerializeField] private float healthBarWidth;
	private float healthBarWidthSmooth;
	[SerializeField] private float healthBarWidthEase;
	public Animator animator;
	[SerializeField] private Image inventoryItemGraphic;
	public TextMeshProUGUI gemAmountMesh;
	[SerializeField] private float gemAmountSmooth;
	[SerializeField] private float gemAmountEase;
	[SerializeField] private float gemAmountOld;
	public bool resetPlayer;
	public string loadSceneName;
	public Sprite blankUI;


	// Use this for initialization
	void Start () {
		healthBarWidth = 1;
		healthBarWidthSmooth = healthBarWidth;
		gemAmountSmooth = (float)GameManager.Instance.gemAmount;
		gemAmountOld = gemAmountSmooth;
	}

	// Update is called once per frame
	void Update () {
		float gemAmount = (float)GameManager.Instance.gemAmount;
		gemAmountMesh.text = Mathf.Round(gemAmountSmooth).ToString();
		gemAmountSmooth += (gemAmount - gemAmountSmooth) * Time.deltaTime * gemAmountEase;
	
		if (gemAmountSmooth >= gemAmountOld) {
			animator.SetTrigger ("getGem");
			gemAmountOld = gemAmountSmooth+1;
		}

		healthBarWidth = (float)NewPlayer.Instance.health / (float)NewPlayer.Instance.maxHealth;
		healthBarWidthSmooth += (healthBarWidth - healthBarWidthSmooth) * Time.deltaTime * healthBarWidthEase;
		healthBar.transform.localScale = new Vector2 (healthBarWidthSmooth, transform.localScale.y);
	}

	public void HealthBarHurt(){
		animator.SetTrigger ("hurt");
	}

	public void SetInventoryImage(Sprite image){
		inventoryItemGraphic.sprite = image;
	}

	void LoadScene(){
		startUp.gameObject.tag = "Startup";
		GameManager.Instance.gemAmount = 0;
		GameManager.Instance.ClearInventory ();
		if (resetPlayer) {
			NewPlayer.Instance.health = NewPlayer.Instance.maxHealth;
			NewPlayer.Instance.transform.position = GameObject.Find (spawnToObject).transform.position;
			NewPlayer.Instance.gameObject.GetComponent<MeshRenderer> ().enabled = true;
			NewPlayer.Instance.Freeze (false);

		}
		SceneManager.LoadScene(loadSceneName);
		Debug.Log ("Got camera effect component");
	}

}
