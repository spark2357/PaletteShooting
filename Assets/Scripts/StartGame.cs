using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneName = "SampleScene";

    public void StartBtn()
    {
        Debug.Log("Ω√¿€");
        SceneManager.LoadScene(sceneName);
    }
}
