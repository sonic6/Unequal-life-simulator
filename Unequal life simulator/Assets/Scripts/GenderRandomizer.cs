using UnityEngine;
using UnityEngine.UI;

public class GenderRandomizer : MonoBehaviour {

	public bool gender;
	public Sprite[] character;
	public SpriteRenderer player;

    public Button[] boyLevels;
    public Button[] girlLevels;

    int rnd;

    // Use this for initialization
    void Start () {

        if (PlayerPrefs.HasKey("gender") == false)
        {
            rnd = Random.Range(1, 3); //3 never shows up
            PlayerPrefs.SetInt("gender", rnd);
        }
        else
            rnd = PlayerPrefs.GetInt("gender");


        if (rnd == 1) //1 for male
        {
            player.sprite = character[0];
            girlLevels[0].interactable = false;
            girlLevels[1].interactable = false;
            girlLevels[2].interactable = false;
        }
        else
        {
            player.sprite = character[1]; //2 for female
            boyLevels[0].interactable = false;
            boyLevels[1].interactable = false;
            boyLevels[2].interactable = false;
        }


		

        if (PlayerPrefs.HasKey("age"))
        {
            if (PlayerPrefs.GetInt("age") == 0)
                BecomeTeen();
            else if(PlayerPrefs.GetInt("age") == 1)
                BecomeAdult();
        }
        
	}

    void BecomeTeen()
    {
        PlayerPrefs.SetInt("age", 1);
        boyLevels[0].gameObject.SetActive(false);
        girlLevels[0].gameObject.SetActive(false);

        boyLevels[1].gameObject.SetActive(true);
        girlLevels[1].gameObject.SetActive(true);

        if (rnd == 1) //boy
        {
            player.sprite = character[2];
            
            girlLevels[1].interactable = false;
        }
        else //girl
        {
            player.sprite = character[3];

            boyLevels[1].interactable = false;
        }
    }

    void BecomeAdult()
    {
        PlayerPrefs.SetInt("age", 2);
        boyLevels[2].gameObject.SetActive(false);
        girlLevels[2].gameObject.SetActive(false);

        boyLevels[2].gameObject.SetActive(true);
        girlLevels[2].gameObject.SetActive(true);

        if (rnd == 1) //boy
        {
            player.sprite = character[4];

            girlLevels[2].interactable = false;
        }
        else //girl
        {
            player.sprite = character[5];

            boyLevels[2].interactable = false;
        }
    }


	
}
