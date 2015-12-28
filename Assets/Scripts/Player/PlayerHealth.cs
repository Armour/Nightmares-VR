using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public AudioClip hurtClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
	PlayerShooting playerShooting;
	AudioSource playerAudio;
	FirstPersonController fps;
    bool isDead;
    bool damaged;

    void Awake() {
        anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
		fps = GetComponent<FirstPersonController>();
        currentHealth = startingHealth;
    }

    void Update() {
        if (damaged) {
            damageImage.color = flashColour;
        } else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount) {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

		playerAudio.clip = hurtClip;
        playerAudio.Play();

        if(currentHealth <= 0 && !isDead) {
            Death();
        }
    }

    void Death() {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

		fps.enabled = false;
        playerShooting.enabled = false;
	}

	public void RestartLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
