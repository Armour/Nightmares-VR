﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour {

    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
	public float range = 100.0f;
	public float innerRange = 2.0f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
	float effectsDisplayTime = 0.2f;
	Animator anim;

	void Awake() {
		anim = GetComponentInParent<Animator>();
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }
	
    void Update() {
        timer += Time.deltaTime;

		bool shooting = Cardboard.SDK.Triggered;
		bool shooting2 = Input.GetButton("Fire1");

		if ((shooting || shooting2) && timer >= timeBetweenBullets && Time.timeScale != 0) {
            Shoot();
		}

		anim.SetBool("IsShooting", shooting);

        if (timer >= timeBetweenBullets * effectsDisplayTime) {
            DisableEffects();
        }
    }
	
    public void DisableEffects() {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
	
    void Shoot() {
        timer = 0.0f;

        gunAudio.Play();

        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

		shootRay = Camera.main.ScreenPointToRay(new Vector3((Screen.width * 0.5f), (Screen.height * 0.5f), 0f));

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        } else {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

		shootRay.direction = -transform.forward;
		if (Physics.Raycast(shootRay, out shootHit, innerRange, shootableMask)) {
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage(damagePerShot, shootHit.point);
			}
		}
    }
}
