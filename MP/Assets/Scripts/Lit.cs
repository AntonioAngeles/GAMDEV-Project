using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lit : MonoBehaviour {

    [SerializeField] GameObject ilaw;
    private int x, xprime;

	// Use this for initialization
	void Start () {
        x = (int)ilaw.transform.rotation.eulerAngles.x;
        xprime = x-180;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        //while (x - xprime < 180) {
            //xprime--;
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(xprime, ilaw.transform.rotation.eulerAngles.y, ilaw.transform.rotation.eulerAngles.z);
            ilaw.transform.rotation = rot;

            //ilaw.transform.rotation.eulerAngles = new Vector3(0, xprime++, 0);
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //while (xprime != x) {
        //    xprime++;
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(x, ilaw.transform.rotation.eulerAngles.y, ilaw.transform.rotation.eulerAngles.z);
            ilaw.transform.rotation = rot;
        //}
    }

}
