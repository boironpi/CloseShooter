using UnityEngine;
using System.Collections;

public class UltimateWeaponScript : MonoBehaviour {

	public Transform shootPrefab;
	public int shootingLoad = 0;
	private PlayerScript ps;

	// Use this for initialization
	void Start () {
		ps = this.GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack) {
			shootingLoad = 0;
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
				move.direction = findDirection(inputY, inputX); // ici la droite sera le devant de notre objet
			}
			shootTransform.Rotate (new Vector3 (0, 0, findAngle));
		}




	}

	private Vector2 findDirection(float x,float y){
		Vector2 direction;

		if (x > 0 && Mathf.Approximately (y, 0)) {

			direction = new Vector2 (1, 0);

		}

		else if (x < 0 && Mathf.Approximately (y, 0)) {

			direction = new Vector2 (-1, 0);

		}
		else if (y < 0 && Mathf.Approximately (x, 0)) {

			direction = new Vector2 (0, -1);

		}
		else if (y > 0 && Mathf.Approximately (x, 0)) {

			direction = new Vector2 (0, 1);

		}
		else if (y > 0 && x > 0) {

			direction = new Vector2 (1, 1);

		}
		else if (y < 0 && x > 0) {

			direction = new Vector2 (1, -1);

		}
		else if (y > 0 && x < 0) {

			direction = new Vector2 (-1, 1);

		}
		else if (y < 0 && x < 0) {

			direction = new Vector2 (-1, -1);

		}

	}

	private int findAngle(float x,float y){
		int angle;
		if (x > 0 && Mathf.Approximately (y, 0)) {

			angle = 0;

		}

		else if (x < 0 && Mathf.Approximately (y, 0)) {

			angle = 180;

		}
		else if (y < 0 && Mathf.Approximately (x, 0)) {

			angle = 90;

		}
		else if (y > 0 && Mathf.Approximately (x, 0)) {

			angle = 270;

		}
		else if (y > 0 && x > 0) {

			angle = 45;

		}
		else if (y < 0 && x > 0) {

			angle = 315;

		}
		else if (y > 0 && x < 0) {

			angle = 135;

		}
		else if (y < 0 && x < 0) {

			angle = 225;

		}

	}

		


	public bool CanAttack
	{
		get
		{
			return shootingLoad <= 100;
		}
	}

	public void loadingWeapon(int loading){
		
		if (shootingLoad + loading < 100) {
			shootingLoad = 100;
		} else {
			shootingLoad += loading;
		}
	
	}
}
