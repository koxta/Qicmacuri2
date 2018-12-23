using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] dropableArr;

    public GameObject FirstGameObject;
    public GameObject SecondGameObject;

    public Camera camera1;
    public Camera camera2;

    Character c1,c2;

    private void Start()
    {



        c1 = FirstGameObject.GetComponent<Character>();
        c2 = SecondGameObject.GetComponent<Character>();

        Physics2D.IgnoreCollision(FirstGameObject.GetComponent<Collider2D>(), SecondGameObject.GetComponent<Collider2D>(), true);
        //////////////////////////////////////////////

        camera1.enabled = true;
        camera2.enabled = false;

        c1.enabled = true;
        c2.enabled = false;

        /////
        ///







    }


    void Update () {
        if(Input.GetKeyDown(KeyCode.B))
        {
            FocusToBoth();
        }
		if(Input.GetKeyDown(KeyCode.V))
        {
            FocusToSecond();
        }


        if(Counter.dropCount == 2) Collapse();
       

    }


    private void FocusToBoth()
    {
        c1.enabled = true;
        c2.enabled = true;
    }

    public void FocusToSecond()
    {
        if(c1.enabled&&c2.enabled)
        {
            c1.enabled = true;
            camera1.enabled = true;

            c2.enabled = false;
            camera2.enabled = false;
        }
        else
        {
            c1.enabled = !c1.enabled;
            c2.enabled = !c2.enabled;

            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }

    public GameObject drop;
    private void Collapse()
    {
        GameObject.Destroy(drop);

        for(int i=0;i<7;i++)
        {
            dropableArr[i].AddComponent<Rigidbody2D>();
        }

        StartCoroutine(destDropables());


        camera1.backgroundColor = ConvertColor(84, 78, 78);
        camera2.backgroundColor = ConvertColor(84, 78, 78);
    }

    private Color ConvertColor(int r, int g, int b)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }

    private IEnumerator destDropables()
    {
        yield return new WaitForSeconds(1);

        for(int i = 0; i < 7; i++)
        {
            Destroy(dropableArr[i]);
        }
    }

}
