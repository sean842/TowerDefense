using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovment : MonoBehaviour
{
    private Transform target; // The current target waypoint.
    private int wavePointIndex = 0; // Index of the current waypoint.
    private Enemy enemy;

    private void Start() {
        // Set the initial target to the first waypoint.
        target = wayPointsScript.wayPoints[0];
        enemy = GetComponent<Enemy>();
    }

    private void Update() {
        // Move towards the current waypoint.
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        // If the distance to the waypoint is very close, move to the next waypoint.
        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;

    }

    void GetNextWayPoint() {
        if (wavePointIndex >= wayPointsScript.wayPoints.Length - 1) {
            EndPath();
            return;
        }

        wavePointIndex++; // Move to the next waypoint in the array.
        target = wayPointsScript.wayPoints[wavePointIndex]; // Set the target to the next waypoint.
    }

    void EndPath() {
        PlayerStat.Lives--;
        // Destroy the enemy when it reaches the last waypoint.
        Destroy(gameObject);
        WaveSpawnerScript.numEnemiesAlive--; // deacrease the number of enemies alive.

    }



}
