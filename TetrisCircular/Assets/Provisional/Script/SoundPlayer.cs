using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public AudioClip slurpAudio;
	public AudioClip fallingPieceAudio;
	public AudioClip chainsawAudio;

	private AudioSource audioSource;

	private static SoundPlayer _instance;
	public static SoundPlayer Instance {
		get { return _instance; }
		private set { _instance = value; }
	}

	public void playChainsaw () {
		audioSource.PlayOneShot (chainsawAudio);
	}

	public void playSlurp () {
		audioSource.PlayOneShot (slurpAudio);
	}

	public void playFallingPiece () {
		audioSource.PlayOneShot (fallingPieceAudio);
	}

	void Awake () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);

			audioSource = GetComponent<AudioSource> ();
		} else
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
