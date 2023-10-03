using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool isOnGround = false;
    public float gravityValue = -10.0f;
    private float jumpHeight = 2f;
    private int jumpCount = 0;

    public float walkSpeed = 3;
    public float runSpeed = 8; 
    private CharacterController controller;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    void LateUpdate()
    {
        ProcessMovement();
    }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }
    void UpdateAnimator()
    {
        isOnGround = controller.isGrounded; 
        // TODO 
        Vector3 characterXandZmotion = new Vector3(playerVelocity.x,0.0f,playerVelocity.z);
        if(Mathf.Abs(Input.GetAxis("Horizontal"))>0.0f || Mathf.Abs(Input.GetAxis("Vertical"))>0.0f){
            if(Input.GetButton("Fire3")){//Left Shift
                animator.SetFloat("Speed",1.0f);
            }else{
                animator.SetFloat("Speed",0.5f);
            }
        }else{
            animator.SetFloat("Speed",0.0f);
        }
        if(Input.GetButtonUp("Fire1")){
            animator.applyRootMotion = true; 
        }
        animator.SetBool("IsGrounded",isOnGround);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

    void ProcessMovement()
    {  
        // Moving the character foward according to the speed
        float speed = GetMovementSpeed();

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Turning the character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity =  move * Time.deltaTime * speed;
        // Making sure we dont have a Y velocity if we are grounded
        // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
       
        // Since there is no physics applied on character controller we have this applies to reapply gravity
        
        isOnGround = controller.isGrounded; 
        Vector3 movement = move.normalized * speed * Time.deltaTime;
         
        if (isOnGround)
        {
            
            if (Input.GetButtonDown("Jump"))
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                jumpCount = 1;
            }
            else
            {
                // Dont apply gravity if grounded and not jumping
                jumpCount = 0;
                gravity.y = -1.0f;
            }
        }
        else
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            if(jumpCount == 1){
                if (Input.GetButtonDown("Jump"))
                {
                    gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue); 
                    jumpCount = 0;
                }
            }
            gravity.y += gravityValue * Time.deltaTime;
        }
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);

    }

    
}
