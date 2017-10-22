using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBehaviour : MonoBehaviour {
	
	void Update () {
		
		if (Input.anyKey) {
			transform.Find ("RawImage").gameObject.SetActive (true);
		}
        
	}
}
