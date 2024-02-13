using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningCoins : Coins
{
    public event Action<RespawningCoins> OnCollected;

    private Vector3 perviousPosition;

    private void Update()
    {
        if (perviousPosition != transform.position)
        {
            Show(true);
        }
        perviousPosition = transform.position;
    }

    public override int Collect()
    {
        if (!IsServer)
        {
            Show(false);
            return 0;
        }

        if (alreadyCollected) { return 0; }

        alreadyCollected = true;
        OnCollected?.Invoke(this);
        return coinValue;
    }

    public void Reset()
    {
        alreadyCollected = false;
    }
}
