using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Value Setup")]
    [SerializeField, Tooltip("Reward Value")] int goldReward = 25;
    [SerializeField, Tooltip("Penalty Value")] int goldPenalty = 25;
    
    Bank bank;

    void Awake()
    {
        // Assign bank object
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank) bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank) bank.Withdraw(goldPenalty);
    }
}
