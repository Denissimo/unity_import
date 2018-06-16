using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public GameObject player;

	public GameObject sphere;

	public GameObject portal1;
	public GameObject portal2;
	public GameObject rotatedPortal1;
	public GameObject rotatedPortal2;
	public GameObject baida;

	public GameObject cube;

	public Camera camera1;
	public Camera camera2;
	public Quaternion quatPortal = Quaternion.Euler(0, 0, 0);
	public Quaternion quatCamera = Quaternion.Euler(90, 0, 0);
	public Quaternion quatBaidaX;
	public Quaternion quatBaidaY;
	public Quaternion quatBaidaZ;
	public Quaternion baidaRot;

	float degPerTime1;
	float degPerTime2;

	float baiX = .3F;
	float baiY = .3F;
	float baiZ = .3F;

	// Use this for initialization
	void Start () {
		//transform.position = new Vector3 (100, 100, 100);
		Debug.Log (portal1.transform.localScale.x);
		baidaRot = baida.transform.rotation;

		//Ray ray = new Ray (portal1.transform.position, 2);

	}
	
	// Update is called once per frame
	void Update () {


        quatBaidaX = Quaternion.AngleAxis(baiX++, Vector3.right);
        quatBaidaY = Quaternion.AngleAxis(baiY++, Vector3.up);
        quatBaidaZ = Quaternion.AngleAxis(baiZ++, Vector3.forward);

        baida.transform.rotation = baidaRot * quatBaidaX * quatBaidaY * quatBaidaZ;

		rot ();

		Vector3 playerPosition = player.transform.position;
		Vector3 portalPosition1 = portal1.transform.position;
		Vector3 portalPosition2 = portal2.transform.position;

		Quaternion playerRotation = player.transform.rotation;
		Quaternion portalRotation1 = portal1.transform.rotation;
		Quaternion portalRotation2 = portal2.transform.rotation;

//		Vector3 distance1 = portalPosition1 - playerPosition;
//		Vector3 distance2 = portalPosition2 - playerPosition;

		Vector3 distance1 = playerPosition - portalPosition1;
		Vector3 distance2 = playerPosition - portalPosition2;

		Vector3 distance0 = playerPosition - portalPosition1;

		//cube.transform.position = portalRotation1 * distance0;
		//cube.transform.position = (portalPosition1 - portalRotation1 * distance1);

		camera1.transform.position = (portalPosition2 + portalRotation2 * portalRotation1 * distance1);
		camera2.transform.position = (portalPosition1 + portalRotation1 * portalRotation2 * distance2);

		//camera1.transform.position = (portalPosition2 + distance1);
		//camera2.transform.position = (portalPosition1 + distance2);

		camera1.transform.rotation =  portalRotation1 * portalRotation2 * playerRotation;
		float near1 = distance1.magnitude - 1;
		if (near1 < 0.01F) {
			near1 = 0.01F;
		}
		camera1.nearClipPlane = near1;
//		camera1.transform.Rotate(0, 180, 0);

		camera2.transform.rotation = portalRotation2 * portalRotation1 * playerRotation;
		float near2 = distance2.magnitude - 1;
		if (near2 < 0.01F) {
			near2 = 0.01F;
		}
		camera2.nearClipPlane = near2;
//		camera2.transform.Rotate(0, 180, 0);

		//camera1.transform.rotation

		//Debug.Log (distance2);
	}

	void rot()
	{
		float rotPerSec1 = .00F;
		float degPerSec1 = 360 * rotPerSec1;

		float rotPerSec2 = .00F;
		float degPerSec2 = 360 * rotPerSec2;

		degPerTime1 = degPerSec1 * Time.deltaTime;
		degPerTime2 = degPerSec2 * Time.deltaTime;

		rotatedPortal1.transform.Rotate(0, degPerTime1, 0);
		rotatedPortal2.transform.Rotate(0, degPerTime2, 0);
		//Debug.Log (degPerTime);
	}
}
