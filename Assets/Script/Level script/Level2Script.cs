using UnityEngine;
using System.Collections;

public class Level2Script : MonoBehaviour {

	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;

	public Transform player;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!(spawn1 || spawn2 || spawn3 || spawn4)) {
			HealthScript hs = player.GetComponent<HealthScript> ();
			hs.hp = hs.hpRate;
			Application.LoadLevel ("Scene3");
		}

		if (!player) {
			Application.LoadLevel("Menu");

		}

	}
}
