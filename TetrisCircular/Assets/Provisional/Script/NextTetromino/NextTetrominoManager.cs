using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTetrominoManager : MonoBehaviour
{

	// Use this for initialization
	private Group NextTetromino;

	public Transform NextTetrominoPos;

	private bool ThereIsATetromino = false;


	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void NextTetrominoModel (Group Tetromino)
	{
		NextTetromino = Tetromino;

		ThereIsATetromino = true;

	}

	public bool CheckIfTetroAvailable ()
	{
		return ThereIsATetromino;
	}
}
