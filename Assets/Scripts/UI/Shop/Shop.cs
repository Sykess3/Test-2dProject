using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;
    

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClicked += OnSellButtonClick;
        view.Render(weapon);
    }
    
    private void OnSellButtonClick(Weapon weapon, WeaponView weaponView)
    {
        TrySellWeapon(weapon, weaponView);
    }

    private bool TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if (_player.TryBuyWeapon(weapon))
        {
            weapon.Buy();
            weaponView.SellButtonClicked -= OnSellButtonClick;
            return true;
        }

        return false;
    }
    
}
