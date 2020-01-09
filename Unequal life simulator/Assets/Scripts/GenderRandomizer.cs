using UnityEngine;

public class GenderRandomizer : MonoBehaviour {

	public bool gender;
	public Sprite[] character;
	public SpriteRenderer player;

	// Use this for initialization
	void Start () {
		int rnd = Random.Range(1,3); //3 never shows up
		if (rnd == 1) //1 for male
			player.sprite = character[0];
		else player.sprite = character[1]; //2 for female

		PlayerPrefs.SetInt("gender", rnd);
	}
	
}
