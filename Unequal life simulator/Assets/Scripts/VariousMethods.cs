using UnityEngine;
using UnityEngine.UI;
using HutongGames.PlayMaker;

public class VariousMethods : MonoBehaviour
{
    public void SaveSelf() //Save this game object in a variable inside an FSM
    {
        GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("me").Value = gameObject;
    }

    public void CheckChild() //manages clothes placement on doll in doll level
    {
        VariousMethods[] childs = transform.parent.GetComponentsInChildren<VariousMethods>();
        for (int i = 0; i < childs.Length -1; i++)
        {
            if (transform.parent.GetChild(i) != gameObject.transform)
            {
                Transform otherCloth = transform.parent.GetChild(0);
                Vector3 home = otherCloth.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmVector3("home").Value;
                otherCloth.transform.position = home;
                otherCloth.transform.parent = null;
            }
        }
    }

    public void JudgeClothing(int outfit)
    {
        int formal = 0;
        int casual = 0;
        int princess = 0;
        

        Transform[] children = gameObject.GetComponentsInChildren<Transform>();

        foreach(Transform child in children)
        {
            if(child.name.Contains("formal") || child.name.Contains("slippers"))
            {
                formal++;
            }
            if (child.name.Contains("princess") || child.name.Contains("slippers"))
            {
                princess++;
            }
            if (child.name.Contains("casual") || child.name.Contains("boots") || child.name.Contains("slippers"))
            {
                casual++;
            }
        }

        int[] selected = { casual, princess, formal }; //important that they stay in this order to work with fsm
        int score = selected[outfit];
        FsmVariables.GlobalVariables.FindVariable("finalScore").RawValue = score;

    }

    public void CountFCoins(GameObject coinText) //to get coins from doll game
    {
        int current = int.Parse(coinText.GetComponent<Text>().text);
        int gained = PlayerPrefs.GetInt("F_money");

        coinText.GetComponent<Text>().text = (current + gained).ToString();
    }

    public void CountMCoins(GameObject coinText) //to get coins from car game
    {
        int current = int.Parse(coinText.GetComponent<Text>().text);
        int gained = PlayerPrefs.GetInt("M_money");

        coinText.GetComponent<Text>().text = (current + gained).ToString();
    }

    public void SwitchTrigger()
    {
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
    }


}
