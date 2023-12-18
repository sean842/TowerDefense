using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // In this script we will make the enemy move in the road (follow the Way Points).

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed; // Speed at which the enemy moves.
    public float startHealth = 100;
    public float health;
    public int moneyValue = 50;

    public GameObject deathEffect;
    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount) {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0) {
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
        WaveSpawnerScript.enemiesAlive--;
        Destroy(gameObject);
    }



}
