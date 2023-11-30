using TMPro;
using UnityEngine;

public class ZoneFonduTexteEtPanneau : MonoBehaviour
{
    public TextMeshProUGUI texteMeshPro;
    public GameObject panneau;
    public KeyCode toucheOuverture = KeyCode.E;
    public float vitesseFondu = 0.5f;

    private bool joueurDansZone = false;
    private bool panneauOuvert = false;

    private void Start()
    {
        // Assurez-vous qu'un TextMeshProUGUI est attaché ou référencé dans l'éditeur Unity
        if (texteMeshPro == null)
        {
            Debug.LogError("Veuillez assigner un TextMeshProUGUI dans l'éditeur Unity.");
        }
        texteMeshPro.alpha = 0;
        // Assurez-vous qu'un panneau est assigné dans l'éditeur Unity
        if (panneau == null)
        {
            Debug.LogError("Veuillez assigner un panneau dans l'éditeur Unity.");
        }
        else
        {
            // Désactive le panneau au démarrage
            panneau.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre dans la zone
        if (other.CompareTag("Player"))
        {
            joueurDansZone = true;
            // Démarre le fondu en augmentant l'alpha du TextMeshProUGUI du texte
            StartCoroutine(FaireFondu(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Vérifie si le joueur sort de la zone
        if (other.CompareTag("Player"))
        {
            joueurDansZone = false;
            // Démarre le fondu en diminuant l'alpha du TextMeshProUGUI du texte
            StartCoroutine(FaireFondu(false));

            // Ferme le panneau s'il est ouvert
            if (panneauOuvert)
            {
                FermerPanneau();
            }
        }
    }

    private void Update()
    {
        // Vérifie si la touche d'ouverture est enfoncée et si le joueur est dans la zone
        if (joueurDansZone && Input.GetKeyDown(toucheOuverture))
        {
            if (!panneauOuvert)
            {
                OuvrirPanneau();
            }
            else
            {
                FermerPanneau();
            }
        }
    }

    private System.Collections.IEnumerator FaireFondu(bool fadeIn)
    {
        float targetAlpha = fadeIn ? 1f : 0f;
        float startAlpha = texteMeshPro.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < vitesseFondu)
        {
            texteMeshPro.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / vitesseFondu);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        texteMeshPro.alpha = targetAlpha;
    }

    private void OuvrirPanneau()
    {
        panneau.SetActive(true);
        panneauOuvert = true;
    }

    private void FermerPanneau()
    {
        panneau.SetActive(false);
        panneauOuvert = false;
    }
}
