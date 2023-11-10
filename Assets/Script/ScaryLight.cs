using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ScaryLightFlicker : MonoBehaviour
{
    public float flickerInterval = 0.1f; // Intervalle de clignotement
    public float flickerDuration = 2f; // Dur�e totale de clignotement
    public List<Light> lights; // Liste des lumi�res � faire clignoter

    void Start()
    {
        // V�rifier si la liste des lumi�res est nulle
        if (lights == null)
        {
            Debug.LogError("Liste des lumi�res non d�finie. Veuillez assigner les lumi�res dans l'�diteur Unity.");
            return;
        }

        // Lancer la coroutine de clignotement
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // D�sactiver toutes les lumi�res de mani�re al�atoire pendant un bref moment
            foreach (Light lightComponent in lights)
            {
                if (lightComponent != null)
                    lightComponent.enabled = false;
            }

            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));

            // R�activer toutes les lumi�res
            foreach (Light lightComponent in lights)
            {
                if (lightComponent != null)
                    lightComponent.enabled = true;
            }

            yield return new WaitForSeconds(flickerInterval);

            // Attendre la dur�e totale de clignotement
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}
