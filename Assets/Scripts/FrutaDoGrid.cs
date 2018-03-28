using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaDoGrid : MonoBehaviour {

	int x, y;
	GameObject prefabFruta;

	public FrutaDoGrid(int vx, int vy, GameObject vprefabFruta){
		x = vx;
		y = vy;
		prefabFruta = vprefabFruta;
	}

	public int GetX(){
		return x;
	}

	public int GetY(){
		return y;
	}

	public void SetX(int vx){
		x = vx;
	}

	public void SetY(int vy){
		y = vy;
	}


		
}
