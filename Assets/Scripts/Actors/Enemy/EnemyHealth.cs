using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health Setup")]
    [SerializeField, Tooltip("Maximum Health")] int maxHitPoints = 5;
    [SerializeField, Tooltip("Amount of HP Gained per Death")] int difficultyRamp = 1;

    int currentHitPoints = 0;
    Enemy enemy;

    void Awake()
    {
        // Assign enemy object
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        // Assign current health
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0) {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
