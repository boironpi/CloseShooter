using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		// Affiche un bouton pour démarrer la partie
		if (
			GUI.Button(
				// Centré en x, 2/3 en y
				new Rect(
					Screen.width / 2 - (buttonWidth / 2),
					(2 * Screen.height / 3) - (buttonHeight / 2)-70,
					buttonWidth,
					buttonHeight
				),
				"Stage 1"
			)
		)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("Scene1");
		}

		if (
			GUI.Button(
				// Centré en x, 2/3 en y
				new Rect(
					Screen.width / 2 - (buttonWidth / 2),
					(2 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				),
				"Stage 2"
			)
		)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("Scene2");
		}

		if (
			GUI.Button(
				// Centré en x, 2/3 en y
				new Rect(
					Screen.width / 2 - (buttonWidth / 2),
					(2 * Screen.height / 3) - (buttonHeight / 2) +70 ,
					buttonWidth,
					buttonHeight
				),
				"Stage 3"
			)
		)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("Scene3");
		}


		if (
			GUI.Button(
				// Centré en x, 2/3 en y
				new Rect(
					Screen.width / 2 - (buttonWidth / 2),
					(2 * Screen.height / 3) - (buttonHeight / 2) +140 ,
					buttonWidth,
					buttonHeight
				),
				"Stage 4"
			)
		)
		{
			// Sur le clic, on démarre le premier niveau
			// "Stage1" est le nom de la première scène que nous avons créés.
			Application.LoadLevel("Scene4");
		}
}
}
