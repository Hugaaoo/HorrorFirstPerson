using UnityEngine;

public class ZoneActivationDesactivation : MonoBehaviour
{
    // Liste des objets � d�sactiver
    public GameObject[] objetsADesactiver;

    // Liste des objets � activer
    public GameObject[] objetsAActiver;

    // Son � jouer lors de la d�sactivation
    public AudioClip sonADesactiver;

    // AudioSource pour le son de la zone
    public AudioSource sourceAudioZone;

    void Start()
    {
        // Assurez-vous qu'une AudioSource est attach�e � cet objet
        if (sourceAudioZone == null)
        {
            Debug.LogError("Veuillez assigner une AudioSource dans l'�diteur Unity.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // V�rifie si le joueur entre dans la zone
        if (other.CompareTag("Player"))
        {
            // D�sactive chaque objet dans la liste � d�sactiver
            foreach (GameObject objet in objetsADesactiver)
            {
                if (objet != null)
                {
                    objet.SetActive(false);
                    Debug.Log("Objet d�sactiv� : " + objet.name);
                }
            }

            // Active chaque objet dans la liste � activer
            foreach (GameObject objet in objetsAActiver)
            {
                if (objet != null)
                {
                    objet.SetActive(true);
                    Debug.Log("Objet activ� : " + objet.name);
                }
            }

            // Joue le son lors de la d�sactivation � partir de l'AudioSource sp�cifi�e
            if (sonADesactiver != null && sourceAudioZone != null)
            {
                sourceAudioZone.PlayOneShot(sonADesactiver);
                Debug.Log("Son jou� : " + sonADesactiver.name);

                // D�truit la zone apr�s la dur�e du son
                Invoke("DetruireZone", sonADesactiver.length);
            }
        }
    }

    void DetruireZone()
    {
        Destroy(gameObject);
    }
}
