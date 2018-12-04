using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheatScript : MonoBehaviour {

	bool cheat_enabled=false;
	bool buttons=false;
	bool cPressed=false;
	bool ctrlPressed=false;
	string input="";
	Color cheatColor=new Color(52,60,99);

	public GameObject player;
	public GameObject mesh;
	public Material pinkMaterial;

	public GUIStyle cheatStyle;

	void Start(){

	}

	void Update () {
		if(Input.GetKeyDown("c")){
			cPressed=true;
		}else if(Input.GetKeyUp("c")){
			cPressed=false;
		}
		if(Input.GetKeyDown(KeyCode.RightControl)||Input.GetKeyDown(KeyCode.LeftControl)){
			ctrlPressed=true;
		}else if(Input.GetKeyUp(KeyCode.RightControl)||Input.GetKeyUp(KeyCode.LeftControl)){
			ctrlPressed=false;
		}

		if(cPressed==true&&ctrlPressed==true&&buttons==false){
			input="";
			if(cheat_enabled==true){
				cheat_enabled=false;
			}else{
				cheat_enabled=true;
			}
			buttons=true;
		}
		if(cPressed==false||ctrlPressed==false){
			buttons=false;
		}
	}

	void OnGUI() {
		if(cheat_enabled==true){
			GUI.backgroundColor=cheatColor;
			GUI.SetNextControlName("MyTextField");
			input=GUI.TextField(new Rect(2,0,Screen.width,30),input,300,cheatStyle);
			GUI.FocusControl("MyTextField");
			if (Event.current.keyCode==KeyCode.Return||Event.current.keyCode==KeyCode.KeypadEnter){
				cheat_enabled=false;
				if(input=="bigBoy"){
					player.transform.localScale+=new Vector3(1.0f,1.0f,1.0f);
				}
				else if(input=="amyRose"){
					//mesh.GetComponent<Renderer>().material.SetColor("_Color",Color.magenta);
					mesh.GetComponent<Renderer>().material=pinkMaterial;
					print("changed color");
				}
				else if(input=="reverseGravity"){
					Physics.gravity=-Physics.gravity;
					player.transform.localScale-=new Vector3(0f,player.transform.localScale.y*2,0f);
					player.transform.position+=new Vector3 (0f,3f,0f);
				}
				else if(input=="superMario64"){
					player.GetComponent<FlyBehaviour>().flyCode=true;
				}
			}
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
		}
	}
}
