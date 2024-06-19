using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fallingdeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            SceneManager.LoadScene("Level");
        }
    }
}
