using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	// Use this for initialization
	public int damage = 1;
	public bool isEnemyShot = false; //projectile ami ou enemis
	public float lifeTime = 2;
	private Vector2 initialPosition;
	public float range;
	public Transform player;
	public Vector2 mouvJoueur;
	public bool ultimate = false;

	// Use this for initialization
	void Start () {
			initialPosition = GetComponent<Transform> ().position;
		if (!ultimate) {
			Destroy (gameObject, lifeTime);
			SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer> ();
			sprite.enabled = false;
			//destruction programé au bout de 2s
		} else {
			
			Destroy (gameObject, lifeTime);
		
		}
	}

	// Update is called once per frame
	void Update () {
		PlayerScript ps = player.GetComponent<PlayerScript> ();
		MoveScript ms = this.GetComponent<MoveScript> ();
		ms.movement += ps.movement;


		if (Vector2.Distance (initialPosition, GetComponent<Transform> ().position) > range)
			Destroy (gameObject);
	}

	void OnDestroy(){
		PlayerScript ps = player.GetComponent<PlayerScript> ();
		if(!ultimate)
			ps.hits -= 1;
	
	}

}
