using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTetrominoManager : MonoBehaviour
{

	// Use this for initialization
	public GameObject NextTetromino;

	public Transform NextTetrominoPos;



	public bool ThereIsATetromino = false;


	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void NextTetrominoModel (GameObject Tetromino)
	{
		NextTetromino = Tetromino;
		
		Instantiate (Tetromino, NextTetrominoPos.position, Quaternion.identity);



		ThereIsATetromino = true;

	}

	public bool CheckIfTetroAvailable ()
	{
	
		bool Available = false;

		if (ThereIsATetromino == true) {
		
			Available = true;

			ThereIsATetromino = false;

			return Available;
		
		
		
		}


		return Available;
	
	
	
	
	}
}
