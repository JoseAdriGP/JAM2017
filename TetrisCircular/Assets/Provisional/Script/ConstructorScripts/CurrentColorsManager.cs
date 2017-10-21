using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentColorsManager : MonoBehaviour
{

	// Use this for initialization

	//public Function

	[Header ("Text Show")]
	public Text CurrentRojo;
	public Text CurrentAzul;
	public Text CurrentAmarillo;
	public Text CurrentVerde;



	//Static Function
	public static int MinoRojo = 10;
	public static int MinoAzul = 10;
	public static int MinoAmarillo = 10;
	public static int MinoVerde = 10;



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
