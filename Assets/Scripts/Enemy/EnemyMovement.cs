using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform playerTransform;
	GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
		playerTransform = player.transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
            nav.SetDestination(playerTransform.position);
        } else {
            nav.enabled = false;
        }
    }
}
