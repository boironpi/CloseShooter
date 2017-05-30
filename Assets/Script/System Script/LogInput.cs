using UnityEngine;
using System;

public class LogInput : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//print(Input.GetAxis ("Mouse X"));
		//print(Input.GetAxis ("Mouse Y"));
		foreach ( KeyCode kcode in Enum.GetValues(typeof(KeyCode))){
			if (Input.GetKeyDown (kcode))
				print ("Keycode press = " + kcode);
			
	}
}
}