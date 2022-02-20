using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    void Awake()
    {
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        // Get the bank
        Bank bank = FindObjectOfType<Bank>();

        // Bank's broken, can't create shit
        if (bank == null) return false;

        // If we have enough gold, create a tower
        if (bank.CurrentBalance >= cost) {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        } else {
            return false;
        }
    }
}
