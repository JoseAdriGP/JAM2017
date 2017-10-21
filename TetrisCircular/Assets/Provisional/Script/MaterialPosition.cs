using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPosition : MonoBehaviour {

	// The kind of elements we are going to use in our field
	public Sprite elementSprite;
	public GameObject elementType;
	public int elementNumber;

	public GameObject TopRightPosition;
	public GameObject BottomLeftPosition;

	private List<GameObject> elementList;

	// The funtion for generate de number of elements in radom position in a range we gave
	public void ElementGenerator(int elements){
		Vector3 randVec;
		List<Vector3> positionElements = new List<Vector3>();
		do{
			randVec = new Vector3(Random.Range(BottomLeftPosition.GetComponent<Transform>().position.x, TopRightPosition.GetComponent<Transform>().position.x), Random.Range(BottomLeftPosition.GetComponent<Transform>().position.x, TopRightPosition.GetComponent<Transform>().position.x), 0.0f);
			if(!positionElements.Contains(randVec)){
				GameObject arbol = Instantiate(elementType,randVec,Quaternion.identity);
				arbol.GetComponent<SpriteRenderer>().sprite = elementSprite;
				positionElements.Add(randVec);
				elementList.Add(arbol);
			}
		}while(positionElements.Count != elements);
	}

	// The funtion to eliminate a numeber of elements in our field
	public void deleteElements(int elements){
		if (elements < elementList.Count) {
			for(int i=0; i<elements; i++){
				Destroy(elementList[elementList.Count-1], 0.0f);
				elementList.RemoveAt (elementList.Count-1);
			}
		} else {
			foreach (GameObject element in elementList)
			{
				Destroy (element,0.0f);
			}
			elementList.Clear ();
		}
	}



	// Use this for initialization
	void Start () {
		elementNumber = 6;
		elementList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
