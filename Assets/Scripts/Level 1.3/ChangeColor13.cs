using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor13 : MonoBehaviour
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        // rend.material.color = new Color(278, 41, 90);
        rend.material.SetColor("_Color", new Color(1, 0, 0, 1));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
