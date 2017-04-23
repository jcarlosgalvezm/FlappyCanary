using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    bool isDead = false;
    Rigidbody2D rb2d;
    public float upForce = 200f;
    Animator anim;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
        else if (Input.GetMouseButtonDown(0) && !GameController.instance.gamePaused){
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * upForce);
            anim.SetTrigger("Flap");
            SoundSystem.instance.PlayFlap();
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        isDead = true;
        anim.SetTrigger("Die");
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayHit();
        GameController.instance.BirdDie();
    }

}
