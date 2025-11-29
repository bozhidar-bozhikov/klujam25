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

    // Start is called before the first frame update
    void Start()
    {
        roulette = new Layout();

        for (int i = 0; i < roulette.pockets.Length; i++)
        {
            GameObject pocket = Instantiate(pocketPrefab, transform);

            Vector3 rotation = new Vector3(0, 0, i * pocketAngle);
            pocket.transform.eulerAngles = rotation;
            Image image = pocket.GetComponent<Image>();
            TextMeshProUGUI text = pocket.GetComponentInChildren<TextMeshProUGUI>();
            roulette.GetPocket(i).SetUI(image, text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}