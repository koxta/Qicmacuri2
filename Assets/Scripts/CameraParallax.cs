using UnityEngine;
using System.Collections;

public class CameraParallax : MonoBehaviour
{
    public Transform Cam;
    Vector2 LastCamPos;
    Vector2 Diff = new Vector2(0, 0);
    public float Speed;
    Vector2 Move;


    void Start()
    {

        LastCamPos = Cam.position;
    }


    void Update()
    {
        Diff.x = ( LastCamPos.x - Cam.position.x ) * Speed;

        Move = new Vector2(Diff.x, Diff.y);

        Move = Move * Time.deltaTime;

        transform.Translate(Move);

        LastCamPos = Cam.position;
    }
}