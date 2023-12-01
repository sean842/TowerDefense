using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // In this script we will:
    // 1. find a target.
    // 2. instatiate the bullet and move it towords the target.
    // 3. destroy the target, bullet and making a nice affect for the bullet.

    private Transform target;
    public float speed = 70f;
    public float explotiontRadius = 0f;
    public GameObject impactEffect;
    public int damage = 50;

    public void Seek(Transform _target) {
        target = _target;
    }

    // Update is called once per frame
    void Update() {
        // if we dont have a target we destroy the object.
        if(target == null) {
            Destroy(gameObject);
            return;
        }

        // set a direction to move.
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // we check if the length to the target is equal or less then distanceThisFrame.
        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }
        // we didnt hit the target so we move the bullet.
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target); // the bullet will look at the target

    }

    void HitTarget() {
        // Show the Effect.
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        // Destroy the effect after 2 sec'.
        Destroy(effectIns, 2f);

        if (explotiontRadius > 0) {
            Explode();
        } else { Damage(target); }

        Destroy(gameObject);
    }

    void Explode() {
        // get an arry of colliders that got hit.
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explotiontRadius);

        // we check if we hit the Enemy, if we do we Damage it.
        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy) {
        Enemy currentEnemy = enemy.GetComponent<Enemy>();// store the enemy script component of the current enemy

        if (currentEnemy != null) {
            currentEnemy.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explotiontRadius);
    }


}
