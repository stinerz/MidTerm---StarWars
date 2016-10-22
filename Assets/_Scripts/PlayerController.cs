using UnityEngine;
using System.Collections;

/*Oct 22,2016
 * Christina Kuo - 300721385 
 * Player Controller - controls player movement by mouse*/

public class PlayerController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	//public float speed;
	public Boundary boundary;

	public Camera camera;

	// PRIVATE INSTANCE VARIABLES
	private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private GameObject _playerControllerObject;
	private PlayerCollider _playerCollider;

	// Use this for initialization
	void Start () {
		this._initialize (); 
	}

	// Update is called once per frame
	void Update () {
		this._CheckInput ();
	}

	private void _CheckInput() {
		this._newPosition = gameObject.GetComponent<Transform> ().position; // current position

		// movement by mouse
		Vector2 mousePosition = Input.mousePosition;
		this._newPosition.x = this.camera.ScreenToWorldPoint (mousePosition).x;

		this._BoundaryCheck ();

		gameObject.GetComponent<Transform>().position = this._newPosition;
	}

	private void _BoundaryCheck() {
		if (this._newPosition.x < this.boundary.xMin) {
			this._newPosition.x = this.boundary.xMin;
		}

		if (this._newPosition.x > this.boundary.xMax) {
			this._newPosition.x = this.boundary.xMax;
		}
	}

	private void _initialize(){
		this._transform = GetComponent<Transform> ();
		this._rigidbody = GetComponent<Rigidbody2D> ();
		this._playerControllerObject = GameObject.Find ("Player Controller");
		this._playerCollider = GetComponent<PlayerCollider> () as PlayerCollider;
	}


}