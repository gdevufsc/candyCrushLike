using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitGenerator : MonoBehaviour {

	public int gridSize = 5;
	public int height = 1;
	public int width = 1;

	//private GameObject[,] fruits;
	private FrutaDoGrid[,] fruits;

	public GameObject banana;
	public GameObject apple;
	public GameObject mango;
	public GameObject lemon;

	void Awake(){
		fruits = new FrutaDoGrid[gridSize,gridSize];
	}

	// Use this for initialization
	void Start () {

		GameObject[] arrayDePrefabsFrutas = {banana, apple, mango, lemon} ; //novo

		for(int x = 0;x<gridSize;x++){
			for(int y = 0; y<gridSize; y++){

				//as próximas 4 linhas visam substituir o switch abaixo. Ainda não está funcionando. Não pode usar new para instanciar monobehaviour
				int numeroAleatorio = Random.Range (0, 4);
				Vector3 position = new Vector3 (x * width, y * height, 0);
				Quaternion rotacao = Quaternion.identity;
				print (arrayDePrefabsFrutas);
				fruits [x, y] = Instantiate (new FrutaDoGrid (x, y, arrayDePrefabsFrutas [numeroAleatorio]), position, rotacao);

				/*
				switch(Random.Range (0, 4)){
				case 0:
					fruits[x,y] = Instantiate (banana, new Vector3 (x * width, y * height, 0), Quaternion.identity);
					break;
				case 1:
					fruits[x,y] = Instantiate (apple, new Vector3 (x * width, y * height, 0), Quaternion.identity);
					break;
				case 2:
					fruits[x,y] = Instantiate (mango, new Vector3 (x * width, y * height, 0), Quaternion.identity);
					break;
				default:
					fruits[x,y] = Instantiate (lemon, new Vector3 (x * width, y * height, 0), Quaternion.identity);
					break;
				}
				*/
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
