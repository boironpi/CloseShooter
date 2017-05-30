using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			float X = target.position.x;
			float Y = target.position.y;
			transform.position = new Vector3 (X, Y, transform.position.z);
		}
	}
}
