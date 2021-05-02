using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;

    public event UnityAction<Enemy> Dying;
    public Player Target => _target;
    public int Reward => _reward;

    public void TakeDamage(int damage)
    {
        if (damage >= _health)
        {
            _health = 0;
            Dying?.Invoke(this);
            Destroy(gameObject);
            return;
        }
        _health -= damage;
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
