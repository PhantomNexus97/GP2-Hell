using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FpsMovement : MonoBehaviour
{

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;

    [Header("Sprint Data")]
    public float sprintStamina = 30;
    public float maxSprintStamina = 30;
    public float staminaRegenRate;
    private bool isRegenerating = false;
    public bool _canSprint = true;
    public Image _staminaBar;
    float _lerpSpeed;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    public float startYScale;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public KeyCode DamageHealth = KeyCode.K;
    public KeyCode placeSigil = KeyCode.Mouse0;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Attack Sigil")]
    public GameObject _attackSigil; 
    public LayerMask _floorLayer;

    public Transform orientation;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;

        sprintStamina = maxSprintStamina;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();

        if (grounded) { rb.drag = groundDrag; }
        else rb.drag = 0;

        if (Input.GetKeyDown(DamageHealth))
        {
            GameManager.gameManager.PlayerTakeDamage(1);
        }
        else if(Input.GetKeyUp(DamageHealth)) 
        {
            return;
        }

        if(_canSprint == false) 
        {
            isRegenerating = true;
            StartCoroutine(RegenerateStamina());
        }



        if (Input.GetKeyDown(placeSigil)) // check if the left mouse button is clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray from the camera to the mouse position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _floorLayer)) // cast the ray and check if it hits the floor
            {
                Instantiate(_attackSigil, hit.point, Quaternion.identity); // instantiate the object at the hit point
            }
        }

        StaminahBarFiller();
        _lerpSpeed = 3f * Time.deltaTime;

       if(sprintStamina <= 5) 
       {
            _canSprint = false; 
       }

    }

    void StaminahBarFiller()
    {
        _staminaBar.fillAmount = Mathf.Lerp(_staminaBar.fillAmount, (sprintStamina / maxSprintStamina), _lerpSpeed);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);

        }
    }
    public void UseStamina(float staminaCost)
    {
        sprintStamina -= staminaCost;
        if (sprintStamina <= 0)
        {
            sprintStamina = 0;
        }
    }
    private void StateHandler()
    {
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }

        //Sprinting
        if(grounded && Input.GetKeyDown(sprintKey) && sprintStamina >= 5 && _canSprint == true)
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
            UseStamina(.2f);
            Debug.Log("Sprinting");
        } 


        if (grounded)
        {
            Debug.Log("Walking");
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        else 
        {
            state = MovementState.air;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        if (grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

                // turn gravity off while on slope
        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
                rb.velocity = rb.velocity.normalized * moveSpeed;
        }



        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

    }

    private void Jump()
    {
        exitingSlope = true;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
    private IEnumerator RegenerateStamina()
    {
        while (isRegenerating)
        {
            sprintStamina += staminaRegenRate * Time.deltaTime;
            sprintStamina = Mathf.Clamp(sprintStamina, 0, maxSprintStamina);
            if (sprintStamina == maxSprintStamina)
            {
                isRegenerating = false;
            }
            yield return null;
        }
    }

    private IEnumerator SprintWait()
    {

        yield return new WaitForSeconds (10);
        _canSprint = true;
        
    }
}


