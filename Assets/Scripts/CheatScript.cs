using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CheatScript : MonoBehaviour {

	bool cheat_enabled=false;
	bool buttons=false;
	bool cPressed=false;
	bool ctrlPressed=false;
	bool audioPlaying;
	string input="";
	Color cheatColor=new Color(52,60,99);
	float jumpHeight;
	float orgSpeed;
	float orgForce;
	float orgFlySpeed;
	float orgWalkSpeed;
	float orgSprintSpeed;
	int sinCounter;
	bool flying;

	public AudioSource flySong;
	public AudioSource sonicSong;

	public GameObject player;
	public GameObject mesh;
	public Material pinkMaterial;
	public Material blueMaterial;
	public GameObject hat;
	public GameObject tomb;
	public AudioSource mainTheme;

	public GUIStyle cheatStyle;

	void Start(){
		audioPlaying=false;
		sinCounter=0;
		flying=false;
		jumpHeight=player.GetComponent<MoveBehaviour>().jumpHeight;
		orgSpeed=player.GetComponent<MoveBehaviour>().runSpeed;
		orgForce=player.GetComponent<MoveBehaviour>().jumpIntertialForce;
		orgFlySpeed=player.GetComponent<FlyBehaviour>().flySpeed;
		orgWalkSpeed = player.GetComponent<MoveBehaviour> ().walkSpeed;
		orgSprintSpeed = player.GetComponent<MoveBehaviour> ().sprintSpeed;

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

		if(ctrlPressed==true&&cPressed==true&&buttons==false){
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
			sinCounter=PlayerPrefs.GetInt("sinCounter",0);
			Debug.Log(sinCounter);
			GUI.backgroundColor=cheatColor;
			GUI.SetNextControlName("MyTextField");
			input=GUI.TextField(new Rect(110,30,Screen.width,30),input,300,cheatStyle);
			GUI.FocusControl("MyTextField");
			if (Event.current.keyCode==KeyCode.Return||Event.current.keyCode==KeyCode.KeypadEnter){
				cheat_enabled=false;
				if(input=="bigBoy"){
					player.transform.localScale+=new Vector3(1.0f,1.0f,1.0f);
					sinCounter++;
				}
				else if(input=="smallBoy"){
					player.transform.localScale-=new Vector3(1.0f,1.0f,1.0f);
					sinCounter++;
				}
				else if(input=="amyRose"){
					//mesh.GetComponent<Renderer>().material.SetColor("_Color",Color.magenta);
					mesh.GetComponent<Renderer>().material=pinkMaterial;
					hat.GetComponent<Renderer>().material=pinkMaterial;
					print("changed color");
					sinCounter++;
				}
				else if(input=="squirtle"){
					//mesh.GetComponent<Renderer>().material.SetColor("_Color",Color.magenta);
					mesh.GetComponent<Renderer>().material=blueMaterial;
					hat.GetComponent<Renderer>().material=blueMaterial;
					print("changed color");
					sinCounter++;
				}
				else if(input=="reverseGravity"){
					Physics.gravity=-Physics.gravity;
					player.transform.localScale-=new Vector3(0f,player.transform.localScale.y*2,0f);
					player.transform.position+=new Vector3 (0f,3f,0f);
					sinCounter++;
				}
				else if(input=="superMario64"){
					player.GetComponent<FlyBehaviour>().flyCode=true;
					sinCounter+=3;
					flying=!flying;
					if(audioPlaying==true){
						flySong.Stop();
						sonicSong.Stop();
						mainTheme.Play();
						audioPlaying=false;
					}
					if(flying){
						flySong.Play();
						mainTheme.Stop();
						audioPlaying=true;
					}
				}
				else if(input=="sonicTheHedgehog"){
					if(player.GetComponent<MoveBehaviour>().runSpeed!=2f){
						player.GetComponent<MoveBehaviour> ().walkSpeed = 2f;
						player.GetComponent<MoveBehaviour>().runSpeed=2f;
						player.GetComponent<MoveBehaviour> ().sprintSpeed = 2f;
						player.GetComponent<MoveBehaviour>().jumpIntertialForce=20f;
						player.GetComponent<FlyBehaviour>().flySpeed=20f;
						sinCounter++;
						if(audioPlaying==true){
							flySong.Stop();
							sonicSong.Stop();
							mainTheme.Play();
							audioPlaying=false;
						}
						sonicSong.Play();
						mainTheme.Stop();
						audioPlaying=true;
					}else{
						player.GetComponent<MoveBehaviour>().runSpeed=orgSpeed;
						player.GetComponent<MoveBehaviour>().jumpIntertialForce=orgForce;
						player.GetComponent<FlyBehaviour>().flySpeed=orgFlySpeed;
						player.GetComponent<MoveBehaviour> ().walkSpeed = orgWalkSpeed;
						player.GetComponent<MoveBehaviour> ().sprintSpeed = orgSprintSpeed;
						sonicSong.Stop();
						audioPlaying=false;
						mainTheme.Play();
					}
				}
				else if(input=="bigJump"){
					if(player.GetComponent<MoveBehaviour>().jumpHeight!=20f){
						player.GetComponent<MoveBehaviour>().jumpHeight=20f;
						sinCounter++;
					}else{
						player.GetComponent<MoveBehaviour>().jumpHeight=jumpHeight;
					}
				}
				else if(input=="biggerJump"){
					if(player.GetComponent<MoveBehaviour>().jumpHeight!=60f){
						player.GetComponent<MoveBehaviour>().jumpHeight=60f;
						sinCounter++;
					}else{
						player.GetComponent<MoveBehaviour>().jumpHeight=jumpHeight;
					}
				}
				else if(input=="catInTheHat"){
					hat.SetActive(!hat.activeInHierarchy);
					sinCounter++;
				}
				else if(input=="doors"){
					if(sinCounter<=10){
						tomb.GetComponent<Animator>().Play("doorsOpen");
					}
				}
				PlayerPrefs.SetInt("sinCounter",sinCounter);
			}

			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
		}
	}
}
