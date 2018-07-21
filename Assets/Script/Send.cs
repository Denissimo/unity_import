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
		Vector3 playerPosition = player.transform.position;
		Vector3 otherPortalPosition = otherPortal.transform.position;
		Vector3 portalPosition = portal.transform.position;
		Debug.Log(
			"portalPosition: x = " + portalPosition.x +
			",y = " + portalPosition.y + 
			",z = " + portalPosition.z 
		);

		Debug.Log(
			"otherPortalPosition: x = " + otherPortalPosition.x +
			",y = " + otherPortalPosition.y + 
			",z = " + otherPortalPosition.z 
		);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Debug.Log(
				"Player: x = " + player.transform.position.x +
				",y = " + player.transform.position.y + 
				",z = " + player.transform.position.z 
			);
		}
	}

	void OnTriggerEnter (Collider portalCollider) {

		Vector3 playerPosition = player.transform.position;
		Vector3 otherPortalPosition = otherPortal.transform.position;
		Vector3 portalPosition = portal.transform.position;
		Vector3 colliderPosition = portalCollider.transform.position;

		Quaternion playerRotation = player.transform.rotation;
		Quaternion otherPortalRotation = otherPortal.transform.rotation;
		Quaternion portalRotation = this.transform.rotation;


		//Vector3 distance = colliderPosition - playerPosition;
		Vector3 distance = playerPosition - portalPosition;

		Debug.Log(
			"distance: x = " + distance.x +
			",y = " + distance.y + 
			",z = " + distance.z 
		);

		Vector3 newPosition = otherPortalPosition + distance;

		player.transform.position = newPosition;

		Debug.Log(
			"Portal: x = " + portalPosition.x +
			",y = " + portalPosition.y + 
			",z = " + portalPosition.z 
		);


		Debug.Log(
			"Collider: x = " + colliderPosition.x +
			",y = " + colliderPosition.y + 
			",z = " + colliderPosition.z 
		);


		Debug.Log(
			"Player: x = " + playerPosition.x +
			",y = " + playerPosition.y + 
			",z = " + playerPosition.z 
		);



	}
}
