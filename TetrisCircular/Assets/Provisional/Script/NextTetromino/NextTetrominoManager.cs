using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTetrominoManager : MonoBehaviour
{

	// Use this for initialization
	private Group NextTetromino;

	public Transform NextTetrominoPos;

	private bool ThereIsATetromino = false;

    public AudioSource constructionAudio;


	void Start ()
	{
        constructionAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void NextTetrominoModel (Group Tetromino)
	{
		NextTetromino = Tetromino;

		ThereIsATetromino = true;

        constructionAudio.Play();
	}

	public Group ExtractTetromino ()
	{
		ThereIsATetromino = false;
		Group _next = NextTetromino;
		NextTetromino = null;
		return _next;
	}

	public bool CheckIfTetroAvailable ()
	{
		return ThereIsATetromino;
	}
}
