using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {
	public GameObject fadeCanvas;

	public void empezarPartida(){
		
		fadeCanvas.SetActive (true);
        
	}

    public void creditosPartida()
    {
        SceneManager.LoadScene("Creditos");
        //fadeCanvas.SetActive(true);

    }

    public void instrucciones()
    {

        //SceneManager.LoadScene("instrucciones");


        //fadeCanvas.SetActive(true);

    }

    public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
