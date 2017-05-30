using UnityEngine;
using System.Collections;

public class scripte : MonoBehaviour {

	// Use this for initialization

	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){

		if (spawn1 != null) {
			SpawnScript sp1 = spawn1.GetComponent<SpawnScript> ();
			sp1.active = true;
		}
		if (spawn2 != null) {
			SpawnScript sp2 = spawn2.GetComponent<SpawnScript> ();
			sp2.active = true;
		}
		if (spawn3 != null) {
			SpawnScript sp3 = spawn3.GetComponent<SpawnScript> ();
			sp3.active = true;
		}
		if (spawn4 != null) {
			SpawnScript sp4 = spawn3.GetComponent<SpawnScript> ();
			sp4.active = true;
		}
	}
}
