using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngine.SceneManagement;

public class ButtonActivate : MonoBehaviour
{

    public GameObject brushCubePrefab;
    public int rows = 50;
    public int columns = 50;
    public float spacing = 0.05f;

    public Canvas canvas;
    public GameObject leftHandController;
    public GameObject rightHandController;
    public Button activateCanvasButton;
    public GameObject image;

    void Start()
    {
        Debug.Log("SetupXRCanvas Start() called.");

        // Ensure the Canvas is in World mode
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.WorldSpace;

            // Add Tracked Device Graphic Raycaster
            if (canvas.GetComponent<TrackedDeviceGraphicRaycaster>() == null)
            {
                canvas.gameObject.AddComponent<TrackedDeviceGraphicRaycaster>();
                Debug.Log("TrackedDeviceGraphicRaycaster added to canvas.");
            }
        }
        else
        {
            Debug.LogError("Canvas is not assigned.");
        }

        // Add XR Ray Interactor to controllers
        AddRayInteractor(leftHandController);
        AddRayInteractor(rightHandController);

        // Setup EventSystem for XR
        SetupEventSystem();

        // Setup button click listener
        if (activateCanvasButton != null)
        {
            activateCanvasButton.onClick.AddListener(GenerateCanvas);
            Debug.Log("activateCanvasButton listener added.");
        }
        else
        {
            Debug.LogError("activateCanvasButton is not assigned.");
        }

    }

    void AddRayInteractor(GameObject controller)
    {
        if (controller != null)
        {
            if (controller.GetComponent<XRRayInteractor>() == null)
            {
                controller.AddComponent<XRRayInteractor>();
                Debug.Log("XRRayInteractor added to " + controller.name);
            }
        }
        else
        {
            Debug.LogError("Controller is not assigned.");
        }
    }

    public void SetupEventSystem()
    {
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            GameObject eventSystemObj = new GameObject("EventSystem");
            eventSystem = eventSystemObj.AddComponent<EventSystem>();
            eventSystemObj.AddComponent<XRUIInputModule>();
            Debug.Log("EventSystem created and XRUIInputModule added.");
        }
        else
        {
            if (eventSystem.GetComponent<XRUIInputModule>() == null)
            {
                eventSystem.gameObject.AddComponent<XRUIInputModule>();
                Debug.Log("XRUIInputModule added to existing EventSystem.");
            }
        }
    }

    public void GenerateCanvas()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(j * spacing, i * spacing, 0);
                Instantiate(brushCubePrefab, position, Quaternion.identity, transform);
                image.gameObject.SetActive(true);
            }
        }
    }
}
