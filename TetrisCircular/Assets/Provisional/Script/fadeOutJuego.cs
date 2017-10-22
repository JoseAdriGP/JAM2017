using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOutJuego : MonoBehaviour {
    public GameObject canvazo;

        
	void Start () {
        
	}
	
	void Update () {
		
	}

    void quitarCanvas()
    {

        canvazo.SetActive(false);
    }
}
