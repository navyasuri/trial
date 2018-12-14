using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterGame : MonoBehaviour {

	public AudioSource aud;
	[SerializeField]private string loadLevel;
	Animator m_Animator;
	float beginTime;

	// Use this for initialization
	void Start () {
		m_Animator = gameObject.GetComponent<Animator>();
		PlayerPrefs.SetInt("sinCounter",0);
		beginTime=0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Return)||Input.GetKeyUp(KeyCode.KeypadEnter)){
			aud.Play();
			beginTime=Time.time;
			m_Animator.Play("leavingTitle");
		}
		if(beginTime!=0f && Time.time-beginTime>=4.9f){
			SceneManager.LoadScene(loadLevel);
		}
	}
}
