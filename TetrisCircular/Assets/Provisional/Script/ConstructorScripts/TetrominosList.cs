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


		public Color Color;

		public int[] MinoReady;

		public int NumActived = 0;

	}

	public  List <MinoPosInfo> MinoPos = new List<MinoPosInfo> ();

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
