using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	public Transform UnitPrefab;
	public Transform player;
	public int Unit;
	public int UnitCapacity;
	public float CooldownSpawn=0f;
	public float CooldownSpawnRate=0f;
	public bool active=true;
	public bool destruction= false;
	public float CooldownExplose = 3f;
	public Transform lastUnit; 

	// Use this for initialization
	void Start () {
		Reload();
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (CooldownSpawn <= 0 && Unit > 0) {
				CooldownSpawn = CooldownSpawnRate;
				var UnitTransform = Instantiate (UnitPrefab) as Transform;
				Vector3 positionSpawn = transform.position;
				positionSpawn.y += 2;
				UnitTransform.position = positionSpawn;
				if (Unit == 1) {
					lastUnit = UnitTransform; 
				}
				Unit -= 1;
				UnitTransform.gameObject.GetComponent<IAFollowPlayer> ().target = player;

			} else {
				CooldownSpawn -= Time.deltaTime;
			}
			if (Unit == 0 && destruction == false && lastUnit==null) {
				ParticleSystem ps = SpecialEffectsHelper.Instance.Explosion(new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z-3));
				CooldownSpawn = CooldownExplose;
				destruction = true;

			}
			if (CooldownSpawn < 0 && destruction == true) {
				Destroy (this.gameObject);
			}
		}
	}
	void Reload(){
		Unit = UnitCapacity;
	
	}




}
