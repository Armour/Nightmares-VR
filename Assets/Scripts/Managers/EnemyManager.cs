using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3.0f;
    public Transform[] spawnPoints;
	public EnemyCounter counter;

    void Start() {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn() {
        if (playerHealth.currentHealth <= 0f) {
            return;
		}
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);
		if (enemy.gameObject.tag == "ZomBunny") {
			if (counter.bunnyNumber < counter.maxBunnyNumber) {
				counter.increaseBunny();
				Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			}
		}
		if (enemy.gameObject.tag == "ZomBear") {
			if (counter.bearNumber < counter.maxBearNumber) {
				counter.increaseBear();
				Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			}
		}
		if (enemy.gameObject.tag == "Hellephant") {
			if (counter.elepNumber < counter.maxElepNumber) {
				counter.increaseElep();
				Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			}
		}
	}
}
