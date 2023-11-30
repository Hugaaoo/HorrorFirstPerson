using UnityEngine;

public class LampeTorcheController : MonoBehaviour
{
    // R�f�rence � l'objet lampe torche
    public GameObject lampeTorche;

    // Touche pour activer/d�sactiver la lampe torche (modifiable dans l'inspecteur Unity)
    public KeyCode toucheActivation = KeyCode.E;

    void Update()
    {
        // V�rifiez si le joueur appuie sur la touche sp�cifi�e pour activer/d�sactiver la lampe torche
        if (Input.GetKeyDown(toucheActivation))
        {
            // Inversez l'�tat de la lampe torche (allum�e/�teinte)
            lampeTorche.SetActive(!lampeTorche.activeSelf);
        }
    }
}
