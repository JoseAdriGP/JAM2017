using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColorMino : MonoBehaviour
{

	// Use this for initialization
	[Header ("Color of mino")]
	public string ColorOfMino;


	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void GetTetrominoColor ()
	{
		switch (ColorOfMino) {

		case "Rojo":
			CurrentColorsManager.MinoRojo++;
			break;

		case "Azul":
			CurrentColorsManager.MinoAzul++;
			break;

		case "Verde":
			CurrentColorsManager.MinoVerde++;
			break;

		case "Amarillo":
			CurrentColorsManager.MinoAmarillo++;
			break;


		}

		FindObjectOfType <CurrentColorsManager> ().ShowCurrentMinos ();



	}
}
