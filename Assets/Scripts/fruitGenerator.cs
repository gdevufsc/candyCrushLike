using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitGenerator : MonoBehaviour {

	public int gridSize = 5;
	public int height = 1;
	public int width = 1;

	//private GameObject[,] fruits;
	//private FrutaDoGrid[,] fruits;

	public GameObject banana;
	public GameObject apple;
	public GameObject mango;
	public GameObject lemon;
	public GameObject GridFather;
	GameObject[] arrayDePrefabsFrutas = new GameObject[4];
	GameObject[,] GridDeFrutas;

	public enum DIRECTION{
		UP, DOWN, LEFT, RIGHT
	}

	void Awake(){
		GridDeFrutas = new GameObject[gridSize,gridSize];
	}

	// Use this for initialization
	void Start () {

		GameObject[] arrayDePrefabsFrutas = {banana, apple, mango, lemon} ; //novo

		//as próximas linhas visam substituir o switch abaixo.
		for (int x = 0; x < gridSize; x++) {
			for (int y = 0; y < gridSize; y++) {

				int numeroAleatorio = Random.Range (0, arrayDePrefabsFrutas.Length);
				Vector3 position = new Vector3 (x * width, y * height, 0);
				Quaternion rotacao = Quaternion.identity;
				GridDeFrutas [x, y] = Instantiate (arrayDePrefabsFrutas [numeroAleatorio], position, rotacao);
				GridDeFrutas [x, y].transform.SetParent (GridFather.GetComponent<Transform>());
			}
		}

		for (int x = 0; x < gridSize; x++) {
			for (int y = 0; y < gridSize; y++) {
				Check (x, y);
			}
		}



       // print(GridDeFrutas[0,0]);
/*
        for (int i=0; i<5; i++)
        {
           print(GridDeFrutas[i, 0]);
            if (GridDeFrutas[i,0].GetComponent<Fruta>().tipoDeFruta == "Apple")
            {
                print("ok");
                //    GridDeFrutas[i - 1, 0] = null;
               // if (i > 0)
               // {
                    Destroy(GridDeFrutas[i - 1, 0]);
                    GridDeFrutas[i - 1, 0] = Instantiate(arrayDePrefabsFrutas[0], new Vector3((i-1) * width, 0, 0), Quaternion.identity);
                //}
            }
        }
 */
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
				}*/
	}

	/*
	public void VerificaETalvezDestroi(){
		ArrayList<GameObject> listaDeFrutas = new ArrayList<GameObject>;
		GameObject FrutaSendoVerificada = null;
		int ContadorDeFrutas = 0;
		for (int x = 0; x < gridSize; x++) {
			for (int y = 0; y < gridSize; y++) {
				if(ContadorDeFrutaas==0){
					FrutaSendoVerificada = GridDeFrutas [x, y];
					ContadorDeFrutas=1;
					listaDeFrutas.add(GridDeFrutas[x,y]);
				}
				else {
					if(FrutaSendoVerificada.GetComponent<Fruta>().type==GridDeFrutas[x,y].GetComponent<Fruta>().type){
						ContadorDeFrutas++;
						listaDeFrutas.add(GridDeFrutas[x,y]);
					}
					else {
						if (ContadorDeFrutas>2){
							for (GameObject f in listaDeFrutas){
								Destroy(f);
							}
						}
						else {
							ContadorDeFrutas =0;
						}
					}
					
				}
			}
		}
	}
	*/

	public int Count(int x, int y, DIRECTION dir){
		switch (dir) {
		case DIRECTION.UP:
			if (y == gridSize-1) {
				return 0;
			}
			if (GridDeFrutas [x, y].GetComponent<Fruta> ().type == GridDeFrutas [x, y + 1].GetComponent<Fruta> ().type) {
				return 1 + Count (x, y + 1, dir);
			} else {
				return 0;
			}
			

		case DIRECTION.DOWN:
			if (y == 0) {
				return 0;
			}
			if (GridDeFrutas [x, y].GetComponent<Fruta> ().type == GridDeFrutas [x, y - 1].GetComponent<Fruta> ().type) {
				return 1 + Count (x, y - 1, dir);
			} else {
				return 0;
			}

		case DIRECTION.LEFT:
			if (x == 0) {
				return 0;
			}
			if (GridDeFrutas [x, y].GetComponent<Fruta> ().type == GridDeFrutas [x-1, y].GetComponent<Fruta> ().type) {
				return 1 + Count (x-1,y, dir);
			} else {
				return 0;
			}

		case DIRECTION.RIGHT:
			if (x==gridSize-1) {
				return 0;
			}
			if (GridDeFrutas [x, y].GetComponent<Fruta> ().type == GridDeFrutas [x+1,y].GetComponent<Fruta> ().type) {
				return 1 + Count (x+1, y, dir);
			} else {
				return 0;
			}

		default:
			Debug.Log ("Grid nao detectou direcao do count");
			return 0;

		}
	}

	void Check(int x, int y){
		int[] count = new int[4];
		for (int i = 0; i < 4; i++) {
			count [i] = Count (x, y, (DIRECTION)i);
		}
		if(count[(int)DIRECTION.UP]+count[(int)DIRECTION.DOWN]>=2){
			Debug.Log("Combo Vertical nas coordenadas: " + x + "."+y);
		}
		if(count[(int)DIRECTION.LEFT]+count[(int)DIRECTION.RIGHT]>=2){
			Debug.Log("Combo Horizontal nas coordenadas: " + x + "."+y);
		}
		/*
		count [(int)DIRECTION.UP] = Count (x, y, DIRECTION.UP);
		count [(int)DIRECTION.DOWN] = Count (x, y, DIRECTION.DOWN);
		count [(int)DIRECTION.UP] = Count (x, y, DIRECTION.);
		count [(int)DIRECTION.UP] = Count (x, y, DIRECTION.UP);
		*/
	}
}