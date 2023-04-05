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


    private Camera _playerCamera;
    private CharacterController _characterController;

    private Vector3 _moveDirection;
    private Vector2 _currentInput;

    private float _rotaionX = 0;

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
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeedX, 0);
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
