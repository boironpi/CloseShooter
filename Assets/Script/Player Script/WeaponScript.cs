using UnityEngine;
using System;

public class WeaponScript : MonoBehaviour {

	public Transform shootPrefab;
	public float shootingRate = 0.25f;
	private float shootCooldown;
	private PlayerScript ps;

	// Use this for initialization
	void Start () {

		shootCooldown = 0f;
		ps = this.GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}

	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack) {
			shootCooldown = shootingRate;
			var shootTransform = Instantiate (shootPrefab) as Transform;
			//shootTransform.position = new Vector3(transform.position.x, transform.position.y+2,transform.position.z);
			shootTransform.position = transform.position;
			ShootScript shot = shootTransform.gameObject.GetComponent<ShootScript> ();
			shot.player = GetComponent<Transform>();
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}
			MoveScript move = shootTransform.gameObject.GetComponent<MoveScript> ();
			if (move != null) {
				float inputX = Input.GetAxis ("Mouse X");
				float inputY = Input.GetAxis ("Mouse Y");
				move.direction = new Vector2 (inputY, inputX); // ici la droite sera le devant de notre objet
			}
			ps.hits+=1;
		}




	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
