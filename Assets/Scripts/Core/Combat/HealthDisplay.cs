using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class HealthDisplay : NetworkBehaviour
{
    [Header("References")] 
    [SerializeField] private Health health;
    [SerializeField] private Image healBarImage;

    public override void OnNetworkSpawn()
    {
        if(!IsClient) {return;}
        health.currentHealth.OnValueChanged += HandleHealthChanged;
        HandleHealthChanged(0, health.currentHealth.Value);
    }

    public override void OnNetworkDespawn()
    {
        if(!IsClient) {return;}
        health.currentHealth.OnValueChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int oldHealth, int newHealth)
    {
        healBarImage.fillAmount = (float)newHealth / health.MaxHealth;
    }
}
