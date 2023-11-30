using UnityEngine;

public class ZoneActivationDesactivation : MonoBehaviour
{
    // Liste des objets à désactiver
    public GameObject[] objetsADesactiver;

    // Liste des objets à activer
    public GameObject[] objetsAActiver;

    // Son à jouer lors de la désactivation
    public AudioClip sonADesactiver;

    // AudioSource pour le son de la zone
    public AudioSource sourceAudioZone;

    void Start()
    {
        // Assurez-vous qu'une AudioSource est attachée à cet objet
        if (sourceAudioZone == null)
        {
            Debug.LogError("Veuillez assigner une AudioSource dans l'éditeur Unity.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre dans la zone
        if (other.CompareTag("Player"))
        {
            // Désactive chaque objet dans la liste à désactiver
            foreach (GameObject objet in objetsADesactiver)
            {
                if (objet != null)
                {
                    objet.SetActive(false);
                    Debug.Log("Objet désactivé : " + objet.name);
                }
            }

            // Active chaque objet dans la liste à activer
            foreach (GameObject objet in objetsAActiver)
            {
                if (objet != null)
                {
                    objet.SetActive(true);
                    Debug.Log("Objet activé : " + objet.name);
                }
            }

            // Joue le son lors de la désactivation à partir de l'AudioSource spécifiée
            if (sonADesactiver != null && sourceAudioZone != null)
            {
                sourceAudioZone.PlayOneShot(sonADesactiver);
                Debug.Log("Son joué : " + sonADesactiver.name);

                // Détruit la zone après la durée du son
                Invoke("DetruireZone", sonADesactiver.length);
            }
        }
    }

    void DetruireZone()
    {
        Destroy(gameObject);
    }
}
