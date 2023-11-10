using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public GameObject jumpScareImage;
    public AudioClip jumpScareSound;
    public float soundDelay = 0.5f; // Ajoutez cette variable pour d�finir le d�lai du son

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // D�marrer le son avec un d�lai
            if (jumpScareSound != null)
            {
                Invoke("PlayJumpScareSound", soundDelay);
            }

            // Afficher l'image du screamer
            if (jumpScareImage != null)
            {
                Invoke("ShowJumpScareImage", soundDelay);
            }

            hasTriggered = true;
        }
    }

    // Fonction pour d�marrer le son
    private void PlayJumpScareSound()
    {
        AudioSource.PlayClipAtPoint(jumpScareSound, transform.position);
    }

    // Fonction pour afficher l'image
    private void ShowJumpScareImage()
    {
        if (jumpScareImage != null)
        {
            jumpScareImage.SetActive(true);
        }
    }
}
