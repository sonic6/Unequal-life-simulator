using UnityEngine;
using UnityEngine.UI;

public class Chearleading : MonoBehaviour
{
    [SerializeField] Text commands;
    [SerializeField] bool takeInput;

    string[] moves = { "up", "left", "right" };
    [SerializeField] string[] savedMoves = { "","",""};

    PlayMakerFSM myFsm;
    int myInt;

    private void Awake()
    {
        myFsm = GetComponent<PlayMakerFSM>();
    }

    public void Act() //PC makes leader do 3 dance moves
    {
        myInt = myFsm.FsmVariables.GetFsmInt("myInt").Value;
        savedMoves[myInt] = moves[Random.Range(0, 3)];
        myFsm.SendEvent(savedMoves[myInt]);
        commands.text = savedMoves[myInt];
        myFsm.FsmVariables.GetFsmInt("myInt").Value++;
    }

    public void Play() //pc waits for Player to immitate moves done by pc
    {
        if(myInt == 2)
        {
            myFsm.FsmVariables.GetFsmInt("myInt").Value = 0;
            myInt = 0;
            commands.text = "";
            takeInput = true;
            myFsm.SendEvent("wait");
        }
    }

    public void DoInput(int i)
    {
        string pressed = "";

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                pressed = moves[0];

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                pressed = moves[1];

            else if (Input.GetKeyDown(KeyCode.RightArrow))
                pressed = moves[2];

            if (pressed == savedMoves[i])
            {
                commands.text = savedMoves[i];
                commands.color = Color.green;
                myFsm.SendEvent("next");
            }
            else
            {
                commands.text = savedMoves[i];
                commands.color = Color.red;
                takeInput = false;
                myFsm.SendEvent("failed");
            }
        }
    
    }

    public void HideText()
    {
        commands.color = Color.white;
        commands.text = "";
    }

    private void Update()
    {
        if (takeInput == true)
            DoInput(myFsm.FsmVariables.GetFsmInt("keyInt").Value);
    }


}
