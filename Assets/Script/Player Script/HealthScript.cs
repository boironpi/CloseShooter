using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp;
	public int hpRate;
	public bool isEnemy = true;
	public bool contact = false;
	public float temporyInvicibilityCoolDown;
	public float rateTemporyInvicibilityCoolDown;
	public bool temporyInvincibility = false;

	public bool invincibility = false;
	public Slider healthSlider;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (!invincibility && !temporyInvincibility) {
			ShootScript shot = collider.gameObject.GetComponent<ShootScript> ();
			ContactDamageScript hit = collider.gameObject.GetComponent<ContactDamageScript> ();
			SpriteRenderer sprite = collider.gameObject.GetComponent<SpriteRenderer> ();

			if (shot != null) {
				if (shot.isEnemyShot != isEnemy) {
					hp -= shot.damage;
					if (!isEnemy) {
						healthSlider.value = hp;
						temporyInvincibilityStart ();
					}
					shot.damage = 0;
					sprite.enabled = true;
					MoveScript ms = collider.gameObject.GetComponent<MoveScript> ();
					ms.imobility =true;
					ProjectionScript projection = this.gameObject.GetComponent<ProjectionScript> ();
					projection.BePush (ms.direction);
					Destroy (shot.gameObject,0.1f);
				}
				if (hp == 0) {
					MoveScript ms = this.gameObject.GetComponent<MoveScript> ();

					ms.imobility =true ;//dead 
					Destroy (gameObject,0.3f);
				}
			}
			if (hit != null) {
				if (hit.isEnemyHit != isEnemy) {
					hp -= hit.damage; //les dégats infliger
					if (!isEnemy) {
						healthSlider.value = hp;
						temporyInvincibilityStart ();
					}
					ProjectionScript ps = this.gameObject.GetComponent<ProjectionScript> ();
					if (ps) {
						MoveScript ms = collider.gameObject.GetComponent<MoveScript> ();
						ps.BePush (ms.direction);
					}
				}
				if (hp == 0) {

					//dead 
					Destroy (gameObject);
				}
			}
		}
	}


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (rateTemporyInvicibilityCoolDown > temporyInvicibilityCoolDown) {
			temporyInvicibilityCoolDown += Time.deltaTime;
		}

		if (temporyInvicibilityCoolDown >= rateTemporyInvicibilityCoolDown) {
			temporyInvincibility = false;
		}
	}

	void temporyInvincibilityStart(){
		temporyInvincibility = true;
		temporyInvicibilityCoolDown = 0f;
	}


}

