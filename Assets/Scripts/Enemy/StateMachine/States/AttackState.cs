using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;
    private float _lastTimeAttack;
    
    private Animator _animator;
    private readonly int _attackAnimationHash = Animator.StringToHash("Attack");
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_lastTimeAttack <= 0)
        {
            Attack(Target);
            _lastTimeAttack = _delay;
        }

        _lastTimeAttack -= Time.deltaTime;
    }
    

    private void Attack(Player target)
    {
        _animator.Play(_attackAnimationHash);
        target.ApplyDamage(_damage);
    }
}
