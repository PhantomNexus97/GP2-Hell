using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiTest2 : MonoBehaviour
{

    public NavMeshAgent _navMeshAgent;
    public float _startWaitTime;
    public float _timeToRotate;
    public float _speedWalk = 11;
    public float _speedRun = 23;

    public float _viewRadius = 15;
    public float _viewAngle = 90;
    public LayerMask _playerMask;
    public LayerMask _obstacleMask;
    public float _meshResolution = 1.0f;
    public int _edgeInterations = 4;
    public float _edgeDistance = 0.5f;


    public Transform[] _waypoints;
    int _m_currentWaypointIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 _m_PlayerPosition;

    float _m_WaitTime;
    float _m_TimeToRotate;
    bool _m_playerInRange;
    bool _m_PlayerNear;
    bool _m_IsPatrol;
    bool _m_CaughtPlayer;


    public float _timeUntilPatrol = 7;
    public bool _aiEnteredSigil = false;

    void Start()
    {
        _m_PlayerPosition = Vector3.zero;
        _m_IsPatrol = true;
        _m_CaughtPlayer = false;
        _m_playerInRange = false;
        _m_PlayerNear = false;
        _m_WaitTime = _startWaitTime;
        _m_TimeToRotate= _timeToRotate;

        _m_currentWaypointIndex = 0;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _navMeshAgent.isStopped = false;
        _navMeshAgent.speed = _speedWalk;
        _navMeshAgent.SetDestination(_waypoints[_m_currentWaypointIndex].position);
    }

    private void Update()
    {
        EnviromentView();

        if (_aiEnteredSigil == true)
        {
            StartCoroutine(CaughtInSigil());
        }
        else if(!_m_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patroling();
        }

    }
    private void Alarmed()
    {
        Move(_speedRun);
        _navMeshAgent.SetDestination(_m_PlayerPosition);
    }



    private void Chasing()
    {
        _m_PlayerNear = false;
        playerLastPosition = Vector3.zero;

        if (!_m_CaughtPlayer)
        {
            Move(_speedRun);
            _navMeshAgent.SetDestination(_m_PlayerPosition);
        }
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            if(_m_WaitTime <= 0 && !_m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                _m_IsPatrol = true;
                _m_PlayerNear = false;
                Move(_speedWalk);
                _m_TimeToRotate = _timeToRotate;
                _m_WaitTime = _startWaitTime;
                _navMeshAgent.SetDestination(_waypoints[_m_currentWaypointIndex].position);
            }
            else
            {
                if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                    Stop();
                _m_WaitTime -= Time.deltaTime;
            }
        }
    }

    public void Patroling()
    {
        if (_m_PlayerNear)
        {
           
            if (_m_TimeToRotate <= 0)
            {
                Move(_speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                Stop();
                _m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            _m_PlayerNear = false;            
            playerLastPosition = Vector3.zero;
            _navMeshAgent.SetDestination(_waypoints[_m_currentWaypointIndex].position);    
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                if (_m_WaitTime <= 0.1)
                {
                    NextPoint();
                    Move(_speedWalk);
                    _m_WaitTime = _startWaitTime;
                }
                else
                {
                    Stop();
                    _m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }

    private void OnAnimatorMove()
    {
        
    }

    private void NextPoint()
    {
        _m_currentWaypointIndex = (_m_currentWaypointIndex + 1) % _waypoints.Length;
        _navMeshAgent.SetDestination(_waypoints[_m_currentWaypointIndex].position);
    }

    public void Stop()
    {
        _navMeshAgent.isStopped = true;
        _navMeshAgent.speed = 0;
    }

    public void Move(float speed)
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.speed = speed;
    }

    void CaughtPlayer()
    {
        _m_CaughtPlayer = true;
    }

    void LookingPlayer(Vector3 player)
    {
        _navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (_m_WaitTime <= 0)
            {
                _m_PlayerNear = false;
                Move(_speedWalk);
                _navMeshAgent.SetDestination(_waypoints[_m_currentWaypointIndex].position);
                _m_WaitTime = _startWaitTime;
                _m_TimeToRotate = _timeToRotate;
            }
            else
            {
                Stop();
                _m_WaitTime -= Time.deltaTime;
            }
        }
    }
    private IEnumerator CaughtInSigil()
    {
        Stop();
        yield return new WaitForSeconds(_timeUntilPatrol);
        Move(_speedWalk);
        _aiEnteredSigil = false;

    }
    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, _viewRadius, _playerMask);   

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < _viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);          
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, _obstacleMask))
                {
                    _m_playerInRange = true;             
                    _m_IsPatrol = false;                 
                }
                else
                {
             
                    _m_playerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > _viewRadius)
            {

                _m_playerInRange = false;                
            }
            if (_m_playerInRange)
            {

                _m_PlayerPosition = player.transform.position;       
            }
        }
    }
}
