using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    protected void OnValueChange(int current, int max)
    {
        Slider.value = (float) current / max;
    }
}
