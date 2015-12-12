using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	int difficulty = 3;

	enum WaveState {
		waveSpawning,
		waveSpawnOver,
		restBetweenWaves,
	}

	public GameObject enemyPrefab;

	float interval = 0.1f;
	float lastCheckTime = 0.0f;
	WaveState currentState;
	int waveNum;
	int enemiesToSpawn;
	float timeBetweenWaves = 1;
	float timeToNextWave;
	PlayerData pData;

	float timeSinceLastSpawn;
	float timeBetweenSpawns;
	float baseTimeBetweenSpawns = 1.5f;

	Bounds spawnBounds;

	void Awake() {
		currentState = WaveState.restBetweenWaves;
		waveNum = 1;
		enemiesToSpawn = getNumberOfEnemies (waveNum);
		timeBetweenSpawns = getTimeBetweenSpawns (waveNum);
		timeSinceLastSpawn = Time.timeSinceLevelLoad;
		spawnBounds =  GetComponent<BoxCollider> ().bounds;
		pData = GameObject.Find ("GameManager").GetComponent<PlayerData> ();
	}

	int LiveBearCount() {
		return GameObject.FindGameObjectsWithTag ("Enemy").Length;
	}

	void Update() {
		// Check game state every interval.
		if(Time.timeSinceLevelLoad > lastCheckTime + interval) {
			//Debug.Log (currentState);
			lastCheckTime = Time.timeSinceLevelLoad;
			
			switch(currentState) {
			case WaveState.waveSpawning:
				if (enemiesToSpawn <= 0) {
					currentState = WaveState.waveSpawnOver;
				} else {
					if (Time.timeSinceLevelLoad > timeSinceLastSpawn + timeBetweenSpawns) {
						timeSinceLastSpawn = Time.timeSinceLevelLoad;
						SpawnBear ();
					}
				}
				break;
			case WaveState.waveSpawnOver :
				if(LiveBearCount() == 0) {
					timeToNextWave = Time.timeSinceLevelLoad + timeBetweenWaves;
					currentState = WaveState.restBetweenWaves;
				} break;
			case WaveState.restBetweenWaves:
				if(Time.timeSinceLevelLoad > timeToNextWave) {
					waveNum++;
					enemiesToSpawn = getNumberOfEnemies (waveNum);
					timeBetweenSpawns = getTimeBetweenSpawns (waveNum);
					currentState = WaveState.waveSpawning;
				}
				break;
			default:
				break;
			}
		}
	}
		
	int getNumberOfEnemies (int waveNum) {
		return waveNum * waveNum * difficulty;
	}

	void SpawnBear() {
		float zCoord = Random.value * (spawnBounds.max.z - spawnBounds.min.z) + spawnBounds.min.z;
		float xCoord = spawnBounds.center.x;
		float yCoord = spawnBounds.center.y;
		Vector3 newSpawnPoint = new Vector3 (xCoord, yCoord, zCoord);
		Instantiate (enemyPrefab, newSpawnPoint, Quaternion.identity);
		enemiesToSpawn--;
//		Debug.Log("Bears left: " + enemiesToSpawn.ToString());
	}

	float getTimeBetweenSpawns(int waveNum) {
		return Mathf.Min (1.5f, Mathf.Max (0.4f, baseTimeBetweenSpawns / Mathf.Sqrt(waveNum)));
	}
}
