using UnityEngine;
using System.Collections;

public class ProjectionScript : MonoBehaviour {


	private Rigidbody2D rb;
	public float projectionTimeMax = 3f;
	public float projectionTime;
	public bool projection = false;
	public bool newProjection = false;
	public Vector2 lastProjection;
	public float power = 1f;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (newProjection) {						//si une nouvelle projection
			
			projection = true;
			lastProjection.x *=power;
			lastProjection.y *= power;

			//rb.velocity = lastProjection;

		}
		if (projection) {
			projectionTime += Time.deltaTime * 3;
			if (projectionTime >= projectionTimeMax) {
				rb.velocity = new Vector2(0,0);

				projectionTime = 0;
				projection = false;
			}
		}

		newProjection = false;

	}

	public void BePush(Vector2 push){
		newProjection = true;
		lastProjection = push;

	}

	void FixedUpdate()
	{
		
		if (projection) {
			rb.velocity = lastProjection;
			print (lastProjection);
		}
	}

}