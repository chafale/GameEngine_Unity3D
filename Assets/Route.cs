using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Route : MonoBehaviour
{
    public void sc_ch(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
