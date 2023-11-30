using UnityEngine;

public class ZoneDesactivation : MonoBehaviour
{
    // Liste des objets à désactiver
    public GameObject[] objetsADesactiver;

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre dans la zone
        if (other.CompareTag("Player"))
        {
            // Désactive chaque objet dans la liste
            foreach (GameObject objet in objetsADesactiver)
            {
                if (objet != null)
                {
                    objet.SetActive(false);
                    Debug.Log("Objet désactivé : " + objet.name);
                }
            }
        }
    }
}
