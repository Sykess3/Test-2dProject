using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrateState : State
{
    private Animator _animator;
    private readonly int _celebrateAnimationHash = Animator.StringToHash("Celebrate");
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_celebrateAnimationHash);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
