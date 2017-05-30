using UnityEngine;
using System.Collections;

public class IAFollowPlayer : MonoBehaviour {
	public Transform target;
	public Vector2 positionTarget;
	public Animator animator;
	public int xDirection = 0;
	public int yDirection = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (target) {
			
			//Vector2 positionTarget = new Vector2 (target.transform.position.x, target.transform.position.y);
			//Vector2 positionIA = new Vector2 (this.transform.position.x,this.transform.position.y);
			basicRush();
			animationDirection (xDirection,yDirection);






			/*
			float x = this.transform.position.x + 10;
			float a = (target.transform.position.y - this.transform.position.y) / (target.transform.position.x - this.transform.position.x);
			float b = this.transform.position.y - a * this.transform.position.x;
			float y = a * x + b;
		*/
			
		}
	}
	private void basicRush(){
		float xtarget = target.transform.position.x; 
		float ytarget = target.transform.position.y;
		float xIA = this.transform.position.x;
		float yIA = this.transform.position.y;


		if (xtarget < xIA) {
			xDirection = -1;
		}

		if (xtarget > xIA) {
			xDirection = 1;
		}

		if (xtarget< xIA+1f && xtarget > xIA-1f) {
			xDirection = 0;
		}


		if (ytarget < yIA) {
			yDirection = -1;
		}
		if (ytarget > yIA) {
			yDirection = 1;

		}
		if ( ytarget< yIA+1f && ytarget > yIA-1f ) {
			yDirection = 0;

		}
			


		GetComponent<MoveScript> ().direction = new Vector2(xDirection,yDirection);




	}

	private void animationDirection(int x, int y){
	
		print (x + "     y=" + y);

		if (x == 1 && y == 1) {

				animator.SetInteger ("direction", 8);

			}

		if (x == 1 && y == 0) {

				animator.SetInteger ("direction", 6);


			}
		if (x == 1 && y == -1) {

				animator.SetInteger ("direction", 2);

			}
		if (x == -1 && y == 1) {

				animator.SetInteger ("direction", 8);

			}
		if (x == -1 && y == 0) {

			animator.SetInteger ("direction", 4);

		}		
		if (x == -1 && y == -1) {

			animator.SetInteger ("direction", 2);

		}
		if (x == -1 && y == -1) {

			animator.SetInteger ("direction", 2);

		}
		if (x == 0 && y == -1) {

			animator.SetInteger ("direction", 2);

		}
		if (x == 0 && y == 1) {

			animator.SetInteger ("direction", 8);

		}


	}
}