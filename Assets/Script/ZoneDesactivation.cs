using UnityEngine;

public class ZoneDesactivation : MonoBehaviour
{
    // Liste des objets � d�sactiver
    public GameObject[] objetsADesactiver;

    void OnTriggerEnter(Collider other)
    {
        // V�rifie si le joueur entre dans la zone
        if (other.CompareTag("Player"))
        {
            // D�sactive chaque objet dans la liste
            foreach (GameObject objet in objetsADesactiver)
            {
                if (objet != null)
                {
                    objet.SetActive(false);
                    Debug.Log("Objet d�sactiv� : " + objet.name);
                }
            }
        }
    }
}
