﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.instance.gameOver)
            rb2d.velocity = Vector2.zero;

        else if (GameController.instance.score >= GameController.instance.nextLevel)
        {
            GameController.instance.nextLevel *= 2;
            //GameController.instance.scrollSpeed -= 0.05f;
            //rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
            SoundSystem.instance.audioSourceMusic.pitch += 0.01f;
        }

    }


}