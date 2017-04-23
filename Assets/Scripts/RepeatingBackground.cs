using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLenght;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start () {
        groundHorizontalLenght = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        groundHorizontalLenght = groundCollider.size.x;

        if (transform.position.x <= -groundHorizontalLenght)
        {
            RepositionBackground();
        }
	}

    void RepositionBackground()
    {
        transform.Translate(Vector2.right * (groundHorizontalLenght*2));
    }
}
