using UnityEngine;
using System.Collections;

public class GenderRandomizor : MonoBehaviour {

public bool gender;

	// Use this for initialization
	void Start () {
		int rnd = Random.Range(1,3); //3 never shows up
		if(rnd == 1) //1 for male
			gender = true;
		else gender = false; //2 for female
	
		print(rnd);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
