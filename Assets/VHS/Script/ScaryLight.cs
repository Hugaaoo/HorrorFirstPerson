using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ScaryLightFlicker : MonoBehaviour
{
    public float flickerInterval = 0.1f; // Intervalle de clignotement
    public float flickerDuration = 2f; // Durée totale de clignotement
    public List<Light> lights; // Liste des lumières à faire clignoter

    void Start()
    {
        // Vérifier si la liste des lumières est nulle
        if (lights == null)
        {
            Debug.LogError("Liste des lumières non définie. Veuillez assigner les lumières dans l'éditeur Unity.");
            return;
        }

        // Lancer la coroutine de clignotement
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // Désactiver toutes les lumières de manière aléatoire pendant un bref moment
            foreach (Light lightComponent in lights)
            {
                if (lightComponent != null)
                    lightComponent.enabled = false;
            }

            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));

            // Réactiver toutes les lumières
            foreach (Light lightComponent in lights)
            {
                if (lightComponent != null)
                    lightComponent.enabled = true;
            }

            yield return new WaitForSeconds(flickerInterval);

            // Attendre la durée totale de clignotement
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}
