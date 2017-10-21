using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentColorsManager : MonoBehaviour
{

	// Use this for initialization

	//public Function

	[Header ("Text Show")]
	public TextMesh CurrentRojo;
	public TextMesh CurrentAzul;
	public TextMesh CurrentAmarillo;
	public TextMesh CurrentVerde;



	//Static Function
	public static int MinoRojo = 0;
	public static int MinoAzul = 0;
	public static int MinoAmarillo = 0;
	public static int MinoVerde = 0;



	void Start ()
	{
		ShowCurrentMinos ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ShowCurrentMinos ()
	{

		CurrentRojo.text = MinoRojo.ToString ();

		CurrentAzul.text = MinoAzul.ToString ();

		CurrentVerde.text = MinoVerde.ToString ();

		CurrentAmarillo.text = MinoAmarillo.ToString ();



	}
}
