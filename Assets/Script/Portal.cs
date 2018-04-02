using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public GameObject player;

	public GameObject sphere;

	public GameObject portal1;
	public GameObject portal2;
	public GameObject rotatedPortal;
	public GameObject baida;

	public GameObject cube;

	public Camera camera1;
	public Camera camera2;
	public Quaternion quatPortal = Quaternion.Euler(-90, 0, 180);
	public Quaternion quatCamera = Quaternion.Euler(90, 0, 0);
	public Quaternion quatBaidaX;
	public Quaternion quatBaidaY;
	public Quaternion quatBaidaZ;
	public Quaternion baidaRot;

	float degPerTime;

	float baiX = .3F;
	float baiY = .3F;
	float baiZ = .3F;

	// Use this for initialization
	void Start () {
		//transform.position = new Vector3 (100, 100, 100);
		Debug.Log ("ZZZZZ");
		baidaRot = baida.transform.rotation;

		//Ray ray = new Ray (portal1.transform.position, 2);

	}
	
	// Update is called once per frame
	void FixedUpdate () {


        quatBaidaX = Quaternion.AngleAxis(baiX++, Vector3.right);
        quatBaidaY = Quaternion.AngleAxis(baiY++, Vector3.up);
        quatBaidaZ = Quaternion.AngleAxis(baiZ++, Vector3.forward);

        baida.transform.rotation = baidaRot * quatBaidaX * quatBaidaY * quatBaidaZ;

		rot ();

		Vector3 playerPosition = player.transform.position;
		Vector3 portalPosition1 = portal1.transform.position;
		Vector3 portalPosition2 = portal2.transform.position;

		Quaternion playerRotation = player.transform.rotation;
		Quaternion portalRotation1 = portal1.transform.rotation * quatPortal;
		Quaternion portalRotation2 = portal2.transform.rotation * quatPortal;

		Vector3 distance1 = portalPosition1 - playerPosition;
		Vector3 distance2 = portalPosition2 - playerPosition;

		Vector3 distance0 = playerPosition - portalPosition1;

		//cube.transform.position = portalRotation1 * distance0;
		//cube.transform.position = (portalPosition1 - portalRotation1 * distance1);

		camera1.transform.position = (portalPosition2 + portalRotation2 * distance1);
		camera2.transform.position = (portalPosition1 + portalRotation1 * distance2);

		camera1.transform.rotation = playerRotation;
		camera1.transform.Rotate(0, 180, 0);

		camera2.transform.rotation = playerRotation;
		camera2.transform.Rotate(0, 180, 0);

		//camera1.transform.rotation

		//camera1.transform.LookAt (portal2.transform.position);
		//camera2.transform.LookAt (portal1.transform.position);
		//Debug.Log (distance2);
	}

	void rot()
	{
		float rotPerSec = .01F;
		float degPerSec = 360 * rotPerSec;
		degPerTime = degPerSec * Time.deltaTime;

		rotatedPortal.transform.Rotate(0, 0, degPerTime);
		//Debug.Log (degPerTime);
	}
}
