using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private bool _isBought;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    
    [SerializeField] protected Bullet Bullet;

    public string Name => _name;
    public Sprite Icon => _icon;
    public int Price => _price;
    public bool IsBought => _isBought;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBought = true;
    }
}
