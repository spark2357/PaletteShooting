using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CoverImage;
    // Start is called before the first frame update
    public void OnClickStartButton()
    {
        CoverImage.SetActive(false);
    }
}
