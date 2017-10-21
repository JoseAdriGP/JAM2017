using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominosList : MonoBehaviour
{

	// Use this for initialization
	[System.Serializable]
	public class MinoPosInfo
	{

		public Vector2 mino1;


		public Vector2 mino2;



		public Vector2 mino3;


		public Vector2 mino4;


		public string ColorAsignado;


		public Sprite Color;

		public int[] MinoReady;

		public int NumActived = 0;

	}

	public  List <MinoPosInfo> MinoPos = new List<MinoPosInfo> ();

	public Transform Amarillo;

	public Transform Verde;

	public Transform Rojo;

	public Transform Azul;


	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public Vector2 GetPos (ColorManager.BlockColor Color)
	{

		Vector2 Pos = new Vector2 (0, 0);

		switch (Color) {

		case ColorManager.BlockColor.YELLOW:
			Pos = Amarillo.position;
			break;

		case ColorManager.BlockColor.GREEN:
			Pos = Verde.position;
			break;

		case ColorManager.BlockColor.RED:
			Pos = Rojo.position;
			break;

		case ColorManager.BlockColor.BLUE:
			Pos = Azul.position;
			break;





		}
		return Pos;


	}
}
