using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int goldIndex = 0;
    [SerializeField] TextMeshProUGUI goldText;
    public  static string[] goldList = {"Most Adapted Pet","Very Loyal","Human Friendly Animal"};

    public static goldScript goldObj;
    void Awake()
    {
        goldObj = this;
    }
    void Start()
    {
        goldText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void updateHint()
    {
        goldText.text = "New Hint: " + goldList[goldIndex].ToString();
    }
}
