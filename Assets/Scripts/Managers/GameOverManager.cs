using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;
	public float winScore = 300.0f;

    Animator anim;
	private Text gameoverText;

    void Awake() {
        anim = GetComponent<Animator>();
		gameoverText = GetComponentInChildren<Text>();
    }

    void Update() {
        if (playerHealth.currentHealth <= 0) {
			gameoverText.text = "You Lose !";
            anim.SetTrigger("GameOver");
		} else if (ScoreManager.score >= 300f) {
			playerHealth.Win();
			gameoverText.text = "You Win !";
			anim.SetTrigger("GameOver");
		}
	}
}
