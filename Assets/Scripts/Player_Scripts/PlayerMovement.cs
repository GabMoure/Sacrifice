using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ItemScript itemScr;
    [SerializeField] private Transform player;
    [SerializeField] private Transform Hand;
    public CharacterController controller;
    public LadderScript ladderScript;
    public DoorScript doorScript;
    public Camera playerCamera;
    //
    public float speed = 5.0f;
    public float initial_speed;
    public float runspd = 10.0f;

    private bool isRunning;
    //
    //gravidade
    public float gravity = -1.0f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    [SerializeField] float velocity;

    //headbobbing
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
        itemScr = GetComponent<ItemScript>();
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
                if (itemScr.ItemList.Contains(itemScr.luz))
                {
                    Lanterna(itemScr.luz.gameObject);
                }
                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");
                Vector3 dir = moveX * transform.right + moveZ * transform.forward;
                HandleHeadBob(dir);
                ///
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
                controller.Move(dir * speed * Time.deltaTime);
                ///
                if (doorScript.fresta == true)
                {
                    estado = State.Parado;
                }
                //escada
                if (ladderScript.range == true)
                {
                    estado = State.Subir;
                }

                
                break;
            }
            case State.Parado:
            {
                ApplyGravity();
                controller.Move(new Vector3(0,0,0));
                if (doorScript.fresta == false)
                {
                    estado = State.Normal;
                }
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
                if (ladderScript.range == false)
                {
                    controller.Move(frontDirection * (ladderspeed * 200.0f) * Time.deltaTime);
                    estado = State.Normal;
                }
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
    void Lanterna(GameObject luze)
    {
        Rigidbody lanternBody = luze.GetComponent<Rigidbody>();
        BoxCollider laterncollider = luze.GetComponent<BoxCollider>();
        if (itemScr.ItemList.Contains(luze))
        {
            
            //desativando componentes
            laterncollider.enabled = false;
            lanternBody.useGravity = false;

            //colocando na mesma posição
            luze.transform.position = Hand.position;
            luze.transform.parent = Hand;
            luze.transform.rotation = playerCamera.transform.rotation;
            //droppar
            if (Input.GetKeyDown(KeyCode.G))
            {
   
                Hand.DetachChildren();
                laterncollider.enabled = true;
                lanternBody.useGravity = true;
                //
                itemScr.ItemList.Remove(luze);
                itemScr.luz = null;
                //          
                return;
            }
        }
    }

 
}
