using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public VignetteScritp vignette;
    public MainManuDoor mainMenuDoor; 
  public void Play()



    {

        mainMenuDoor.playClicked = true;
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("player has quit");
    }

    public void LoadScene()
    {
        StartCoroutine(TimerOff1());
        
    }


    IEnumerator TimerOff1()
    {
        vignette.animator.SetBool("CameraChange", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);




    }
}
