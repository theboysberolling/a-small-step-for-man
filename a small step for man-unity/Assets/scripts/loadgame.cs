using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadgame : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
