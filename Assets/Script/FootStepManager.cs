using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepSound;

    void Start()
    {
        footstepSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Vérifie si le joueur est en mouvement (change de position en X ou en Z)
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            PlayFootstepSound();
        }
        else
        {
            StopFootstepSound();
        }
    }

    void PlayFootstepSound()
    {
        if (!footstepSound.isPlaying)
        {
            footstepSound.Play();
        }
    }

    void StopFootstepSound()
    {
        if (footstepSound.isPlaying)
        {
            footstepSound.Stop();
        }
    }
}
