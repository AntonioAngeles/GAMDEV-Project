using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

    // Use this for initialization

    /*public GameObject panel;

    public void showPanel()
    {
        panel.gameObject.SetActive(true);
    }

    public void hidePanel()
    {
        panel.gameObject.SetActive(false);
    }*/

    [SerializeField] private GameObject panel;
	[SerializeField] private UnityChanControlScriptWithRgidBody script;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //panel.enabled = true;
            panel.gameObject.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			script.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //panel.enabled = false;
            panel.gameObject.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
			script.enabled = true;
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
