using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roulette : MonoBehaviour
{
    public GameObject pocketPrefab;
    private float pocketAngle = 360f / 37f;

    public Layout roulette;

    private EdgeCollider2D edgeCollider;

    // Start is called before the first frame update
    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();

        roulette = new Layout();

        for (int i = 0; i < roulette.pockets.Length; i++)
        {
            GameObject pocket = Instantiate(pocketPrefab, transform);

            Vector3 rotation = new Vector3(0, 0, i * pocketAngle);
            pocket.transform.eulerAngles = rotation;
            SpriteRenderer sprite = pocket.GetComponent<SpriteRenderer>();
            TextMeshPro text = pocket.GetComponentInChildren<TextMeshPro>();
            roulette.GetPocket(i).SetUI(sprite, text);
        }

        CreateOuterEdgeCollider(edgeCollider, 74, 4.5f);
    }

    public void CreateOuterEdgeCollider(EdgeCollider2D collider, int segments, float radius)
    {
        Vector2[] points = new Vector2[segments + 1];

        for (int i = 0; i < segments; i++)
        {
            float angle = (float)i / segments * 2f * Mathf.PI;
            points[i] = new Vector2(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius
            );
        }

        points[segments] = points[0];
        collider.points = points;
    }
}