using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public enum Shape {
		I,
		J,
		L,
		O,
		S,
		T,
		Z
	}

	// Groups
	public GameObject[] groups;

	public Group spawn(Shape _shape, Vector3 _pos) {
		return Instantiate (groups [System.Int32.Parse(_shape.ToString("d"))],
			_pos,
			Quaternion.identity).GetComponent<Group> ();
	}

	public Group spawnNext(){
		// Random Shape
		int i = Random.Range(0, groups.Length);
		Shape _shape = (Shape)System.Enum.Parse(typeof(Shape), ""+i);

		// Spawn Group at current Position
		Group _piece = spawn(_shape, transform.position);
		_piece.startPlaying ();
		return _piece;
	}
		
	// Spawn Group at current Position

	// Use this for initialization
	void Start () {
		// Spawn initial Group
		spawnNext();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
