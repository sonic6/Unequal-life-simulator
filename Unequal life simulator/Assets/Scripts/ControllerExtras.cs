using UnityEngine;

public class ControllerExtras : MonoBehaviour
{
    public void FlipSprite()
    {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
}
