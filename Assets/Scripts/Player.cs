using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(MoveController))]

public class Player : MonoBehaviour
{

     [System.Serializable]
     public class MouseInput
     {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool LockMouse; 

     }

    [SerializeField]float runSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float jumpForce = 30f;
    [SerializeField] float gravity = 30f;
    public bool grounded;
    public new Rigidbody rigidbody;

    [SerializeField] AudioController footSteps;
    [SerializeField] float minimumMoveThreshold;
    [SerializeField]MouseInput MouseControl;

    Vector3 previousPosition;

   private MoveController m_moveController;
    public MoveController MoveController
    {
        get
        {
            if (m_moveController == null)
                m_moveController = GetComponent<MoveController>();
            return m_moveController;
        }
    }

    private PlayerShoot m_PlayerShoot;
    public PlayerShoot PlayerShoot
    {
        get
        {
            if (m_PlayerShoot == null)
                m_PlayerShoot = GetComponent<PlayerShoot>();
            return m_PlayerShoot;
        }
    }

    private Crosshair m_Crosshair;
    private Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GetComponentInChildren<Crosshair>();
            return m_Crosshair;
        }
    }

   

    InputController playerInput;
    Vector2 mouseInput;
   
    // Use this for initialization
    void Start ()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;

        /*if(MouseControl.LockMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }*/
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();

        LookAround();

        if (GameManager.Instance.InputController.isJumping)
            Jump();




    }

    void Move()
    {
        float moveSpeed = runSpeed;
        if (playerInput.IsWalking)
        moveSpeed = walkSpeed;

        if (playerInput.IsSprinting)
            moveSpeed = sprintSpeed;



        Vector2 direction = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);

        MoveController.Move(direction);
        if (Vector2.Distance(transform.position, previousPosition) > minimumMoveThreshold)
            footSteps.Play();

        previousPosition = transform.position;
    }

    void LookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);

        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);

        Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);

    }

    void Jump()
    {
        if (!grounded)
            return;
        rigidbody.AddForce(transform.up * jumpForce);
        
        
    }

   /*void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            grounded = true;
    }*/

    void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            grounded = false;

    }


    void OnCollisionEnter(Collision collision)
    {
        float moveSpeed = runSpeed;
        if (collision.gameObject.tag == "Buildings")
            moveSpeed = 0;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            grounded = true;

    }

}
