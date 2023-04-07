using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaskSystem : MonoBehaviour
{
    public bool _canUseMask { get; private set; } = true;
    
    [Header("Mask Key")]
    [SerializeField] private KeyCode _maskKey = KeyCode.Q;

    [Header("Mask Logic")]
    [SerializeField] private float _maxMaskStamina = 50;
    [SerializeField] private float _maskStaminaUseMultiplier = 5;
    [SerializeField] private float _timeBeforeMaskStaminaRegenStarts = 5;
    [SerializeField] private float _maskStaminaValueIncrement = 2;
    [SerializeField] private float _maskStaimnaTimeIncrement = 0.1f;
    [SerializeField] private bool _maskBroken = false;
    [SerializeField] private bool _wearingMask = false;
    public float _currentMaskStamina = 50;
    public bool _isMaskActive = false;
    private Coroutine _regeneratingMaskStamina;

    [Header("Mask UI")]
    [SerializeField] public TextMeshProUGUI _maskStaminaText;
     public GameObject _TrueDisplay;
     public GameObject _FalseDisplay;

    // Update is called once per frame
    void Update()
    {
        if(_currentMaskStamina == 0)
        {
            _maskBroken = true;
        }
        
        if(_maskBroken == true)
        {
            _isMaskActive = false;
            _wearingMask = false;
            _TrueDisplay.SetActive(true);
            _FalseDisplay.SetActive(false);
            Debug.Log("Mask is Broken");
            return;
        }

        if (Input.GetKeyDown(_maskKey) && _maskBroken == false && _wearingMask == false)
        {

            _wearingMask = true;

        }
        else if (Input.GetKeyDown(_maskKey) && _maskBroken == false && _wearingMask == true)
        {
            _wearingMask = false;
        }
        

        if(_wearingMask == true)
        {
            _isMaskActive = true;
            HandleMaskStamina();
        }
        else if(_wearingMask == false)
        {
            _isMaskActive = false;
            HandleMaskStamina();
        }

        //Debug temp
        _maskStaminaText.text = _currentMaskStamina.ToString();

        if(_maskBroken == false)
        {
            _TrueDisplay.SetActive(false);
            _FalseDisplay.SetActive(true);
        }
    }
    private void HandleMaskStamina()
    {
        if (_isMaskActive && _maskBroken == false)
        {
            if (_regeneratingMaskStamina != null)
            {
                StopCoroutine(_regeneratingMaskStamina);
                _regeneratingMaskStamina = null;
            }
            _currentMaskStamina -= _maskStaminaUseMultiplier * Time.deltaTime;

            if (_currentMaskStamina < 0)
                _currentMaskStamina = 0;

            if (_currentMaskStamina <= 0)
                _canUseMask = false;

                
        }

        if (!_isMaskActive && _currentMaskStamina < _maxMaskStamina && _regeneratingMaskStamina == null)
        {
            _regeneratingMaskStamina = StartCoroutine(RegenerateMaskStamina());
        }
    }

    private IEnumerator RegenerateMaskStamina()
    {
        yield return new WaitForSeconds(_timeBeforeMaskStaminaRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(_maskStaimnaTimeIncrement);

        while (_currentMaskStamina < _maxMaskStamina)
        {
            if (_currentMaskStamina > 0)
                _canUseMask = true;
                
            _currentMaskStamina += _maskStaminaValueIncrement;
                
            if (_currentMaskStamina > _maxMaskStamina)
                _currentMaskStamina = _maxMaskStamina;
            yield return timeToWait;
        }

        _regeneratingMaskStamina = null;
    }

}
