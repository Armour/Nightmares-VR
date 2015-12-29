using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;
	public Animator mobileAnim;

    Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (playerHealth.currentHealth <= 0) {
            anim.SetTrigger("GameOver");
			mobileAnim.SetTrigger("GameOver");
        }
	}
}
