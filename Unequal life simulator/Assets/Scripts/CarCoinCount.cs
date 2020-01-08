using UnityEngine.UI;
using UnityEngine;

public class CarCoinCount : MonoBehaviour
{
    public Text myText;
    public  PlayMakerFSM player;

    public void AddCoin()
    {
        string myInt = PlayMakerGlobals.Instance.Variables.GetFsmInt("coins").ToString();
        myText.text = " Coins: " + myInt;
    }
}
