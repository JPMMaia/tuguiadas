using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			if(this.transform.childCount == 0)
				SceneManager.LoadScene("Default");//switch scene
			else
				Destroy(this.transform.GetChild(this.transform.childCount - 1).gameObject);
		}
	}
}
