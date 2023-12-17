using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawnerScript : MonoBehaviour
{

    // In this script we count a few seconds and startig to spawn enemies.
    // We will spawn them with 0.5 sec' between every enemy spawning.
    // We span a wave of enemies every few sec'.

    //public Transform enemyPrefab;
    public Transform spawnPoint;
    public Wave[] waves;

    public static int numEnemiesAlive = 0;

    public float timeBetweenWaves = 20f;
    private float countDown = 2.5f;

    public TextMeshProUGUI waveCountDownText;
    private int waveIndex = 0;

    public GameManager gameManager;

    private bool waveComplited = false;

    private void Update() {

        // if we have enemies we don't want to spawn a new wave.
        if(numEnemiesAlive > 0) { 
            return;
        }

        if (waveIndex == waves.Length && numEnemiesAlive == 0) {
            Debug.Log("next");
            waveComplited = true;
        }

        if (waveComplited){
            if (gameManager.nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
                gameManager.WinLevel();
                this.enabled = false;// we disable this script to not keep spawning enemies.
                waveComplited = false;
            }
            else {
                gameManager.FinishedGame();
                this.enabled = false;// we disable this script to not keep spawning enemies.
            }

        }

        // if the coutdown is 0 we spawn enemies and set the countdown to time between waves.
        if (countDown <= 0f) {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }
        // we decrease time from the countdown and show it in the game.
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format( "Next Wave: \n {0:00.00}",countDown);
    }


    // Spawning a wave of enemies with 0.5 sec' between.
    IEnumerator SpawnWave() {
        PlayerStat.waveSurvived++;

        if (waveIndex < waves.Length) {
            Wave wave = waves[waveIndex];

            numEnemiesAlive = wave.amountOfEnemies;

            for (int i = 0; i < wave.amountOfEnemies; i++) {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        waveIndex++;
    }

    /// <summary>
    /// instantiate enemy prefab and increase the number of enemies alive.
    /// </summary>
    void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
