using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public ItemScript itemScr;
    [Header("Itens")]
    [SerializeField] private Transform player;
    [SerializeField] private MeshRenderer playerrender;
    public CharacterController controller;
    //public LadderScript ladderScript;
    public Camera playerCamera;


    [Header("run & crouch")]
    //run
    public float speed = 5.0f;
    public float initial_speed;
    public float runspd = 10.0f;

    private bool isRunning;
    //crouch
    [SerializeField] float crouchHeight = 1f;
    [SerializeField] Vector3 standingHeight;
    float crouchspeed = 2.5f;


    //gravidade
    [Header("Gravity")]
    public float gravity = -1.0f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    [SerializeField] float velocity;

    //headbobbing
    [Header("headbobbing")]
    [SerializeField] float WalkBobSpeed = 14.0f;
    [SerializeField] float WalkBobAmount = 0.05f;
    [SerializeField] float SprintBobSpeed = 18.0f;
    [SerializeField] float SprintBobAmount = 0.11f;
    private float defaultYpos = 0;
    private float timer;
    //
    Vector3 current_position;
    
    Vector3 last_position;

   public enum State
    {
        Normal,
        Parado,
        Agachar,
        Subir,
    }
    public State estado;
    void Start()
    {
        initial_speed = speed;
        estado = State.Normal;
        defaultYpos = playerCamera.transform.localPosition.y;
        isRunning = false;
        current_position = transform.position;
        standingHeight = player.localScale;
        /*itemScr = GetComponent<ItemScript>();*/
    }
    void Update()
    {
        current_position = transform.position;
        last_position = current_position;
        switch(estado)
        {
            case State.Normal:
            {
                ApplyGravity();
                Movement();
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    speed = runspd; 
                    isRunning = true;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    speed = initial_speed;
                    isRunning = false;
                }
                ///

                //agachar
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    estado = State.Agachar;
                }

                /*
                //escada
                if (ladderScript.range == true)
                {
                    estado = State.Subir;
                }*/
      
                break;
            }
            case State.Parado:
            {
                ApplyGravity();
                controller.Move(new Vector3(0,0,0));
                break;
            }
            case State.Subir:
            {
                Vector3 frontDirection = playerCamera.transform.forward;
                float ladderspeed = 2f;
                controller.Move(new Vector3(0,0,0));
                if (Input.GetKey(KeyCode.W))
                {
                    controller.Move(Vector3.up * ladderspeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    controller.Move(Vector3.down * ladderspeed * Time.deltaTime);
                }
                /*if (ladderScript.range == false)
                {
                    controller.Move(frontDirection * (ladderspeed * 200.0f) * Time.deltaTime);
                    estado = State.Normal;
                }*/
                break;
            }
            case State.Agachar:
            {
                ApplyGravity();
                Movement();
                Crouch();
                break;
            }
        }
    }
    void ApplyGravity()
    {
        velocity = -gravity * Time.deltaTime;
        if (controller.isGrounded && velocity <= 0.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }
        controller.Move(new Vector3(0,velocity,0));
    }
    void HandleHeadBob(Vector3 direction)
    {
        if (controller.isGrounded)
        {
             //moving or not
            if (Mathf.Abs(direction.x) > 0.1f || Mathf.Abs(direction.z) > 0.1f)
            {
                timer += Time.deltaTime * (isRunning ? SprintBobSpeed : WalkBobSpeed);
                
                playerCamera.transform.localPosition = new Vector3(
                    playerCamera.transform.localPosition.x,
                    defaultYpos + Mathf.Sin(timer) * (isRunning ? SprintBobAmount : WalkBobAmount),
                    playerCamera.transform.localPosition.z
                );
            }
        }

    }
    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 dir = moveX * transform.right + moveZ * transform.forward;
        HandleHeadBob(dir);
        controller.Move(dir * speed * Time.deltaTime);
    }
    void Crouch()
    {
        speed = crouchspeed;
        player.localScale = new Vector3(2,crouchHeight,2);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {   
            speed = initial_speed;
            player.localScale = standingHeight;
            estado = State.Normal;
        }
    }    

    public void Switch(int n)
    {
        if (n == 0)
        {
            estado = State.Parado;
        }
        if (n == 1)
        {
            estado = State.Normal;    
        }    
    }
}
