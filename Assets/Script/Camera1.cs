using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour {

	public GameObject player;
	public GameObject portal;
	public GameObject portal2;
	public GameObject cam3;
	public GameObject sphere;
	public Camera cam_3;
	public float cam_3_FoV = 10;
	public float anglePl_Po;
	public float distance;
	public float portalSize;
	public float rad = 180 / 3.14F;


	public Vector3 v1;

	// Use this for initialization
	void Start () {
		portalSize = portal.transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {
		v1 =  player.transform.position - portal.transform.position;
		distance = Vector3.Distance (player.transform.position, portal.transform.position);
		sphere.transform.position = portal2.transform.position + v1;
		cam3.transform.LookAt (portal2.transform.position);
		anglePl_Po = Vector3.Angle (cam3.transform.forward, portal2.transform.forward);

		cam_3_FoV = 2 * Mathf.Atan (portalSize / (2 * distance)) * rad *  Mathf.Abs( Mathf.Cos (anglePl_Po/rad));
		//cam_3_FoV = Mathf.Atan (0.57F)*180/3.14F;// * Mathf.Cos (anglePl_Po);
		cam_3.fieldOfView = cam_3_FoV;


		//Debug.Log (player.transform.position);
	}
}
