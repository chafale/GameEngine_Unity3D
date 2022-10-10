// not using this for health
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int lives = 3;
    [SerializeField] TextMeshProUGUI livesScore;

    void Start()
    {
        livesScore = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        livesScore.text = "Lives: " + lives.ToString();
    }
}
