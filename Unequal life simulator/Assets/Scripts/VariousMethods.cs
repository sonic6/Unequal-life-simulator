using UnityEngine;

public class VariousMethods : MonoBehaviour
{
    public void SaveSelf() //Save this game object in a variable inside an FSM
    {
        GetComponent<PlayMakerFSM>().FsmVariables.GetFsmGameObject("me").Value = gameObject;
    }

    public void CheckChild()
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
}
