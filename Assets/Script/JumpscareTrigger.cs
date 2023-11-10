using UnityEngine;

public class JumpScareTrigger : MonoBehaviour
{
    public GameObject jumpScareImage;
    public AudioClip jumpScareSound;
    public float soundDelay = 0.5f; // Ajoutez cette variable pour définir le délai du son

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // Démarrer le son avec un délai
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

    // Fonction pour démarrer le son
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
