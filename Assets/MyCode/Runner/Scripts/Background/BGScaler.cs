using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// calculate the height of the screen
		float height = Camera.main.orthographicSize * 2f;
		//Debug.Log("Height: " + height);

		// make the width honor the aspect ratio of the device.
		//float aspectRatio = Screen.width / Screen.height;
		//Debug.Log("Screen Width: " + Screen.width + "; Screen height: " + Screen.height + "; Aspect Ratio: " + aspectRatio);

		float width = height * Screen.width / Screen.height;
		//float width = height * aspectRatio;
		//Debug.Log("Calc Width: " + width);

		// Resize the background.
		if (gameObject.name == "Background") {

			transform.localScale = new Vector3(width, height, 0f);

		}

		if (gameObject.name == "MeditationBG") {

			transform.localScale = new Vector3(width+width , height+height , 0f);

		}


		// Scale and position the Ground;  Add more on width to trigger colliders
		if (gameObject.name == "Ground") {

			transform.localScale = new Vector3(width + 3f, 5f, 0f);

		}



	}


}
