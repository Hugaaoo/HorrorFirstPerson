using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ZoneInteraction : MonoBehaviour
{
    public TMP_Text interactionText; // Le TextMeshPro pour afficher le message d'interaction
    public KeyCode interactionKey = KeyCode.E; // Touche pour interagir
    public bool lightsOn = false; // �tat des lumi�res
    public List<Light> interactableLights; // Liste des lumi�res � activer/d�sactiver

    private void Start()
    {
        interactionText.gameObject.SetActive(false);

        // �teindre les lumi�res au d�marrage
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
            // �teindre les lumi�res
            foreach (Light lightComponent in interactableLights)
            {
                lightComponent.enabled = false;
            }
            lightsOn = false;
        }
        else if (Input.GetKeyDown(interactionKey) && !lightsOn)
        {
            // Allumer les lumi�res
            foreach (Light lightComponent in interactableLights)
            {
                lightComponent.enabled = true;
            }
            lightsOn = true;
        }
    }
}
