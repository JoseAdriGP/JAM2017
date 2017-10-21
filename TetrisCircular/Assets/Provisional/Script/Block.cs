using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private SpriteRenderer renderer;

	private ColorManager.BlockColor _blockColor;
	public ColorManager.BlockColor BlockColor {
		get { return _blockColor; }
		set {
			_blockColor = value;
			renderer.sprite = ColorManager.Instance.SpritesByColor [_blockColor];
		}
	}

	void Awake () {
		renderer = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
