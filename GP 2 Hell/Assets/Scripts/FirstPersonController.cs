using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    public bool _canMove { get; private set; } = true;
    private bool _IsSprinting => _canSprint && Input.GetKey(_sprintKey);

    [Header("Functional Settings")]
    [SerializeField] private bool _canSprint = true;
    [SerializeField] private bool _useStamina = false;

    [Header("Controls")]
    [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 12.0f;
    [SerializeField] private float _sprintSpeed = 24.0f;
    [SerializeField] private float _gravity = 30.0f;

    [Header("Look Settings")]
    [SerializeField, Range(1, 10)] private float _lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float _lookSpeedY = 2.0f;
    [SerializeField, Range(1, 100)] private float _upperLookLimit = 80.0f;
    [SerializeField, Range(1, 100)] private float _lowerLookLimit = 80.0f;

    [Header("Stamina Settings")]
    [SerializeField] private float _maxStamina = 50;
    [SerializeField] private float _staminaUseMultiplier = 5;
    [SerializeField] private float _timeBeforeStaminaRegenStarts = 5;
    [SerializeField] private float _staminaValueIncrement = 2;
    [SerializeField] private float _staimnaTimeIncrement = 0.1f;
    private float _currentStamina = 50;
    public Image _staminaBar;
    float _lerpSpeed;
    private Coroutine _regeneratingStamina;

    [Header("Attack Settings")]
    [SerializeField] public bool _attackAllowed = true;
    [SerializeField] public GameObject _sigil;
    [SerializeField] public LayerMask _floorLayer;

    [Header("UI Settings")]
    public GameObject _healthBarUI;
    public GameObject _staminaBarUI;
    public GameObject _maskUI;
    public GameObject _fpsCounterUI;
    public GameObject _gameOverUI;




    private Camera _playerCamera;
    private CharacterController _characterController;

    private Vector3 _moveDirection;
    private Vector2 _currentInput;

    private float _rotaionX = 0;
    private float _rotaionY= 0;

    // Start is called before the first frame update
    void Awake()
    {
        _playerCamera = GetComponentInChildren<Camera>();
        _characterController= GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove) 
        {
            HandleMovementInput();
            HandleMouseLook();

            if(_useStamina) 
            {
                HandleStamina();
                StaminahBarFiller();
                _lerpSpeed = 3f * Time.deltaTime;
            }

            ApplyFinalMovement();

        }

        if (Input.GetKeyDown(_attackKey) && _attackAllowed == true) // check if the left mouse button is clicked
        {
            HandleAttack();
        }
        else if(Input.GetKeyDown(_attackKey) && _attackAllowed == false)
        {
            return;
        }

   

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            _healthBarUI.SetActive(false);
            _staminaBarUI.SetActive(false);
            _maskUI.SetActive(false);
            _fpsCounterUI.SetActive(false);
            _gameOverUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            Debug.Log("Player collided with an enemy!");
        }
    }
    private void HandleMovementInput()
    {
        _currentInput = new Vector2((_IsSprinting ? _sprintSpeed : _walkSpeed) * Input.GetAxis("Vertical"), (_IsSprinting ? _sprintSpeed : _walkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = _moveDirection.y;
        _moveDirection = (transform.TransformDirection(Vector3.forward) * _currentInput.x) + (transform.TransformDirection(Vector3.right) * _currentInput.y);
        _moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLook()
    {
        _rotaionX -= Input.GetAxis("Mouse Y") * _lookSpeedY;
        _rotaionX = Mathf.Clamp(_rotaionX, -_upperLookLimit, _lowerLookLimit);
        _playerCamera.transform.localRotation = Quaternion.Euler(_rotaionX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeedY, 0);
    }

    private void HandleAttack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray from the camera to the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _floorLayer)) // cast the ray and check if it hits the floor
        {
            _attackAllowed = false;
            Instantiate(_sigil, hit.point, Quaternion.identity); // instantiate the object at the hit point
        }
        
    }

    private void HandleStamina()
    {
        if(_IsSprinting && _currentInput != Vector2.zero)
        {
            if(_regeneratingStamina != null)
            {
                StopCoroutine(_regeneratingStamina);
                _regeneratingStamina = null;
            }
            _currentStamina -= _staminaUseMultiplier * Time.deltaTime;

            if(_currentStamina < 0)
                _currentStamina = 0;

            if(_currentStamina <= 0)
                _canSprint = false;
        }

        if(!_IsSprinting && _currentStamina < _maxStamina && _regeneratingStamina == null)
        {
           _regeneratingStamina = StartCoroutine(RegenerateStamina());
        }
    }
    void StaminahBarFiller()
    {
        _staminaBar.fillAmount = Mathf.Lerp(_staminaBar.fillAmount, (_currentStamina / _maxStamina), _lerpSpeed);
    }
    private void ApplyFinalMovement()
    {
        if(!_characterController.isGrounded) 
        {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    private IEnumerator RegenerateStamina() 
    {
        yield return new WaitForSeconds(_timeBeforeStaminaRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(_staimnaTimeIncrement);

        while(_currentStamina < _maxStamina)
        {
            if(_currentStamina > 0)
                _canSprint = true;

            _currentStamina += _staminaValueIncrement;

            if(_currentStamina > _maxStamina)
                _currentStamina = _maxStamina;
            yield return timeToWait;
        }

        _regeneratingStamina = null;
    }

}
