using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour {

	public GameObject portal;
	public GameObject otherPortal;
	public GameObject player;
	public GameObject dummy;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter (Collider portalCollider) {

		Vector3 playerPosition = player.transform.position;
		Vector3 otherPortalPosition = otherPortal.transform.position;
		Vector3 portalPosition = portal.transform.position;

		Quaternion playerRotation = player.transform.rotation;
		Quaternion otherPortalRotation = otherPortal.transform.rotation;
		Quaternion portalRotation = this.transform.rotation;


		Vector3 distance = portalPosition - playerPosition;
		Vector3 newPosition = otherPortalPosition + distance;

		player.transform.position = newPosition;
		Debug.Log(player.transform.position.x);

	}
}
