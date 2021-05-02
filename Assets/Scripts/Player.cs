using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    
    private Animator _animator;
    private int _currentHealth;
    private Weapon _currentWeapon;
    
    public int Money { get; private set; }
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }
    
    public void ApplyDamage(int amount)
    {
        if (amount >= _currentHealth)
        {
            _currentHealth = 0;
            HealthChanged?.Invoke(_currentHealth,_maxHealth);
            gameObject.SetActive(false);
            return;
        }
        _currentHealth -= amount;
        HealthChanged?.Invoke(_currentHealth,_maxHealth);
    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public bool TryBuyWeapon(Weapon weapon)
    {
        if (Money >= weapon.Price)
        {
            AddMoney(-weapon.Price);
            MoneyChanged?.Invoke(Money);
            
            _weapons.Add(weapon);
            return true;
        }

        return false;
    }
}
