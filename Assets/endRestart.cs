using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endRestart : MonoBehaviour {

	public string titleScreen;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		SceneManager.LoadScene (titleScreen);
	}
}
