using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float breakForce = 5f;
    public int points = 100;

    private bool destroyed = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!destroyed && collision.relativeVelocity.magnitude > breakForce)
        {
            destroyed = true;

            // 👉 sumar puntos
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(points);
            }

            Destroy(gameObject);
        }
    }
}
