using UnityEngine;

public class DetectTile : MonoBehaviour
{
    public GameObject player;

    RaycastHit2D hit;

    

    void CastRay()
    {
        hit = Physics2D.Raycast(player.transform.position, transform.forward);
        Debug.DrawRay(player.transform.position, transform.forward, Color.red);

        
        if (hit.collider == null)
        {
            player.GetComponent<PlayMakerFSM>().SendEvent("Lose");
        }
    }


    private void Update()
    {
        CastRay();
    }
}
