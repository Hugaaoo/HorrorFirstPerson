using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class ZoneInteraction : MonoBehaviour
{
    [System.Serializable]
    public class LightSwitch
    {
        public Collider switchCollider; // Collider de l'interrupteur
        public List<Light> associatedLights; // Liste des lumières associées à cet interrupteur
        public bool lightsOn = false; // État des lumières associées à cet interrupteur
    }

    public TMP_Text interactionText; // Le TextMeshPro pour afficher le message d'interaction
    public KeyCode interactionKey = KeyCode.E; // Touche pour interagir
    public List<LightSwitch> lightSwitches = new List<LightSwitch>(); // Liste des interrupteurs

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.gameObject.SetActive(true);
            interactionText.text = "Press E to toggle the lights";
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
        if (Input.GetKeyDown(interactionKey))
        {
            ToggleLights();
        }
    }

    // Fonction pour basculer l'état des lumières associées à l'interrupteur
    private void ToggleLights()
    {
        foreach (LightSwitch lightSwitch in lightSwitches)
        {
            if (lightSwitch.switchCollider.bounds.Contains(transform.position))
            {
                lightSwitch.lightsOn = !lightSwitch.lightsOn;

                // Appliquer l'état des lumières pour cet interrupteur
                foreach (Light lightComponent in lightSwitch.associatedLights)
                {
                    lightComponent.enabled = lightSwitch.lightsOn;
                }
            }
        }
    }
}
