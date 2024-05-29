using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;
    public DzbanScript dzbanScript;
    public animationStateController animationStateController;

    private void Start()
    {
        src.clip = sfx1;
        src.loop = true;
    }

    private void Update()
    {
        VasePushingSound();
    }


    void VasePushingSound()
    {
        {
            if (animationStateController.isPushing)
            {
                if (!src.isPlaying)
                {
                    src.clip = sfx1;
                    src.Play();
                    
                }
            }
            else
            {
                if (src.isPlaying)
                {
                    src.Stop();
                }
            }
        }
    }

}
