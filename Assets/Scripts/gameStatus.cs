using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using des = Destroy;

public class gameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] TextMeshProUGUI statusText;

    public static gameStatus gameStatusObj;

    void Awake()
    {
        gameStatusObj = this;
    }
    void Start()
    {
        statusText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void updateStatus()
    {
        
            statusText.text = "Congratulations!\n You Win!";
 
    }
}
