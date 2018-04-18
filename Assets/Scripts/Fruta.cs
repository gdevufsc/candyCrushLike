using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour {

    //public string tipoDeFruta;
	public enum FRUITTYPE
	{
		APPLE, BANANA, LEMON, MANGO
	}
	public FRUITTYPE type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TestaTrigger (){
		print ("trigger worked!");
	}
}
