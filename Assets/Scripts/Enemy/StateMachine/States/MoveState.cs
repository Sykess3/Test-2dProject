using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;
    private Animator _animator;
    private readonly int _runAnimationHash = Animator.StringToHash("Run");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_runAnimationHash);
    }
    private void OnDisable()
    {
        _animator.StopPlayback();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            Target.transform.position, _speed * Time.deltaTime);
    }
}
