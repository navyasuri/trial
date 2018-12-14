using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour {

	AudioSource audioData;
	public bool play;
	bool play2;


    void Start()
    {
    	play=false;
    	play2=true;
        audioData = GetComponent<AudioSource>();
        Debug.Log("started");
    }

    void Update(){
    	if(play==true && play2==true){
    		audioData.Stop();
    		audioData.Play(0);
    		play2=false;
    	}else if(play==false && play2==false){
    		play2=true;
    	}
    }

}
