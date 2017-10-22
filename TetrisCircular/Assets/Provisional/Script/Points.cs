using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	public TextMesh counter;
	public static int puntos;


	// Use this for initialization
	void Start () {
		puntos = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter.GetComponent<TextMesh>().text = puntos.ToString();	
	}
}
