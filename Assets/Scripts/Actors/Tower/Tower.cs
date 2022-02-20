using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay = 1f;

    void Awake()
    {

    }

    void Start()
    {
        StartCoroutine(Build());
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

    IEnumerator Build()
    {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child) {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child) {
                grandchild.gameObject.SetActive(true);
                //yield return new WaitForSeconds(buildDelay);
            }
        }
    }
}
