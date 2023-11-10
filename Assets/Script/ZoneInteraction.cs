using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ZoneInteraction : MonoBehaviour
{
    public TMP_Text interactionText; // Le TextMeshPro pour afficher le message d'interaction
    public KeyCode interactionKey = KeyCode.E; // Touche pour interagir
    public bool lightsOn = false; // État des lumières
    public List<Light> interactableLights; // Liste des lumières à activer/désactiver

    private void Start()
    {
        interactionText.gameObject.SetActive(false);

        // Éteindre les lumières au démarrage
        foreach (Light lightComponent in interactableLights)
        {
            lightComponent.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "Press E to turn on/off the light";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && lightsOn)
        {
            // Éteindre les lumières
            foreach (Light lightComponent in interactableLights)
            {
                lightComponent.enabled = false;
            }
            lightsOn = false;
        }
        else if (Input.GetKeyDown(interactionKey) && !lightsOn)
        {
            // Allumer les lumières
            foreach (Light lightComponent in interactableLights)
            {
                lightComponent.enabled = true;
            }
            lightsOn = true;
        }
    }
}
