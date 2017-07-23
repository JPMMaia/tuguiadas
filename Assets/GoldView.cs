using Core;
using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;
using UnityEngine.UI;

public class GoldView : Entity {

    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var playerState = FindObjectOfType<PlayerState>();
        text.text = playerState.CurrentMoney.ToString();
	}
}
