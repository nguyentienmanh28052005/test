using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public Image fillBar;

    // public void UpdateHealth(int health, int maxHealth)
    // {
    //     valueText.text = health.ToString() + " / " + maxHealth.ToString();
    //     fillBar.fillAmount = (float)health / (float)maxHealth;
    // }

    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
        
    }
}

