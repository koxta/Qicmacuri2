using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float speed;
    public float upForce;

    public Dialogue dialogue;



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

 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(this.name == "RedDude" && collision.gameObject.tag == "dropable")
        {
            Counter.dropCount -= 1;
        }
        if(this.name == "BlueDude" && collision.gameObject.tag == "dropable")
        {
            Counter.dropCount -= 1;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.name == "RedDude" && collision.gameObject.tag == "dropable")
        {
            Counter.dropCount += 1;
        }
        if(this.name == "BlueDude" && collision.gameObject.tag == "dropable")
        {
            Counter.dropCount += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.name == "BoxCollider")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        if(collision.name== "MOG_Trigger")
        {
            if(!Counter.MOG_Dialog)
            {
                Counter.MOG_Dialog = true;
                ShowMogDialog();
            }
        }

        Vector3 newMetro = new Vector3(132.87f,10.6f,0);

        if(collision.name=="MetroTrigger")
        {
            if(this.name=="RedDude")
            {
                transform.position = newMetro;
                GameObject.Find("BlueDude").transform.position = newMetro;
            }
            if(this.name=="BlueDude")
            {
                transform.position = newMetro;
                GameObject.Find("RedDude").transform.position = newMetro;
            }
        }
    }


    private void ShowMogDialog()
    {
        Debug.Log("d");
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
