using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class ImageController : MonoBehaviour
{
    public Canvas canvas; //상호작용할 컴포넌트가 있는 캔버스
    public GameObject panel; // 기존에 보여줄 패널
    public GameObject panel_activate; // 버튼 클릭 시 활성화할 패널
    public GameObject leftHandController;
    public GameObject rightHandController;
    public Button activateCanvasButton; // 상호작용할 버튼

    void Start()
    {
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

        AddRayInteractor(leftHandController);
        AddRayInteractor(rightHandController);

        SetupEventSystem();
        // Setup button click listener
        if (activateCanvasButton != null)
        {
            activateCanvasButton.onClick.AddListener(OnActivateCanvasButtonClicked);
            Debug.Log("activateCanvasButton listener added.");
        }
        else
        {
            Debug.LogError("activateCanvasButton is not assigned.");
        }
        // Initially disable the canvas
        if (panel_activate != null)
        {
            panel_activate.gameObject.SetActive(false);
        }
    }

    void AddRayInteractor(GameObject controller)
    {
        if (controller != null)
        {
            if (controller.GetComponent<XRRayInteractor>() == null)
            {
                controller.AddComponent<XRRayInteractor>();
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

    public void OnActivateCanvasButtonClicked()
    {
        Debug.Log("Activate Canvas button clicked.");
        // Activate the canvas
        if (panel_activate != null)
        {
            panel.gameObject.SetActive(false);
            panel_activate.gameObject.SetActive(true);
        }
    }
}
