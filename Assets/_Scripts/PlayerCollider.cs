using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*Oct 22,2016
 * Christina Kuo - 300721385 
 * Player Collider - sets and gets score and lives and UI elements are included*/

//airplane sound from https://www.freesoundeffects.com/free-sounds/airplane-10004/

public class PlayerCollider : MonoBehaviour {

	//Private Instance Varaibles ++++++++++++++++++++++++++++++++++++++
	private int _livesValue;
	private int _scoreValue;

	[Header("UI Objects")]//+++++++++++++++++++++++++++++++++++++++
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text FinalScoreLabel; 
	public Button RestartButton; 
	public AudioSource Hit_Hurt8; 
	public GameObject Player; 
	public GameObject Enemy; 


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

	//Method for when Player collides with the enemy, will take away one life if hit and will add score if player passes the enemy
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			this.LivesValue -= 1;
			this.Hit_Hurt8.Play (); //http://www.bfxr.net/
		}

		if (other.gameObject.CompareTag ("Boundary")) {
			this.ScoreValue += 10; 
		}
	}

	//Method displays final score and restart button once game is over 
	private void _gameOver(){
		this.FinalScoreLabel.text = "FINAL SCORE: " + this.ScoreValue; 
		this.FinalScoreLabel.gameObject.SetActive (true); 
		this.RestartButton.gameObject.SetActive (true); 

		//will not be displayed on screen 
		this.ScoreLabel.gameObject.SetActive (false); 
		this.LivesLabel.gameObject.SetActive (false); 
		this.Player.SetActive (false); 
		this.Enemy.SetActive (false); 
	}

	//Method restarts the game when player clicks on the restart button 
	public void RestartGameButton_Click() {
		SceneManager.LoadScene ("Main");
	}
}
