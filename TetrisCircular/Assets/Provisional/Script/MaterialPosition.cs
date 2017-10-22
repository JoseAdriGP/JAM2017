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

	public GameObject malla;

	public TextMesh counter;

	private List<int> positionElements;
	private List<GameObject> elementList;

	// The funtion for generate de number of elements in radom position in a range we gave
	public void ElementGenerator(int elements){
		int selecter;
		int randPos;
		do{
			randPos = Random.Range(0, 72);
			if(!positionElements.Contains(randPos)){
				GameObject arbol = Instantiate(elementType, malla.transform.GetChild(randPos).gameObject.transform.position, Quaternion.identity);
				float scaleChanger;
				selecter = Random.Range(1, 8);

				switch (randPos/6){
				case 0:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 12;
					scaleChanger=1.0f;
					break;
				case 1:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 11;
					scaleChanger=0.9f;
					break;
				case 2:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 10;
					scaleChanger= 0.85f;
					break;
				case 3:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 9;
					scaleChanger= 0.8f;
					break;
				case 4:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 8;
					scaleChanger= 0.75f;
					break;
				case 5:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 7;
					scaleChanger= 0.7f;
					break;
				case 6:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 6;
					scaleChanger= 0.65f;
					break;
				case 7:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 5;
					scaleChanger= 0.6f;
					break;
				case 8:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 4;
					scaleChanger= 0.55f;
					break;
				case 9:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 3;
					scaleChanger= 0.5f;
					break;
				case 10:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 2;
					scaleChanger= 0.45f;
					break;
				case 11:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 1;
					scaleChanger= 0.4f;
					break;
				default:
					arbol.GetComponent<SpriteRenderer>().sortingOrder = 1;
					scaleChanger=1.0f;
					break;
				}

				arbol.GetComponent<Transform>().localScale = new Vector3(scaleChanger,scaleChanger,1);

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
					
				positionElements.Add(randPos);
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
				elementNumber -= elements;
			}
		} else {
			foreach (GameObject element in elementList)
			{
				Destroy (element,0.0f);
			}
			elementList.Clear ();
			elementNumber = 0;
		}
		updateTreeText ();
	}

	// Update the number of trees in the portview
	void updateTreeText(){
		counter.GetComponent<TextMesh>().text = elementNumber.ToString();
	}

	// Use this for initialization
	void Start () {
		positionElements = new List<int>();
		elementList = new List<GameObject>();
		ElementGenerator(elementNumber);
		updateTreeText ();
	}

	// At the init of the program
	void Awake(){
		if(elementNumber > 72 || elementNumber <= 0){
			elementNumber = 72;
		}
	}



	// Update is called once per frame
	void Update () {
	
	}
}
