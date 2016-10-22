using UnityEngine;
using System.Collections;

/*Oct 22,2016
 * Christina Kuo - 300721385 
 * Enemy Controller sets the speed and position of the enemy*/

[System.Serializable] //variables display on inspector
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable] //variables display on inspector 
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	public Speed speed;
	public Boundary boundary;

	// PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	private float _CurrentSpeed;
	private float _CurrentDrift;

	// Use this for initialization
	void Start () {
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.y <= boundary.yMin) {
			this._Reset();
		}
	}

	// resets the gameObject
	private void _Reset() {
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}


}
