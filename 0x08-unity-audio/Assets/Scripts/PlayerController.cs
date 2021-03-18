using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{


    //CharacterController.Move
    public CharacterController controller;
    public float speed = 6f;
    private float jumpSpeed = 9f;
    public float gravity = 18f;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject reference;


    public float rotateSpeed = 60;
    
    Vector3 velocity;
    private Vector3 startPosition;
    Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Animator anim;

    public AudioSource audioSource;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        cam = GetComponent<Transform>();
        startPosition = cam.position;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");



        if (controller.isGrounded)
        {
            //Control  of animations
            Debug.Log("TIERRA ON");
            anim.SetBool("ground",true);
            anim.SetBool("falling",false);
            anim.SetBool("Run", false);

            //movement and change of exes with camera and mouse
           
            moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection = transform.TransformDirection(moveDirection);
            Quaternion target = Quaternion.Euler(horizontal, reference.transform.eulerAngles.y, vertical) ;
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotateSpeed);
            


            if (horizontal != 0 || vertical != 0)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.x *= speed / 1.5f;
                    moveDirection.z *= speed / 1.5f;
                    moveDirection.y = jumpSpeed;
                    anim.SetTrigger("Jump");
                }
                else {
                    moveDirection.x *= speed;
                    moveDirection.z *= speed;
                }
                anim.SetBool("Run", true);
                
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    anim.SetTrigger("Jump");
                }
                anim.SetBool("Run", false);
            }
                

            
        }
        else
        {
                anim.SetBool("ground", false);
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        //if fall restart from sky
        if (cam.position.y < -20)
        {
            anim.SetBool("ground", false);
            anim.SetBool("falling", true);
            anim.SetBool("Run", false);
            cam.position = new Vector3(startPosition.x, startPosition.y + 15, startPosition.z);
        }
        
    }    
}