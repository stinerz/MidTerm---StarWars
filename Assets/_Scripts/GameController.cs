using UnityEngine;
using System.Collections;
/*Oct 22,2016
 * Christina Kuo - 300721385 
 * Game Controller - computationally clones the enemy prefab*/

public class GameController : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
		public int enemyCount;
		public GameObject enemy;

		// Use this for initialization
		void Start () {
			this._GenerateEnemies ();
		}

		// Update is called once per frame
		void Update () {

		}

		// generate Clouds
		private void _GenerateEnemies() {
			for (int count=0; count < this.enemyCount; count++) {
				Instantiate(enemy);
			}
	}
}
