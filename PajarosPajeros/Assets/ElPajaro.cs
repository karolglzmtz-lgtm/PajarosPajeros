using UnityEngine;
using System.Collections;

public class SlingshotReset : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody2D rb;
    private Vector2 startPosition;

    public float maxDistance = 3f;
    public float forceMultiplier = 10f;
    public float resetDelay = 3f; // tiempo antes de reiniciar

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        rb.isKinematic = true;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(mousePos);

            if (col != null && col.gameObject == gameObject)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            rb.isKinematic = false;

            Vector2 force = startPosition - (Vector2)transform.position;
            rb.linearVelocity = force * forceMultiplier;

            // 👉 iniciar reinicio
            StartCoroutine(ResetBird());
        }

        if (isDragging)
        {
            Vector2 direction = mousePos - startPosition;
            direction = Vector2.ClampMagnitude(direction, maxDistance);
            transform.position = startPosition + direction;
        }
    }

    IEnumerator ResetBird()
    {
        yield return new WaitForSeconds(resetDelay);

        // detener movimiento
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // regresar posición
        transform.position = startPosition;

        // volver a modo reposo
        rb.isKinematic = true;
    }
}