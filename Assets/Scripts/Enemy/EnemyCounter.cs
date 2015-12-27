using UnityEngine;
using System.Collections;

public class EnemyCounter : MonoBehaviour {

	public int maxBunnyNumber;
	public int maxBearNumber;
	public int maxElepNumber;

	[HideInInspector] public int bunnyNumber = 0;
	[HideInInspector] public int bearNumber = 0;
	[HideInInspector] public int elepNumber = 0;

	public void increaseBunny() {
		bunnyNumber++;
	}

	public void increaseBear() {
		bearNumber++;
	}

	public void increaseElep() {
		elepNumber++;
	}

	public void decreaseBunny() {
		bunnyNumber--;
	}

	public void decreaseBear() {
		bearNumber--;
	}

	public void decreaseElep() {
		elepNumber--;
	}
}
