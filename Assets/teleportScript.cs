using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportScript : MonoBehaviour {

	public string teleportTo;
	public GameObject canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			print("gonna teleport");
			canvas.GetComponent<Animator>().Play("fadeOut");
			StartCoroutine("teleport");
		}
	}

	IEnumerator teleport(){
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene (teleportTo);
	}
}