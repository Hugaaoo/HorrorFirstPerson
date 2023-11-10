using UnityEngine;
using UnityEngine.UI;

public class MouseToggle : MonoBehaviour
{
    public Button[] buttons;
    public GameObject playerObject;  // Sélectionnez manuellement l'objet contenant le script FirstPersonController

    private bool areButtonsActive = false;

    void Start()
    {
        SetButtonsActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            areButtonsActive = !areButtonsActive;
            SetButtonsActive(areButtonsActive);

            ToggleMouseAndPauseGame(areButtonsActive);
        }
    }

    void SetButtonsActive(bool active)
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(active);
        }
    }

    void ToggleMouseAndPauseGame(bool active)
    {
        if (active)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

            if (playerObject != null)
            {
                var firstPersonController = playerObject.GetComponentInChildren<FirstPersonController>();
                if (firstPersonController != null)
                {
                    firstPersonController.enabled = false;
                }
                else
                {
                    Debug.LogError("FirstPersonController not found on the playerObject or its children!");
                }
            }
            else
            {
                Debug.LogError("playerObject is NULL!");
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;

            if (playerObject != null)
            {
                var firstPersonController = playerObject.GetComponentInChildren<FirstPersonController>();
                if (firstPersonController != null)
                {
                    firstPersonController.enabled = true;
                }
                else
                {
                    Debug.LogError("FirstPersonController not found on the playerObject or its children!");
                }
            }
            else
            {
                Debug.LogError("playerObject is NULL!");
            }
        }
    }
}
