using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    //SerializeField is used to allow the variable to be seen in editor while private 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;

    private int count;

    //references 
    private CharacterController controller;
    private Animator anim;


    // Start is called before the first frame update
    private void Start()
    {
        //reference to character controller component 
        controller = GetComponent<CharacterController>();
        //checking children components for an animator 
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();

        //set clicking the mouse to attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
    }

    //function for movement 
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //access vertical axis in project settings to use the w and s keys 
        float moveZ = Input.GetAxis("Vertical");

        //move player in Z direction
        moveDirection = new Vector3(0, 0, moveZ);
        //forward motion set relative to player orientation 
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            //two conditions must be met: if moveDirection not equal to 0 in any direction and left shift key not pressed
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //walking
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //running 
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                //idle 
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        //setting idle function to the idle animation 
        //using 0 cause speed parameter in the animator has idle equal to 0
        //the 0.1 and deltatime are used to make smooth transition between animations
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        //setting walk function to the walk animation
        //use 0.5 cause the speed parameter has walk equal to 0.5
        //the 0.1 and deltatime are used to make smooth transition between animations
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        //setting run function to the run animation
        //use 1 cause the speed parameter has walk equal to 1
        //the 0.1 and deltatime are used to make smooth transition between animations
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        //setting up the trigger in animator called attack 
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        //pickUp object incremented by 1
        {
            other.gameObject.SetActive(false);
            count = count + 1;

        }
    }
}
