using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoColor : MonoBehaviour
{

	// Use this for initialization
	public string colorAsignado;
	public int TetrominoModel = 0;

	[Header ("Block Sprites")]
	public Sprite ColorRed;
	public Sprite ColorAmarillo;
	public Sprite ColorVerde;
	public Sprite ColorAzul;

	private NextTetrominoManager tetrominoManager;

	private Spawner.Shape getShapeForTetrominoIndex (int _i)
	{
		switch (_i) {
		case 0:
			return Spawner.Shape.I;
		case 1:
			return Spawner.Shape.J;
		case 2:
			return Spawner.Shape.L;
		case 3:
			return Spawner.Shape.O;
		case 4:
			return Spawner.Shape.S;
		case 5:
			return Spawner.Shape.T;
		default:
			return Spawner.Shape.Z;
		}
	}

	private void createPiece (ColorManager.BlockColor _color)
	{
		Group _piece = FindObjectOfType<Spawner> ().spawn (getShapeForTetrominoIndex (TetrominoModel), transform.position);
		_piece.PieceColor = _color;
		tetrominoManager.NextTetrominoModel (_piece);
		_piece.goToNextPieceContainer ();
	}

	void Awake ()
	{
		tetrominoManager = FindObjectOfType<NextTetrominoManager> ();
	}

	void Start ()
	{
		AsignRandomColor ();
		SetTetrominoForm ();
	}

	// Update is called once per frame
	void Update ()
	{
		CheckInputColor ();
		MinoActive ();
		CheckInput ();
	}

	void SetTetrominoForm ()
	{

		transform.GetChild (0).gameObject.GetComponent<Transform> ().localPosition = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].mino1;

		transform.GetChild (1).gameObject.GetComponent<Transform> ().localPosition = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].mino2;

		transform.GetChild (2).gameObject.GetComponent<Transform> ().localPosition = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].mino3;

		transform.GetChild (3).gameObject.GetComponent<Transform> ().localPosition = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].mino4;

		if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].Color != null) {

			transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].Color;

			transform.GetChild (1).gameObject.GetComponent<SpriteRenderer> ().sprite = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].Color;

			transform.GetChild (2).gameObject.GetComponent<SpriteRenderer> ().sprite = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].Color;

			transform.GetChild (3).gameObject.GetComponent<SpriteRenderer> ().sprite = FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].Color;


		} else {
		
			AsignRandomColor ();
		
		
		}
	
	
	}

	void CheckInputColor ()
	{
		if (tetrominoManager.CheckIfTetroAvailable ())
			return;
		
		if (Input.GetKeyDown (KeyCode.A) || Input.GetButtonDown ("BotonA")) {
			//Verde
			if (CheckIfColorIsValid ("Verde")) {
				if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].ColorAsignado == "Verde") {
					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived < 4) {
						CurrentColorsManager.MinoVerde--;

						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived] = 1; 

						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived++;

						FindObjectOfType <CurrentColorsManager> ().ShowCurrentMinos ();
					}
					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived == 4) {

						createPiece (ColorManager.BlockColor.GREEN);

						AsignRandomColor ();
						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived = 0;
						for (int i = 0; i < 4; i++) {
							FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [i] = 0; 
						}
					}
				}

			} else {
			
				print ("Color Verde Is not Valid");
			
			}

		} else if (Input.GetKeyDown (KeyCode.B) || Input.GetButtonDown ("BotonB")) {
			//Rojo
			if (CheckIfColorIsValid ("Rojo")) {
				if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].ColorAsignado == "Rojo") {

					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived < 4) {
				
						CurrentColorsManager.MinoRojo--;

						
						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived] = 1; 

						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived++;

						FindObjectOfType <CurrentColorsManager> ().ShowCurrentMinos ();
					}
					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived == 4) {

						createPiece (ColorManager.BlockColor.RED);

						AsignRandomColor ();
						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived = 0;
						for (int i = 0; i < 4; i++) {
							FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [i] = 0; 
						}
					}
				}

			} else {

				print ("Color Rojo Is not Valid");

			}

		} else if (Input.GetKeyDown (KeyCode.Y) || Input.GetButtonDown ("BotonY")) {
			//Amarillo
			if (CheckIfColorIsValid ("Amarillo")) {
				if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].ColorAsignado == "Amarillo") {
					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived < 4) {
						CurrentColorsManager.MinoAmarillo--;

						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived] = 1; 


						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived++;

						FindObjectOfType <CurrentColorsManager> ().ShowCurrentMinos ();
					}
					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived == 4) {

						createPiece (ColorManager.BlockColor.YELLOW);

						AsignRandomColor ();
						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived = 0;
						for (int i = 0; i < 4; i++) {
							FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [i] = 0; 
						}
					}
				}
			} else {

				print ("Color Amarillo Is not Valid");

			}

		} else if (Input.GetKeyDown (KeyCode.X) || Input.GetButtonDown ("BotonZ")) {
			//Azul
			if (CheckIfColorIsValid ("Azul")) {
				if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].ColorAsignado == "Azul") {
					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived < 4) {
						CurrentColorsManager.MinoAzul--;

						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived] = 1; 

						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived++;

						FindObjectOfType <CurrentColorsManager> ().ShowCurrentMinos ();
					}
					if (FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived == 4) {

						createPiece (ColorManager.BlockColor.BLUE);

						AsignRandomColor ();
						FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].NumActived = 0;
						for (int i = 0; i < 4; i++) {
							FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].MinoReady [i] = 0; 
						}
					}
				}
			} else {

				print ("Color Azul Is not Valid");

			}
		}


	
	
	
	
	}

	bool CheckIfColorIsValid (string color)
	{
	
		bool Valid = false;

		switch (color) {

		case "Rojo":
			if (CurrentColorsManager.MinoRojo > 0) {
			
				Valid = true;

			}
			break;
		case "Azul":
			if (CurrentColorsManager.MinoAzul > 0) {

				Valid = true;

			}
			break;
		case "Amarillo":
			if (CurrentColorsManager.MinoAmarillo > 0) {

				Valid = true;

			}
			break;

		case "Verde":
			if (CurrentColorsManager.MinoVerde > 0) {

				Valid = true;

			}
			break;



		}
		return Valid;
	
	
	
	
	}

	void AsignRandomColor ()
	{
		Sprite color = RandomColor ();

		for (int i = 0; i < transform.childCount; i++) {

			transform.GetChild (i).GetComponent<SpriteRenderer> ().sprite = color;




		}
		FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].Color = color;

		FindObjectOfType< TetrominosList> ().MinoPos [TetrominoModel].ColorAsignado = colorAsignado;


	}

	public void Right ()
	{
	
		if (TetrominoModel < FindObjectOfType<TetrominosList> ().MinoPos.Count - 1) {

			TetrominoModel++;
			SetTetrominoForm ();
		}
	
	}

	public void Left ()
	{

		if (TetrominoModel > 0) {

			TetrominoModel--;
			SetTetrominoForm ();
		}

	
	
	}

	void CheckInput ()
	{
		
		if (Input.GetButtonDown ("LTrigger")) {
			print ("Button1");
			Left ();
		
		
		}

		if (Input.GetButtonDown ("RTrigger")) {
			print ("Button2");

			Right ();

		}




	}

	void MinoActive ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			if (FindObjectOfType<TetrominosList> ().MinoPos [TetrominoModel].MinoReady [i] == 0) {
				Color MinoColor = transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().color;
				MinoColor.a = 0.5f;
				transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().color = MinoColor;
			} else {
				Color MinoColor = transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().color;
				MinoColor.a = 1f;
				transform.GetChild (i).gameObject.GetComponent<SpriteRenderer> ().color = MinoColor;
			
			
			
			}
		}
	
	
	
	}

	private Sprite RandomColor ()
	{

		Sprite RndColor = null;
		int randomNumber = Random.Range (1, 5);

		switch (randomNumber) {

		case 1:
			RndColor = ColorAzul;
			colorAsignado = "Azul";
			break;
		case 2:
			RndColor = ColorVerde;
			colorAsignado = "Verde";
			break;

		case 3:
			RndColor = ColorRed;
			colorAsignado = "Rojo";
			break;
		case 4:
			RndColor = ColorAmarillo;
			colorAsignado = "Amarillo";
			break;


		}




		return RndColor;
	}

}
