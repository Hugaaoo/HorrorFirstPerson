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
        Debug.Log("Script de clignotement d�marr�.");

        // D�marrer la coroutine apr�s un certain d�lai
        StartCoroutine(CommencerClignotement());
    }

    IEnumerator CommencerClignotement()
    {
        Debug.Log("Attente avant le d�but du clignotement...");

        // Attendre avant de commencer le clignotement
        yield return new WaitForSeconds(tempsAvantDebutClignotement);

        Debug.Log("D�but du clignotement.");

        // Boucle de clignotement
        while (true)
        {
            // Activer la lumi�re
            myLight.enabled = true;

            Debug.Log("Lumi�re allum�e.");

            // Attendre pendant la dur�e du clignotement
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            // D�sactiver la lumi�re
            myLight.enabled = false;

            Debug.Log("Lumi�re �teinte.");

            // Attendre pendant la dur�e du clignotement �teint
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

            // R�p�ter le clignotement pendant le tempsDeClignotement sp�cifi�
            yield return new WaitForSeconds(tempsDeClignotement);
        }
    }
}
