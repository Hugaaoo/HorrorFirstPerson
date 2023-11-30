using TMPro;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    // R�f�rence au texte que vous souhaitez afficher
    public TextMeshProUGUI texte;

    // La vitesse � laquelle le texte appara�t/dispara�t (modifiable dans l'inspecteur Unity)
    public float vitesseApparition = 1.0f;

    private bool joueurDansZone = false;
    private float opaciteCible = 0.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            joueurDansZone = true;
            opaciteCible = 1.0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            joueurDansZone = false;
            opaciteCible = 0.0f;
        }
    }

    void Update()
    {
        float nouvelleOpacite = Mathf.MoveTowards(texte.color.a, opaciteCible, vitesseApparition * Time.deltaTime);
        texte.color = new Color(texte.color.r, texte.color.g, texte.color.b, nouvelleOpacite);
    }
}
