using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour {

	//Private Instance Varaibles
	private int _livesValue;
	private int _scoreValue;

	[Header("UI Objects")]
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text FinalScoreLabel; 
	public Button RestartButton; 


	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
				this._gameOver (); 
			} else {
				this.LivesLabel.text = "Lives: " + this._livesValue;
			}
		}
	}

	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}


	// Use this for initialization
	void Start () {
		this.LivesValue = 5; 
		this.ScoreValue = 5; 
		this.FinalScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			this.LivesValue -= 1;
		}

		if (other.gameObject.CompareTag ("Boundary")) {
			this.ScoreValue += 10; 
		}
	}

	private void _gameOver(){
		this.FinalScoreLabel.text = "FINAL SCORE: " + this.ScoreValue; 
		this.FinalScoreLabel.gameObject.SetActive (true); 
		this.RestartButton.gameObject.SetActive (true); 
		this.ScoreLabel.gameObject.SetActive (false); 
		this.LivesLabel.gameObject.SetActive (false); 
	}
	public void RestartGameButton_Click() {
		SceneManager.LoadScene ("Main");
	}
}
