using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnClouds : MonoBehaviour {

	public GameObject player;

	Vector3 respawnArea;
	Vector3[] vectors;

	int respawnLvl;

	void Start(){
		respawnLvl=1;
		vectors[1]=new Vector3(115f,48.2f,18f);
		vectors[2]=new Vector3(97f,49f,137f);
		vectors[3]=new Vector3(45f,59.2f,117f);
		vectors[4]=new Vector3(-165f,72.92f,201.7f);
		respawnArea=new Vector3(115f,48.6f,18f);
	}

	// Update is called once per frame
	void Update () {
		if(respawnLvl==1){
			respawnArea=new Vector3(115f,48.6f,18f);
		}
		if(player.transform.position.z>=133){
			if(player.transform.position.x<=55){
				if(player.transform.position.y>=70){
					if (respawnLvl==3){
						respawnLvl++;
						respawnArea=new Vector3(-165f,72.92f,201.7f);
					}
				}else{
					if(respawnLvl==2){
						respawnLvl++;
						respawnArea=new Vector3(45f,59.9f,170f);
					}

				}
			}
			else{
				if(respawnLvl==1){
					respawnLvl++;
					respawnArea=new Vector3(97f,49f,137f);
				}
			}
		}
		if(player.transform.position.y<0){
			print(respawnArea);
			player.transform.position=respawnArea;
		}
	}
}
