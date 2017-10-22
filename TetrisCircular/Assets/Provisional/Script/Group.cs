using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

	private const float STORE_SPEED = 300.0f;

	public GameObject BlockPrefab;
    public enum Dpad { None, Right, Left, Up, Down };
    private bool flag = true;
    private Dpad control = Dpad.None;

	public ColorManager.BlockColor _pieceColor;
	public ColorManager.BlockColor PieceColor {
		get { return _pieceColor; }
		set { _pieceColor = value; }
	}

	// Time since last gravity tick
	float lastFall = 0;
	bool playing = false;

	private Coroutine movementCoroutine;

	public void startPlaying () {
		playing = true;
	}

	public void goToSpawner () {
		if (movementCoroutine != null)
			StopCoroutine (movementCoroutine);

		Spawner _spawner = FindObjectOfType<Spawner> ();
		Vector3 _destination = _spawner.transform.position;
		movementCoroutine = StartCoroutine (movePieceCoroutine (_destination, true));
	}

	public void goToNextPieceContainer () {
		if (movementCoroutine != null)
			StopCoroutine (movementCoroutine);
		
		NextTetrominoManager _nextPieceManager = FindObjectOfType<NextTetrominoManager> ();
		Vector3 _destination = _nextPieceManager.NextTetrominoPos.position;
		movementCoroutine = StartCoroutine (movePieceCoroutine (_destination, false));
	}
		
	private IEnumerator movePieceCoroutine (Vector3 _destination, bool _enableWhenFinished) {
		
		while (true) {
			Vector3 _movementVector = _destination - transform.localPosition;
			float _displacement = Time.deltaTime * STORE_SPEED;
			float _currentDistance = _movementVector.magnitude;

			if (_currentDistance < _displacement) {
				transform.localPosition = _destination;
				movementCoroutine = null;

				if (_enableWhenFinished)
					startPlaying ();
				break;
			}

			_movementVector = _movementVector * _displacement / _currentDistance;

			transform.localPosition = transform.localPosition + _movementVector;

			yield return null;
		}
	}
      
    void izquierda()
        {
        if (isValidGridPos())
         {
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
         }
        }


        void derecha()
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (isValidGridPos())
                // It's valid. Update grid.
                updateGrid();
            else
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
        }


        void rotar()
        {
            rotateGroup();
        }

    void bajar()
    {
        
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                Grid.deleteFullRows();

                // Spawn next Group
                FindObjectOfType<Spawner>().spawnNext();

                // Leave children in the grid and die
                unlinkChildren();
                Destroy(gameObject);

            lastFall = Time.time;
        }
    }


        bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);

			// Not inside Border?
			if (!Grid.insideBorder(v))
				return false;

			// Block in grid cell (and not part of same group)?
			if (Grid.grid[(int)v.x, (int)v.y] != null &&
				Grid.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid() {
		// Remove old children from grid
		for (int y = 0; y < Grid.h; ++y)
			for (int x = 0; x < Grid.w; ++x)
				if (Grid.grid[x, y] != null)
				if (Grid.grid[x, y].parent == transform)
					Grid.grid[x, y] = null;

		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid [(int)v.x, (int)v.y] = child.transform;
		}        
	}

	void unlinkChildren() {
		List<Transform> children = new List<Transform> ();
		foreach (Transform t in transform) {
			children.Add (t);
		}

		foreach (Transform t in children) {
			t.SetParent (null, true);
		}
	}

	void rotateGroup() {
		transform.Rotate(0, 0, -90);

		// See if valid
		if (isValidGridPos ()) {
			// It's valid. Update grid.
			updateGrid ();

			foreach (Transform t in transform) {
				t.Rotate (0, 0, 90);
			}
		}
		else
			// It's not valid. revert.
			transform.Rotate(0, 0, 90);
	}

	Group () {
		PieceColor = ColorManager.BlockColor.UNKNOWN;
	}

	// Use this for initialization
	void Start () {
		ColorManager.BlockColor _groupColor = PieceColor == ColorManager.BlockColor.UNKNOWN ? ColorManager.Instance.GetRandomColor () : PieceColor;
		foreach (Transform child in transform) {
			GameObject _block = Instantiate (BlockPrefab);
			_block.transform.SetParent (child, false);
			_block.GetComponent<Block>().BlockColor = _groupColor;
		}

		// Default position not valid? Then it's game over
		if (playing && !isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}

    void PadControl()
    {
        if (Input.GetAxis("PadX") == 0.0)
        {
            control = Dpad.None;
            flag = true;
        }

        if (Input.GetAxis("PadX") == 1f && flag)
        {
            StartCoroutine("DpadControl", Dpad.Right);
        }
        if (Input.GetAxis("PadX") == -1f && flag)
        {
            StartCoroutine("DpadControl", Dpad.Left);
        }
        if (Input.GetAxis("PadY") == 1f && flag)
        {
            StartCoroutine("DpadControl", Dpad.Up);
        }
        if (Input.GetAxis("PadY") == -1f)
        {
            StartCoroutine("DpadControl", Dpad.Down);

        }
    }

    // your methods can go nice and easy here ! 
    IEnumerator DpadControl(Dpad value)
    {
        flag = false;
        yield return new WaitForSeconds(0.15f); // delay it as you wish 
        if (value == Dpad.Right) derecha();  //** go right
        if (value == Dpad.Left) izquierda();  //** go left
        if (value == Dpad.Up) rotateGroup();  //** go up
        if (value == Dpad.Down) bajar(); //** go down

        StopCoroutine("DpadControl");
    }

    // Update is called once per frame
    void Update() {
		if (playing) {
			// Move Left
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				// Modify position
				transform.position += new Vector3 (-1, 0, 0);

				// See if valid
				if (isValidGridPos ())
				// It's valid. Update grid.
				updateGrid ();
				else
				// It's not valid. revert.
				transform.position += new Vector3 (1, 0, 0);
			}

			// Move Right
			else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				// Modify position
				transform.position += new Vector3 (1, 0, 0);

				// See if valid
				if (isValidGridPos ())
				// It's valid. Update grid.
				updateGrid ();
				else
				// It's not valid. revert.
				transform.position += new Vector3 (-1, 0, 0);
			}

			// Rotate
			else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				rotateGroup ();
			}

			// Move Downwards and Fall
			else if (Input.GetKey (KeyCode.DownArrow) ||
			        Time.time - lastFall >= 1) {
				// Modify position
				transform.position += new Vector3 (0, -1, 0);

				// See if valid
				if (isValidGridPos ()) {
					// It's valid. Update grid.
					updateGrid ();
				} else {
					// It's not valid. revert.
					transform.position += new Vector3 (0, 1, 0);

					// Clear filled horizontal lines
					Grid.deleteFullRows ();

					// Spawn next Group
					FindObjectOfType<Spawner> ().spawnNext ();

					// Leave children in the grid and die
					unlinkChildren ();
					Destroy (gameObject);
				}

				lastFall = Time.time;
            }
            else
            {
                PadControl();
            }
        }
	}
}
