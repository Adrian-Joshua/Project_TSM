using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText = default;
    [SerializeField] private TextMeshProUGUI staminaText = default;

    private void OnEnable()
    {
        FirstPersonController.OnDamage += UpdateHealth;
        FirstPersonController.OnHeal += UpdateHealth;
        FirstPersonController.OnStaminaChange += UpdateStamina;
    }

    private void OnDisable()
    {
        FirstPersonController.OnDamage -= UpdateHealth;
        FirstPersonController.OnHeal -= UpdateHealth;
        FirstPersonController.OnStaminaChange -= UpdateStamina;
    }
    private void Start()
    {
        UpdateHealth(100.0f);
        UpdateStamina(100.0f);

    }
    private void UpdateHealth(float  currentHealth)
    {
        healthText.text = currentHealth.ToString("00");
    }

    private void UpdateStamina(float currentStamina)
    {
        staminaText.text = currentStamina.ToString("00");
    }
}
