using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        TransitTo(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();
        if (nextState != null)
            TransitTo(nextState);
    }
    

    private void TransitTo(State state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;
        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
