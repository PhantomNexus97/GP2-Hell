using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigil : MonoBehaviour
{
    public float _timeUntilDespawn = 3;
    public AiTest2 _aiScript;
    public FirstPersonController _fpsController;
    private void Start()
    {
        _aiScript = GameObject.Find("Enemy_01").GetComponent<AiTest2>();
        _fpsController = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        if(_aiScript._aiEnteredSigil == true)
        {

        }
        else if(_aiScript._aiEnteredSigil == false)
        {
            return;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            _aiScript._aiEnteredSigil = true;
            StartCoroutine(Despawn());
        }
    }
    IEnumerator Despawn()
    {

        yield return new WaitForSeconds(_timeUntilDespawn);
        _fpsController._attackAllowed = true;
        _aiScript._aiEnteredSigil = false;
        Destroy(gameObject);
    }
}
