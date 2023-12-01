using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // In this script we will make the enemy move in the road (follow the Way Points).

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed; // Speed at which the enemy moves.
    public float helth = 100;
    public int moneyValue = 50;
    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount) { 
        helth -= amount;
        if (helth <= 0) {
            Die();
        }

    }

    public void Slow(float amount) { 
        speed = startSpeed * (1f - amount);
    }

    void Die() {
        PlayerStat.Money += moneyValue;// add money to player.
        // make a death effect.
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Destroy the enemy & death effect.    
        Destroy(effect, 5f);
        Destroy(gameObject);
    }



}
