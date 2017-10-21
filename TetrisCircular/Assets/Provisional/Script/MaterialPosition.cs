using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPosition : MonoBehaviour {

	// The kind of elements we are going to use in our field
	public Sprite elementSprite1;
	public Sprite elementSprite2;
	public Sprite elementSprite3;
	public Sprite elementSprite4;
	public Sprite elementSprite5;
	public Sprite elementSprite6;
	public Sprite elementSprite7;

	public GameObject elementType;
	public int elementNumber;

	public GameObject TopRightPosition;
	public GameObject BottomLeftPosition;


	private List<Vector3> positionElements = new List<Vector3>();
	private List<GameObject> elementList;

	// The funtion for generate de number of elements in radom position in a range we gave
	public void ElementGenerator(int elements){
		int selecter;
		Vector3 randVec;
		do{
			randVec = new Vector3(Random.Range(BottomLeftPosition.GetComponent<Transform>().position.x, TopRightPosition.GetComponent<Transform>().position.x), Random.Range(BottomLeftPosition.GetComponent<Transform>().position.y, TopRightPosition.GetComponent<Transform>().position.y), 0.0f);
			if(!positionElements.Contains(randVec)){
				GameObject arbol = Instantiate(elementType,randVec,Quaternion.identity);
				selecter = Random.Range(1, 8);

				switch (selecter){
					case 1:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite1;
						break;
					case 2:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite2;
						break;
					case 3:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite3;
						break;
					case 4:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite4;
						break;
					case 5:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite5;
						break;
					case 6:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite6;
						break;
					case 7:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite7;
						break;
					default:
						arbol.GetComponent<SpriteRenderer>().sprite = elementSprite7;
						break;
				}
					
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
		elementList = new List<GameObject>();
		ElementGenerator(elementNumber);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
