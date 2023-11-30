using System.Collections;
using UnityEngine;

public class EffrayantClignotant : MonoBehaviour
{
    public Light myLight;
    public float clignotementSpeed = 1.0f;
    public float tempsAvantDebutClignotement = 1.0f;
    public float tempsDeClignotement = 3.0f;

    void Start()
    {
        Debug.Log("Script de clignotement démarré.");

        // Démarrer la coroutine après un certain délai
        StartCoroutine(CommencerClignotement());
    }

    IEnumerator CommencerClignotement()
    {
        Debug.Log("Attente avant le début du clignotement...");

        // Attendre avant de commencer le clignotement
        yield return new WaitForSeconds(tempsAvantDebutClignotement);

        Debug.Log("Début du clignotement.");

        // Boucle de clignotement
        while (true)
        {
            // Activer la lumière
            myLight.enabled = true;

            Debug.Log("Lumière allumée.");

            // Attendre pendant la durée du clignotement
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            // Désactiver la lumière
            myLight.enabled = false;

            Debug.Log("Lumière éteinte.");

            // Attendre pendant la durée du clignotement éteint
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            // Répéter le clignotement pendant le tempsDeClignotement spécifié
            yield return new WaitForSeconds(tempsDeClignotement);
        }
    }
}
