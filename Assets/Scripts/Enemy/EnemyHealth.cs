﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
	public EnemyManager manager;
	public EnemyCounter counter;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake() {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
		counter = GameObject.Find("EnemyManager").GetComponent<EnemyCounter>();
        
		currentHealth = startingHealth;
    }

    void Update() {
        if(isSinking) {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint) {
        if(isDead)
            return;

        enemyAudio.Play();

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();
		
		currentHealth -= amount;
        if (currentHealth <= 0) {
            Death();
        }
    }

    void Death() {
        isDead = true;
        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();

		Debug.Log(gameObject.tag);
		if (gameObject.tag == "ZomBunny") {
			counter.decreaseBunny();
		}
		if (gameObject.tag == "ZomBear") {
			counter.decreaseBear();
		}
		if (gameObject.tag == "Hellephant") {
			counter.decreaseElep();
		}
    }

    public void StartSinking() {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}
