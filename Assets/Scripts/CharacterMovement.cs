using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool isOnGround = true;
    public static bool canDoubleJump = false;
    public float gravityValue = -9.81f;
    public float mouseSensitivy = 5.0f;
    private float jumpHeight = 1.5f;
    public float speed = 5.0f;

    public float walkSpeed = 3;
    public float runSpeed = 8; 
    private CharacterController controller;
    Animator animator;

    bool hasJumped = false;
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
        UpdateRotation();
        Moving();
    }

    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivy, 0, Space.Self);
 
    }

    void Moving(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 verticalMovement = transform.forward * verticalInput;
        Vector3 horizontalMovement = transform.right * horizontalInput;

        transform.position = transform.position + (verticalMovement + horizontalMovement)* speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, mouseX, 0));
    }

    void LateUpdate()
    {
        UpdateAnimator();
    }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }
    void UpdateAnimator()
    {
        isOnGround = controller.isGrounded; 
        
        Vector3 characterXandZmotion = new Vector3(playerVelocity.x,0.0f,playerVelocity.z);
        if(Mathf.Abs(Input.GetAxis("Horizontal"))>0.0f || Mathf.Abs(Input.GetAxis("Vertical"))>0.0f){
            if(Input.GetButton("Fire3")){//Left Shift
                animator.SetFloat("Speed",1.0f);
            }else{
                animator.SetFloat("Speed",0.5f);
            } 
        }else{
            animator.SetFloat("Speed",0f);
        }
       
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
    //    // Moving the character foward according to the speed
    //     float speed = GetMovementSpeed();

    //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //     // Turning the character
    //     if (move != Vector3.zero)
    //     {
    //         gameObject.transform.forward = move;
    //     }

    //     playerVelocity =  move * Time.deltaTime * speed;
    //     // Making sure we dont have a Y velocity if we are grounded
    //     // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
       
    //     // Since there is no physics applied on character controller we have this applies to reapply gravity
        
    //     isOnGround = controller.isGrounded; 
    //     Vector3 movement = move.normalized * speed * Time.deltaTime;
         
    //     if (isOnGround)
    //     {
            
    //         if (Input.GetButtonDown("Jump"))
    //         {
    //             gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //             jumpCount = 1;
    //         }
    //         else
    //         {
    //             // Dont apply gravity if grounded and not jumping
    //             jumpCount = 0;
    //             gravity.y = -1.0f;
    //         }
    //     }
    //     else
    //     {
    //         // Since there is no physics applied on character controller we have this applies to reapply gravity
    //         if(jumpCount == 1){
    //             if (Input.GetButtonDown("Jump"))
    //             {
    //                 gravity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue); 
    //                 jumpCount = 0;
    //             }
    //         }
    //         gravity.y += gravityValue * Time.deltaTime;
    //     }
    //     playerVelocity = gravity * Time.deltaTime + movement;
    //     controller.Move(playerVelocity);

        float speed = GetMovementSpeed();
 
        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
 
        // Make sure to flatten the vectors so that they don't contain any vertical component
        cameraForward.y = 0;
        cameraRight.y = 0;
 
        // Normalize the vectors to ensure consistent speed in all directions
        cameraForward.Normalize();
        cameraRight.Normalize();
 
        // Calculate the movement direction based on input and camera orientation
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));
 
        // Apply the movement direction and speed
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;
 
        isOnGround = controller.isGrounded;

        if (isOnGround)
        {
            animator.SetBool("IsGrounded",true);
            animator.SetBool("CanDoubleJump",false);

            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("IsGrounded",false);
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                hasJumped = true;
            }
            
            else
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
                hasJumped = false;
            }
        }else
        {
            if(canDoubleJump == true && hasJumped == true){
                if (Input.GetButtonDown("Jump"))
                {
                    animator.Play("Double Jump");
                    canDoubleJump = false;
                    gravity.y += Mathf.Sqrt(jumpHeight * -1.5f * gravityValue);
                    animator.SetBool("CanDoubleJump",true);
                    animator.SetBool("IsGrounded",false); 
                }
                    
            }
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }
        // Apply gravity and move the character
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);
    }
 
}
