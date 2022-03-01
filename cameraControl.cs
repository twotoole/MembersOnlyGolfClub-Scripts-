using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
//float speed = 75f;
public GameObject ball;
 
 void Update() {
    transform.RotateAround(ball.transform.position, Vector3.up ,Input.GetAxis("Horizontal"));
 }

}
