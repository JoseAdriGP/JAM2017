﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private static readonly Vector3 drainPosition = new Vector3(4.5f, -3.5f, 0.0f);
	private const float drainSpeed = 10.0f;

	private SpriteRenderer renderer;
	private Animator anim;

	private ColorManager.BlockColor _blockColor;
	public ColorManager.BlockColor BlockColor {
		get { return _blockColor; }
		set {
			_blockColor = value;
			renderer.sprite = ColorManager.Instance.SpritesByColor [_blockColor];
		}
	}

	public void finishDraining () {
		anim.enabled = false;
	}

	private IEnumerator movementCoroutine () {
		while (true) {
			Vector3 _movementVector = drainPosition - transform.localPosition;
			float _displacement = Time.deltaTime * drainSpeed;
			float _currentDistance = _movementVector.magnitude;

			if (_currentDistance < _displacement) {
				transform.localPosition = drainPosition;
				anim.enabled = true;
				break;
			}

			_movementVector = _movementVector * _displacement / _currentDistance;

			transform.localPosition = transform.localPosition + _movementVector;

			yield return null;
		}
	}

	public void drain () {
		++renderer.sortingOrder;
		StartCoroutine (movementCoroutine ());
	}

	void Awake () {
		renderer = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
