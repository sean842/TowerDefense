using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TarrutScript : MonoBehaviour
{

    // In this script we will:
    // 1. search the nearest enemy.
    // 2. set teh turret in the position of the nearest enemy.
    // 3. shoot the enemy.

    private Transform target;
    private Enemy targetEnemyCompo;

    [Header("Generals")]
    public float range = 15f;// rang for the Gizmo Sphere.

    [Header("Bullets (default)")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;

    [Header("Laser")]
    public bool useLaser = false;

    public float slowAmount = 0.5f;
    public int damageOverTime = 30;

    public LineRenderer lineRenderer;
    public Light impactLight;
    public ParticleSystem impactEffect;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);// call the update function every 0.5 sec.
    }

    void UpdateTarget() {
        // we get all the enemies.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //look for the nearest enemy.
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // we set the target to the nearest enemy.
        if(nearestEnemy != null && shortestDistance <range) {
            target = nearestEnemy.transform;
            targetEnemyCompo = nearestEnemy.GetComponent<Enemy>();
        } else { target = null; }

    }

    // Update is called once per frame
    void Update() {

        // if we dont have a target we do nothing.
        if (target == null && useLaser) {
            if (lineRenderer.enabled) {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }

            return;
        }

        LockOnTarget();

        if (useLaser) {
            Laser();
        } else {
            if (fireCountdown <= 0f) {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

        }

    }

    void LockOnTarget()
    {
        Debug.Log("6666666ion");

        if (transform != null) {
            // rotation fo the turret.
            Vector3 dir = target.position - transform.position;
            Quaternion lookRrotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRrotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            Debug.Log("rotation");
        }
        Debug.Log("2323rotation");

    }

    void Laser() {

        targetEnemyCompo.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemyCompo.Slow(slowAmount);

        if (!lineRenderer.enabled) { 
            lineRenderer.enabled=true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        // make the impact effect from the enemy and point the direction of the Laser Beamer.
        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot() {
        Debug.Log("shoot");
        // refrence to our Bullet.
        GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bullet = bulletGO.GetComponent<BulletScript>();
        // if we have a bullet we use Seek Method and pass the target.
        if (bullet != null)  {
            bullet.Seek(target);
        }
    }

    /// <summary>
    /// Drow a Sphere around the object(only in the scene view).
    /// </summary>
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

}
