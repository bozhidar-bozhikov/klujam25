using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 wheelCenter;
    public float launchSpeed = 8f;
    public float gravity = 1f;

    public float drag = 0.1f;
    public float dragMultiplier = 1.1f;
    public bool increaseDrag = true;

    private bool hasLanded = false;
    private bool isSpinning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        isSpinning = true;

        rb.isKinematic = false;
        rb.drag = drag;
        rb.angularDrag = drag;

        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float startRadius = 4.2f;

        transform.position = wheelCenter + new Vector3(
            Mathf.Cos(randomAngle) * startRadius,
            Mathf.Sin(randomAngle) * startRadius,
            0
        );

        Vector2 tangent = new Vector2(-Mathf.Sin(randomAngle), Mathf.Cos(randomAngle));
        rb.velocity = tangent * launchSpeed;
    }

    void FixedUpdate()
    {
        if (hasLanded) return;

        // Simulate gravity pulling ball toward center
        Vector2 toCenter = (wheelCenter - transform.position).normalized;
        float distanceFromCenter = Vector2.Distance(transform.position, wheelCenter);

        float gravityStrength = gravity * (1 - (rb.velocity.magnitude / launchSpeed));
        rb.AddForce(toCenter * gravityStrength);

        // Apply air resistance
        rb.velocity *= 0.995f;

        if (isSpinning && increaseDrag)
        {
            rb.drag *= dragMultiplier;
            rb.angularDrag *= dragMultiplier;
        }
    }
}
