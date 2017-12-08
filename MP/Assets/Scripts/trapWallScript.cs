using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapWallScript : MonoBehaviour {

	[SerializeField] GameObject trapWall;
	[SerializeField] UnityChanControlScriptWithRgidBody script;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision collision) { 


		// Delete(?) this wall then post event to change active color
		// TODO: Delete (?) this wall
		if (collision.gameObject.name == "Player") {
			Debug.Log ("trap collision...");
			trapWall.GetComponent<Animator> ().enabled = false;
			collision.gameObject.GetComponent<Animator>().Play ("PlayerTrapHit");
			script.enabled = false;
			Debug.Log ("game over! :(");
		}

		Invoke ("postReplayEvent", 3);

	}

	void postReplayEvent() {
		EventBroadcaster.Instance.PostEvent (EventNames.ON_REPLAY_LEVEL);
	}
		


}
