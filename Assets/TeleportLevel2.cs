using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportLevel2 : MonoBehaviour {

	public string teleportTo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collider col){
		if (col.tag == "Player") {
			teleport ();
		}
	}

	IEnumerator teleport(){
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (teleportTo);
	}
}
