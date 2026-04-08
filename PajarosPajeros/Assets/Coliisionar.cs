using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float breakForce = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > breakForce)
        {
            Destroy(gameObject);
        }
    }
}
