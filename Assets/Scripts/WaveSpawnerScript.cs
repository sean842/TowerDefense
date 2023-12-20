using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{

    // In this script we count a few seconds and startig to spawn enemies.
    // We will spawn them with 0.5 sec' between every enemy spawning.
    // We span a wave of enemies every few sec'.

    public static int enemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    private float countDown = 2.5f;

    public TextMeshProUGUI waveCountDownText;
    private int waveIndex = 0;

    public GameManager gameManager;

    private void Update() {
        
        if(enemiesAlive > 0) {
            return;
        }
        if (waveIndex == waves.Length) {
            gameManager.WinLevel();
            this.enabled = false; // we enable this script.
        }

        if (countDown <= 0f) {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format( "Next Wave: \n {0:00.00}",countDown);
    }


    // Spawning a wave of enemies with 0.5 sec' between.
    IEnumerator SpawnWave() {
        PlayerStat.wavwSurvived++;
        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveIndex++;

    }


    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
