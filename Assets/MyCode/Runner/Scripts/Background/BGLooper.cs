using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

	// Scroll speed
	public float scrollSpeed = 0.1f;

	// Offset of Texture
	private Vector2 offset = Vector2.zero;

	// We will need the material to get offset
	private Material material;


	// Use this for initialization
	void Start () {

		material = GetComponent<Renderer>().material;

		// get starting texture offset value;
		offset = material.GetTextureOffset("_MainTex");


	}
	
	// Update is called once per frame
	void Update () {

		// increment new offset value;
		offset.x += scrollSpeed * Time.deltaTime;

		// set offset
		material.SetTextureOffset("_MainTex", offset);

	}
}
