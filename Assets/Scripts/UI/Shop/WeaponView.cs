using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonClicked;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);

    }

    private void TryLockItem()
    {
        if (_weapon.IsBought)
            _sellButton.interactable = false;
    }
        
    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        
        _icon.sprite = _weapon.Icon;
        _label.text = _weapon.Name;
        _price.text = _weapon.Price.ToString();
    }

    private void OnSellButtonClick()
    {
        SellButtonClicked?.Invoke(_weapon, this);
    }
}
