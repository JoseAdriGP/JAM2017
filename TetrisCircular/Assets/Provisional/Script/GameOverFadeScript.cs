using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverFadeScript : MonoBehaviour {

	public void changeScene () {
		SceneManager.LoadScene("Menu");
	}
}
