using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitGenerator : MonoBehaviour {

	public int gridSize = 5;
	public int height = 1;
	public int width = 1;

	private GameObject[,] fruits;

	public GameObject banana;
	public GameObject apple;
	public GameObject mango;
	public GameObject lemon;

	void Awake(){
		fruits = new GameObject[gridSize,gridSize];
	}

	void instantiateFruit(GameObject fruitType, int x, int y) {
		fruits[x, y] = Instantiate (fruitType, new Vector3 (x * width, y * height, 0), Quaternion.identity);
		fruits [x, y].AddComponent<touchInput>();
	}

	// Use this for initialization
	void Start () {
		for(int x = 0;x<gridSize;x++){
			for(int y = 0; y<gridSize; y++){
				switch(Random.Range (0, 4)){
				case 0:
					instantiateFruit (banana, x, y);
					break;
				case 1:
					instantiateFruit (apple, x, y);
					break;
				case 2:
					instantiateFruit (mango, x, y);
					break;
				default:
					instantiateFruit (lemon, x, y);
					break;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
