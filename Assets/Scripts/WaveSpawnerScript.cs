using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerScript : MonoBehaviour
{

    // In this script we count a few seconds and startig to spawn enemies.
    // We will spawn them with 0.5 sec' between every enemy spawning.
    // We span a wave of enemies every few sec'.

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float countDown = 2.5f;

    public TextMeshProUGUI waveCountDownText;
    private int waveIndex = 0;

    private void Update() {
        
        if(countDown <= 0f) {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format( "Next Wave: \n {0:00.00}",countDown);
    }


    // Spawning a wave of enemies with 0.5 sec' between.
    IEnumerator SpawnWave() {
        waveIndex++;
        PlayerStat.wavwSurvived++;

        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }


    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
