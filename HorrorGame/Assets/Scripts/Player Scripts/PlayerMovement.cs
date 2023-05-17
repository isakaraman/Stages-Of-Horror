using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    
    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump=true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded=true;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rigid;

    [SerializeField] AudioSource footsteps;

    [SerializeField] firstStage firststageS;

    public bool gameOverCheck;
    public bool gameStart;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;
    }

    private void Update()
    {
        if (gameStart)
        {
            if (!gameOverCheck)
            {
                grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.75f + 0.2f, whatIsGround);

                MyInput();
                SpeedControl();

                if (grounded)
                {
                    rigid.drag = groundDrag;
                }
                else
                {
                    rigid.drag = 0;
                }
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (gameStart)
        {
            if (!gameOverCheck)
            {
                MovePlayer();
            }
        }
    }
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            readyToJump = false;
            Jump();
            Invoke(nameof(resetJump), jumpCoolDown);
        }
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rigid.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rigid.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rigid.velocity.x, 10f, rigid.velocity.z);

        if (flatVel.magnitude>moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rigid.velocity = new Vector3(limitedVel.x, rigid.velocity.y, limitedVel.z);
        
        }
        
    }

    void Jump()
    {
        rigid.velocity = new Vector3(rigid.velocity.x, 0f, rigid.velocity.z);

        rigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    void resetJump()
    {
        readyToJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="FirstStageStart")
        {

            other.gameObject.SetActive(false);
            firststageS.firstStageText();
            firststageS.skip2 = true;
            gameStart = false;
        }
    }
}
