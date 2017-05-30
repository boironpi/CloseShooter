using UnityEngine;
using System.Collections;

public class DashScript : MonoBehaviour {

	private Rigidbody2D rb;
	private HealthScript hs;

	public float dashTimeMax = 3f; //temps du dash
	public float dashTime;  // temps passer depuis le debut du dash
	public float dashCooldown=0f;	
	public float dashCooldownRate=0f;	//temps du cooldown

	public float dashCooldownGhostRate=0f;	//temps du cooldown pour effet particule
	public float dashCooldownGhost=0f;
	private Vector2 lastGhostPosition;
	public float distanceGhostEnable = 0f;

	public bool dash = false;		//si le personnage dash
	public Vector2 dashVelocity;	//vecteur du dash
	public Vector2 dashDirection;
	public float power = 1f;		//puissance du dash
	public int direction = 5;		//direction du dash en foncton du paver numerique (4862)


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		hs = this.GetComponent<HealthScript>();

	}

	// Update is called once per frame
	void Update () {

		if (dashCooldown > 0f) {
			dashCooldown -= Time.deltaTime;

		} 

		if (dash) {
				
			if(distanceGhostEnable< Vector2.Distance(rb.position, lastGhostPosition)){
				print (Vector2.Distance (rb.position, lastGhostPosition));
				Vector3 positionGhost = new Vector3(rb.position.x,rb.position.y,transform.position.z+1);
				SpecialEffectsHelper.Instance.Ghost(positionGhost,direction);
				lastGhostPosition = rb.position;
			
			}
				dashTime += Time.deltaTime * 3;
			/**	dashCooldownGhost += Time.deltaTime * 3;
			if (dashCooldownGhost > dashCooldownGhostRate) {
				Vector3 positionGhost = transform.position;
				positionGhost.z += 1;
				SpecialEffectsHelper.Instance.Ghost(positionGhost,direction);
				dashCooldownGhost = 0f;

			}*/
				

				if (dashTime >= dashTimeMax) {
					rb.velocity = new Vector2 (0, 0);
					dashTime = 0f;
					dash = false;
					hs.invincibility = false;
					dashCooldownGhost = 0f;
				}
			}

		}



	public void BeginDash(Vector2 directionPlayer){

		if (dashCooldown <= 0f) {
			hs.invincibility = true;
			dash = true;
			directionDash (directionPlayer);
			addDirectionToDash (direction);
			dashVelocity = this.dashDirection;
			dashVelocity.x *= power;
			dashVelocity.y *= power;
			dashCooldown = dashCooldownRate;

			Vector3 positionGhost = new Vector3(rb.position.x,rb.position.y,transform.position.z+1);
			SpecialEffectsHelper.Instance.Ghost(positionGhost,direction);
			lastGhostPosition = rb.position;
		}

	}

	void FixedUpdate()
	{

		if (dash) {
			rb.velocity = dashVelocity;
		}
	}
	/*
	 * directionDash ce charge de l'animation du dash
	 * 
	 * */
	private void directionDash ( Vector2 dash ){
		float x = dash.x;
		float y = dash.y; 

		if (x > 0 && Mathf.Approximately (y, 0)) {

			direction = 6;

		}

		if (x < 0 && Mathf.Approximately (y, 0)) {

			direction = 4;


		}
		if (y < 0 && Mathf.Approximately (x, 0)) {

			direction = 2;

		}
		if (y > 0 && Mathf.Approximately (x, 0)) {

			direction = 8;

		}

		if (x > 0 && y > 0) {

			direction = 9;

		}

		if (x < 0 && y > 0) {

			direction = 7;


		}
		if (y < 0 && x > 0) {

			direction = 3;

		}
		if (y < 0 && x < 0) {

			direction = 1;





		}
	}

	/*
	 * addDirectionToDash ce charge de la direction de la force du dash
	 * 
	 * */
	private void addDirectionToDash ( int dash ){
		

		if (direction == 6) {

			this.dashDirection = new Vector2(1,0);

		}

		if (direction == 4) {

			this.dashDirection = new Vector2(-1,0);


		}
		if (direction == 2) {

			this.dashDirection = new Vector2(0,-1);

		}
		if (direction == 8) {

			this.dashDirection = new Vector2(0,1);

		}


		if (direction == 9) {

			this.dashDirection = new Vector2(1,1);

		}

		if (direction == 7) {

			this.dashDirection = new Vector2(-1,1);


		}
		if (direction == 1) {

			this.dashDirection = new Vector2(-1,-1);

		}
		if (direction == 3) {

			this.dashDirection = new Vector2(1,-1);

		}
	}
		
}