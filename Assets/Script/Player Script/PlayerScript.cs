using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speedInitial = new Vector2(25, 25);
	public Vector2 speedCurrently = new Vector2(25, 25);
	public Vector2 movement; //vecteur de velocite
	private bool resetAttack = true; 
	private ProjectionScript pj;
	private DashScript ds;
	public Animator animator;
	private int animationAttackNb;
	public int hits= 0;
	// Use this for initialization
	void Start () {
		pj = GetComponent<ProjectionScript> ();
		ds = GetComponent<DashScript> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");



		movement = new Vector2(speedCurrently.x * inputX, speedCurrently.y * inputY);
		float inputXR = Input.GetAxis ("Mouse X");
		float inputYR = Input.GetAxis ("Mouse Y");

		float LTRT = Input.GetAxis ("LTRT");




		if (LTRT>0.2f) {
			ds.BeginDash(new Vector2(inputX,inputY));
		}
	

		if (AttackStarted (inputXR, inputYR)&&resetAttack==true) {
			WeaponScript weapon = GetComponent<WeaponScript> ();
			speedCurrently = new Vector2 (10, 10);
			resetAttack = false;
		
			AnnimationAttack (inputYR,inputXR);
			if (weapon != null) {
				// false : le joueur n'est pas un ennemi
				weapon.Attack (false);
				//SoundEffectsHelper.Instance.MakePlayerShotSound();
			}
		} else {
			if (!AttackStarted (inputXR, inputYR)) { //si le joueur a remis son joystick au millieu rénitialise l'attaque
				resetAttack = true;

				speedCurrently = speedInitial;
			}
			if (hits > 0) {
				animator.SetInteger ("direction", animationAttackNb);
				animator.SetInteger ("direction", 3);

			} else {
				print ("ok");
				animator.SetInteger ("direction", 5);
				AnnimationMarche (inputX, inputY);
			}
		}

	/*	if (resetAttack == true && attacked==true) {
			animator.SetInteger ("direction", 5);
			AnnimationMarche (inputX, inputY);

		} else {
			animator.SetInteger ("direction", animationAttackNb);
		}*/




	}

	public bool AttackStarted(float X, float Y){

		return(X > 0.05|| X < -0.05 || Y > 0.05 || Y < -0.05 );


	}

	void FixedUpdate()
	{
		if(!pj.projection && !ds.dash)
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	void OnDestroy()
	{
		// Game Over.
		// Ajouter un nouveau script au parent
		// Car cet objet va être détruit sous peu
		//transform.parent.gameObject.AddComponent<GameOverScript>();
	}



	private void AnnimationMarche(float x, float y){
		

		if (x > 0 && Mathf.Approximately (y, 0)) {
			
				animator.SetInteger ("direction", 6);
				
			}

		if (x < 0 && Mathf.Approximately (y, 0)) {

			animator.SetInteger ("direction", 4);


		}
		if (y < 0 && Mathf.Approximately (x, 0)) {

			animator.SetInteger ("direction", 2);

		}
		if (y > 0 && Mathf.Approximately (x, 0)) {

			animator.SetInteger ("direction", 8);

		}



		if ( Mathf.Approximately (x, 0) &&  Mathf.Approximately (y, 0)) {
			animator.Play (animator.GetCurrentAnimatorStateInfo (0).tagHash, -1, 0);

		}
	
	}

	private void AnnimationAttack(float x, float y){
		


		if (x > 0 && y> 0) {

			if (x > y) {
				animator.SetInteger ("direction", 66);
				animationAttackNb = 66;

			} else {
				animator.SetInteger ("direction", 88);
				animationAttackNb = 88;

			}
		}

		if (x < 0 && y< 0) {

			if (x > y) {
				animator.SetInteger ("direction", 22);
				animationAttackNb = 22;

			} else {
				animator.SetInteger ("direction", 44);
				animationAttackNb = 44;

			}


		}
		if (y < 0 && x> 0) {

			if (x > -y) {
				animator.SetInteger ("direction", 66);
				animationAttackNb = 66;

			
			} else {
				animator.SetInteger ("direction", 22);
				animationAttackNb = 22;

			}


		}
		if (y > 0 && x < 0) {

			if (-x > y) {
				animator.SetInteger ("direction", 44);
				animationAttackNb = 44;

			} else {
				animator.SetInteger ("direction", 88);
				animationAttackNb = 88;

			}

		}


	}
}
