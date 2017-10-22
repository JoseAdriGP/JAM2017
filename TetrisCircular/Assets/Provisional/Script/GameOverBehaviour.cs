using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBehaviour : MonoBehaviour {
	
	void Update () {
		
		if (Input.anyKeyDown) {
			transform.Find ("RawImage").gameObject.SetActive (true);
		}
        
	}
}
