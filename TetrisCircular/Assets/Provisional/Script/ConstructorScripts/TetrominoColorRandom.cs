using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoColorRandom : MonoBehaviour
{

	// Use this for initialization

	void Start ()
	{
		AsignRandomColor ();
		SetTetrominoForm ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void SetTetrominoForm ()
	{
		 
		transform.GetChild (0).gameObject.GetComponent<RectTransform> ().anchoredPosition = FindObjectOfType< TetrominosList> ().MinoPos [0].mino1;

		transform.GetChild (1).gameObject.GetComponent<RectTransform> ().anchoredPosition = FindObjectOfType< TetrominosList> ().MinoPos [0].mino2;

		transform.GetChild (2).gameObject.GetComponent<RectTransform> ().anchoredPosition = FindObjectOfType< TetrominosList> ().MinoPos [0].mino3;

		transform.GetChild (3).gameObject.GetComponent<RectTransform> ().anchoredPosition = FindObjectOfType< TetrominosList> ().MinoPos [0].mino4;
	}

	void AsignRandomColor ()
	{
	
	
		for (int i = 0; i < transform.childCount; i++) {
		
			transform.GetChild (i).GetComponent<SpriteRenderer> ().color = RandomColor ();
		
		
		
		
		}
	
	
	
	}

	private Color RandomColor ()
	{
	
		Color RndColor = Color.white;
		int randomNumber = Random.Range (1, 5);

		switch (randomNumber) {

		case 1:
			RndColor = Color.blue;
			break;
		case 2:
			RndColor = Color.green;
			break;

		case 3:
			RndColor = Color.red;
			break;
		case 4:
			RndColor = Color.yellow;
			break;


		}
	
	
	
	
		return RndColor;
	}

}
