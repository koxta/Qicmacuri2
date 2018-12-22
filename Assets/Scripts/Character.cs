using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float speed;
    public float upForce;

    Animator animator;
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody;

	void Start () {

        speed = 3f;
        upForce = 5f;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="door")
        {
          //  Transpose();
        }
    }

    void Update () {
        Vector3 move =new Vector3(Input.GetAxis("Horizontal"),0, 0);
        transform.position += move * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow))
        { 
            spriteRenderer.flipX = true;
            animator.SetBool("walk", true);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("walk", false);
            rigidbody.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("walk", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("walk", false);
        }
        
    }
}
