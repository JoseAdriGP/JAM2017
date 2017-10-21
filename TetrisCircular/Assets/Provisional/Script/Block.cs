using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private static readonly Vector3 drainPosition = new Vector3(4.5f, -3.5f, 0.0f);
	private const float drainSpeed = 15.0f;

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

		StartCoroutine (accumulationCoroutine ());
	}

	private IEnumerator accumulationCoroutine () {
		TetrominosList _tetrominosList = FindObjectOfType<TetrominosList> ();
		Vector2 __counterPosition = _tetrominosList.GetPos (BlockColor);
		Vector3 _counterPosition = new Vector3 (__counterPosition.x, __counterPosition.y, 0.0f);
		while (true) {
			Vector3 _movementVector = _counterPosition - transform.localPosition;
			float _displacement = Time.deltaTime * drainSpeed;
			float _currentDistance = _movementVector.magnitude;

			if (_currentDistance < _displacement) {
				transform.localPosition = drainPosition;
				updateTetriminoCounters ();
				Destroy (gameObject);
				break;
			}

			_movementVector = _movementVector * _displacement / _currentDistance;

			transform.localPosition = transform.localPosition + _movementVector;

			yield return null;
		}
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

	private void updateTetriminoCounters ()
	{
		switch (BlockColor) {

		case ColorManager.BlockColor.RED:
			CurrentColorsManager.MinoRojo++;
			break;

		case ColorManager.BlockColor.BLUE:
			CurrentColorsManager.MinoAzul++;
			break;

		case ColorManager.BlockColor.GREEN:
			CurrentColorsManager.MinoVerde++;
			break;

		case ColorManager.BlockColor.YELLOW:
			CurrentColorsManager.MinoAmarillo++;
			break;
		}

		FindObjectOfType <CurrentColorsManager> ().ShowCurrentMinos ();
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
