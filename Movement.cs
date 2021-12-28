using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
//using UnityEngine.Animations.Rigging;

public class Movement : MonoBehaviour
{
    CharacterController controller;


    public Transform cam;
   // public Vector3 off;

    public float speed = 5f;
    public float acceleration = 1f;
    public float smoothTime = 0.1f;
    public float jumpSpeed;
    public ThirdPersonOrbitCamBasic camScript;
   // public Weapon_manager wap_man;
    float smooth, c_speed, xv, yv, tmp = 5f;
    private float ySpeed, originalStepOffset;

    Animator anim;


    Vector3 movdir;

    private void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        originalStepOffset = controller.stepOffset;
        c_speed = 0f;
        xv = yv = 0f;
        anim = GetComponent<Animator>();
        
        
        
       // wap_man.id_change(id);
    }

    private void LateUpdate()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
       
        movement();
       
        anim.SetFloat("speed", c_speed);
        anim.SetBool("grounded", controller.isGrounded);

        //anim.SetBool("firing", firing);
        //anim.SetInteger("id", id);
        //anim.SetFloat("x", xv);
        // anim.SetFloat("y", yv);
        //camScript.aiming = aiming;

        ySpeed += Physics.gravity.y * Time.deltaTime;
        
        if (controller.isGrounded)
        {
            
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                anim.Play("jump");
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            controller.stepOffset = 0;
        }


        if(Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.TransformDirection(Vector3.forward), out hit, 3f))
            {
                if(hit.collider.tag == "movable")
                {
                    hit.rigidbody.AddForce(300f * transform.forward);
                }
            }
        }


    }

    

    

    void movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x > 0)
        {
            if (xv < 1f) xv += tmp * Time.deltaTime;
        }
        else if (x < 0)
        {
            if (xv > -1f) xv -= tmp * Time.deltaTime;
        }
        else
        {
            if (xv > 0) xv -= tmp * Time.deltaTime;
            if (xv < 0) xv += tmp * Time.deltaTime;
            if (Mathf.Abs(xv - 0) < 0.1f) xv = 0;
        }

        if (y > 0)
        {
            if (yv < 1f) yv += tmp * Time.deltaTime;
        }
        else if (y < 0)
        {
            if (yv > -1f) yv -= tmp * Time.deltaTime;
        }
        else
        {
            if (yv > 0) yv -= tmp * Time.deltaTime;
            if (yv < 0) yv += tmp * Time.deltaTime;
            if (Mathf.Abs(yv - 0) < 0.1f) yv = 0;
        }

        Vector3 dir = new Vector3(x, 0f, y).normalized;
        if (dir.magnitude >= 0.1f)
        {
            
            if (c_speed < speed) c_speed += Time.deltaTime * acceleration;
                //if ((aiming || firing) && c_speed > aim_speeds) c_speed = aim_speeds;
            
            
            float tarAng = cam.eulerAngles.y +  Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tarAng, ref smooth, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            movdir = Quaternion.Euler(0f, tarAng, 0f) * Vector3.forward;
        }
        else if(dir.magnitude < 0.1f)
        {
            if (c_speed > 0f) c_speed -= Time.deltaTime * acceleration;
            else if (c_speed < 0f) c_speed = 0f;
        }
        


       // if (c_speed > 0f)
        {
            Vector3 val = movdir.normalized * c_speed;
            val.y = ySpeed;
            controller.Move(val * Time.deltaTime);
        }
    }
}
