﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
	static public FollowCam S;
	public float easing = 0.05f;
	public Vector2 minXY;
	public bool _________________________________;

	public GameObject poi;
	public float camZ;

	void Awake () {
		S = this;
		camZ = this.transform.position.z;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 destination;
		if (poi == null) {
			destination = Vector3.zero;
		} else {
			destination = poi.transform.position;
			if (poi.tag == "Projectile") {
				if (poi.GetComponent<Rigidbody> ().IsSleeping ()) {
					poi = null;
					return;
				}
			}
		}

		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);
		destination = Vector3.Lerp (transform.position, destination, easing);
		destination.z = camZ;
		transform.position = destination;
		this.GetComponent<Camera> ().orthographicSize = destination.y + 10;
	}
}
