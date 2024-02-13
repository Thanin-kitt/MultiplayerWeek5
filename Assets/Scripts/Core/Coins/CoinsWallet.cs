using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CoinsWallet : NetworkBehaviour
{
    public NetworkVariable<int> TotalCoins = new NetworkVariable<int>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent<Coins>(out Coins coins)) { return; }
        int coinValue = coins.Collect();
        
        if(!IsServer) { return; }
        TotalCoins.Value += coinValue;
    }
}
