using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSliderVal : MonoBehaviour {

	public PlayerHealth playerHealth;

	private Slider slider;

	void Awake() {
		slider = GetComponent<Slider>();
		slider.maxValue = playerHealth.startingHealth;
		slider.value = playerHealth.startingHealth;
	}
}
