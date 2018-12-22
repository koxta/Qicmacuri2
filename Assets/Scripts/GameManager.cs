using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject FirstGameObject;
    public GameObject SecondGameObject;

    public Camera camera1;
    public Camera camera2;

    Character c1,c2;

    private void Start()
    {
        c1 = FirstGameObject.GetComponent<Character>();
        c2 = SecondGameObject.GetComponent<Character>();

        //////////////////////////////////////////////

        camera1.enabled = true;
        camera2.enabled = false;

        c1.enabled = true;
        c2.enabled = false;
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
    
}
