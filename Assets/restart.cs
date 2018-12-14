using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	public string titleScreen;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("r")){
			GetComponent<Animator>().Play("fadeOutEnd");
			StartCoroutine("ttScreen");
		}
	}

	IEnumerator ttScreen(){
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (titleScreen);
	}
}
