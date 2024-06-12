using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{
    public animationStateController animationStateController;
    public AudioSource audioSource;
    public AudioClip sfx;
    public bool canPlay;
    public void Footstep()
    {
        PlayFootstepSound(sfx);
    }

    public void PlayFootstepSound(AudioClip audio)
    {
        


        if (animationStateController.animator.GetBool("isWalking"))
            
        {
            audioSource.pitch = Random.Range(0.8f, 1f); 
            audioSource.PlayOneShot(audio); 
        }
        
    }


    private void Update()
    {
        if (animationStateController.isWalking1)
        {
            canPlay = true;
        }
        else
        {
            canPlay = false;
        }
    }
}
