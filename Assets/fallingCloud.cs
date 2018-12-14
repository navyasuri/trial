using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingCloud : MonoBehaviour {

	float originY;
	float vel;

	public float fallingSpeed;

	public Transform cloud;
	public Transform player;
	public Rigidbody rb;
	// Use this for initialization
	void Start () {
		originY=cloud.position.y;
		vel=0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(cloud.position,player.position)>4){
			rb.velocity=new Vector3(0f,0.1f,0f);
			//print("have exited");
			vel=0.03f;
		}
		//print(Vector3.Distance(cloud.position,player.position));
		if (vel==0.03f && (cloud.position.y>=originY)){
			//rb.velocity=new Vector3(0f,0f,0f);
			vel=0f;
			//print("resetting");
		}
		cloud.position+=new Vector3(0f,vel,0f);
		//print(rb.velocity.y);
	}
	void OnCollisionEnter(Collision col){
		
		//rb.velocity=new Vector3(0f,-1f,0f);
		//print("have collided,");
		vel=-fallingSpeed;
		//print(rb.velocity.y);
	}

}
