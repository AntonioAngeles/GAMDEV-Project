using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour {

	[SerializeField] int activeColor = 1; // 1 - red (default), 2 - blue
	[SerializeField] int level = 0;
	// Use this for initialization
	void Start () {

		// initialize starting color
		Parameters parameters = new Parameters ();
		parameters.PutExtra ("ParamKey", this.activeColor);
		EventBroadcaster.Instance.PostEvent(EventNames.ON_GET_ACTIVE_COLOR,parameters);
		Debug.Log ("Current Active Color: " + activeColor);
		EventBroadcaster.Instance.AddObserver (EventNames.ON_WALL_HIT, this.changeActiveColor);
		EventBroadcaster.Instance.AddObserver (EventNames.ON_REPLAY_LEVEL,this.reloadScene); // will change soon with parameters (scene level)
		EventBroadcaster.Instance.AddObserver (EventNames.ON_CHECK_ACTIVE_WALL, this.sendActiveWall);



		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void sendActiveWall() {
		Parameters parameters = new Parameters ();
		parameters.PutExtra ("ParamKey", this.activeColor);
		EventBroadcaster.Instance.PostEvent(EventNames.ON_GET_ACTIVE_COLOR,parameters);
	}


	// On active color wall hit, change active color
	void changeActiveColor() {
		Debug.Log ("On wall hit called...");

		if (this.activeColor == 1) {
			this.activeColor = 2; // change to blue
			Debug.Log ("Current Active Color: " + this.activeColor);
			Parameters parameters = new Parameters ();
			parameters.PutExtra ("ParamKey", this.activeColor);
			EventBroadcaster.Instance.PostEvent (EventNames.ON_GET_ACTIVE_COLOR, parameters);
		} else if (this.activeColor == 2) {
			this.activeColor = 1; // change to red
			Debug.Log ("Current Active Color: " + this.activeColor);
			Parameters parameters = new Parameters ();
			parameters.PutExtra ("ParamKey", this.activeColor);
			EventBroadcaster.Instance.PostEvent (EventNames.ON_GET_ACTIVE_COLOR, parameters);
		}
			
	}

	void PrintSomething() {
		Debug.Log ("ayy lmao...");
	}

	void reloadScene() {
		SceneManager.LoadScene ("Tutorial");

	}


}
