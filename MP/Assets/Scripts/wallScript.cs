using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallScript : MonoBehaviour {
	[SerializeField] int wallColor = 0; // 1 - red, 2 - blue

	[SerializeField] GameObject wall;
	int activeColor = 0; 
	public const string PARAM_KEY = "ParamKey";

	// Use this for initialization
	void Start () {

		EventBroadcaster.Instance.AddObserver (EventNames.ON_GET_ACTIVE_COLOR, this.setActiveColor);
		EventBroadcaster.Instance.AddObserver (EventNames.ON_MAKE_WALLS_ACTIVE, this.makeWallActive);
		
		
	}
		

	void OnCollisionEnter(Collision collision) { 
		
		
		// Delete(?) this wall then post event to change active color
		// TODO: Delete (?) this wall
		if (collision.gameObject.name == "Player") {
			EventBroadcaster.Instance.PostEvent (EventNames.ON_CHECK_ACTIVE_WALL);
			//Debug.Log ("collision...");
			//Debug.Log ("wallColor: " + wallColor + " activeColor: " + activeColor);

			if (this.wallColor == activeColor) {
				//Debug.Log ("Changing active color...");

				//wall.GetComponent<Animator> ().Play ("WallHit");
				//wall.GetComponent<Animator> ().Play ("WallHit2");
				//wall.GetComponent<Animator> ().Play ("WallHit3");
				//wall.GetComponent<Animator> ().Play ("WallHit4");
					
				EventBroadcaster.Instance.PostEvent (EventNames.ON_MAKE_WALLS_ACTIVE);
				wall.SetActive (false);
				EventBroadcaster.Instance.PostEvent (EventNames.ON_WALL_HIT);
			}
		}


		
	}
		
	void makeWallActive() {
		if(this.wall != null)
			this.wall.SetActive (true);
	}

	void setActiveColor(Parameters parameters) {
		Debug.Log ("Set active color...");
		int colorNum = parameters.GetIntExtra (PARAM_KEY, -1);
		activeColor = colorNum;
		//Debug.Log ("Current Active Color: " + activeColor);
	}
}
