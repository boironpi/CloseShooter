using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(0, 0);

	public Vector2 direction = new Vector2(0, 0); 
	public bool imobility=false;
	public Vector2 movement;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}
	void FixedUpdate()
	{
		//GetComponent<Rigidbody2D>().velocity = movement;
		if (imobility == false) {
			GetComponent<Transform> ().Translate (movement);
		}
		//GetComponent<Transform> ().Translate (direction);
	}

}
