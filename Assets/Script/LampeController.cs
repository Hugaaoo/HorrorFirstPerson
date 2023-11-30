using UnityEngine;

public class LampeTorcheController : MonoBehaviour
{
    // Référence à l'objet lampe torche
    public GameObject lampeTorche;

    // Touche pour activer/désactiver la lampe torche (modifiable dans l'inspecteur Unity)
    public KeyCode toucheActivation = KeyCode.E;

    void Update()
    {
        // Vérifiez si le joueur appuie sur la touche spécifiée pour activer/désactiver la lampe torche
        if (Input.GetKeyDown(toucheActivation))
        {
            // Inversez l'état de la lampe torche (allumée/éteinte)
            lampeTorche.SetActive(!lampeTorche.activeSelf);
        }
    }
}
