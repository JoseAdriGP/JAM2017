using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTetrominoManager : MonoBehaviour
{

	// Use this for initialization
	private GameObject NextTetromino;

	public Transform NextTetrominoPos;

	private bool ThereIsATetromino = false;


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
		return ThereIsATetromino;
	}
}
