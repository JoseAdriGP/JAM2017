using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private static readonly Vector3 drainPosition = new Vector3(4.5f, -0.5f, 0.0f);
	private const float drainSpeed = 10.0f;

	private SpriteRenderer renderer;

	private ColorManager.BlockColor _blockColor;
	public ColorManager.BlockColor BlockColor {
		get { return _blockColor; }
		set {
			_blockColor = value;
			renderer.sprite = ColorManager.Instance.SpritesByColor [_blockColor];
		}
	}

	private IEnumerator movementCoroutine () {
		while (true) {
			Vector3 _movementVector = drainPosition - transform.parent.localPosition;
			float _displacement = Time.deltaTime * drainSpeed;
			float _currentDistance = _movementVector.magnitude;

			if (_currentDistance < _displacement) {
				transform.parent.localPosition = drainPosition;
				break;
			}

			_movementVector = _movementVector * _displacement / _currentDistance;

			transform.parent.localPosition = transform.parent.localPosition + _movementVector;

			yield return null;
		}
	}

	public void drain () {
		++renderer.sortingOrder;
		StartCoroutine (movementCoroutine ());
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
