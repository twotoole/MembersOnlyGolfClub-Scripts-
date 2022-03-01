using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelControl : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;

    public int swingCount = 0;

    public GameObject _camera;
    public GameObject golfer;

    public Vector3 arrowOffset;
    public Vector3 offset;

    public GameObject ball;
    public GameObject arrow;
    public Rigidbody ballRB;

    private bool isMoving;

    public float speed = 0.01f;
    private int phase = 0;
    private float height = 0f;
    private float power = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVelocity();
        MoveGolfer();
        SwingPhase();
        ChangeSprite();
        ArrowControl();
    }
    
      void FixedUpdate()
      {

        if (phase == 0)
        {
            height = 0;
            power = 0;
        }
        if(phase == 1)
        {
            if(height > 90)
            {
                speed = -speed;
            }
            if(height < 0)
            {
                speed = -speed;
            }
            height += speed;
        
        }

        if(phase == 2)
        {
            if(power > 50)
            {
                speed = -speed;
            }
            if(power < 0)
            {
                speed = -speed;
            }
            power += speed;
           
        }

        if(phase == 3)
        {
            swingCount++;
            Vector3 hit = CameraPosition()+new Vector3(0f, height, 0f);
            hit.Normalize();
            ball.GetComponent<Rigidbody>().AddForce(hit*power, ForceMode.Impulse);
            phase++;

            float x = arrow.transform.eulerAngles.x;
            float y = arrow.transform.eulerAngles.y;
            float z = arrow.transform.eulerAngles.z;

            arrow.transform.eulerAngles = new Vector3(-90, y, z);
        }

        
    }

    public void SwingPhase()
    {
        if(isMoving == false)
        {
            if (phase > 3)
            {
                phase = 0;
            }

            if (Input.GetKeyDown("space"))
            {
                phase += 1;
            }
        }
    }



    void ArrowControl()
    {
        arrow.transform.RotateAround(transform.position, Vector3.up ,Input.GetAxis("Horizontal"));
        if(phase == 1)
        {
            arrow.transform.Rotate(-speed, 0, 0);  
        }      
        arrow.transform.localScale = new Vector3(15f, 10+power, 1);
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Hole")
        { 
            Debug.Log("Hole.");
        }
    }

    void CalculateVelocity()
    {

        if(ballRB.velocity == Vector3.zero)
        {
            isMoving = false;
            arrow.SetActive(true);
        }
        if(ballRB.velocity != Vector3.zero)
        {
            isMoving = true;
            arrow.SetActive(false);
        }
    }

    void MoveGolfer()
    {
        if(isMoving == false)
        {
            golfer.transform.position = ball.transform.position + offset;
            arrow.transform.position = ball.transform.position + arrowOffset;
        }
    }

    public Vector3 CameraPosition()
    {
        Vector3 diff;
        diff = ball.transform.position - _camera.transform.position;
        return diff;
    }

    void ChangeSprite()
    {
        if(phase == 0 || phase == 1 || phase == 3)
        {
            spriteRenderer.sprite = sprite1; 
        }
        if(phase == 2)
        {
            spriteRenderer.sprite = sprite2; 
        }
        
    }
}
