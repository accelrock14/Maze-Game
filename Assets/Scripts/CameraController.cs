using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the object to track
    public GameObject targetObject;

    // Reference to the main camera
    private Camera mainCamera;

    // Minimum and maximum zoom levels (consider adding padding)
    public float minZoom = 0.5f;
    public float maxZoom = 5f;
    public float padding = 0.2f; // Add margin around the object

    // Offset from the center of the screen (optional for fine-tuning)
    public Vector2 offset = Vector2.zero;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    void LateUpdate() // LateUpdate ensures object position is updated after movement
    {
        if (targetObject == null || mainCamera == null)
        {
            Debug.LogWarning("Missing target object or camera in TrackObject script!");
            return;
        }

        // Get object's bounds with padding
        Bounds bounds = targetObject.GetComponent<Renderer>().bounds;
        bounds.Expand(padding * Vector3.one);

        // Calculate required orthographic size to fit the object
        float requiredSize = Mathf.Max(bounds.size.x, bounds.size.y) * 0.5f;

        // Clamp the calculated size within min/max limits
        float newSize = Mathf.Clamp(requiredSize, minZoom, maxZoom);

        // Adjust camera size based on object position
        Vector2 screenCenter = mainCamera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        Vector2 objectCenter = targetObject.transform.position;
        Vector2 offsetPosition = objectCenter + offset; // Add optional offset

        // Calculate new camera position to keep object centered
        Vector2 newCameraPosition = offsetPosition - (screenCenter - objectCenter) * newSize / requiredSize;

        // Clamp camera position within screen bounds (optional)
        // newCameraPosition.x = Mathf.Clamp(newCameraPosition.x, mainCamera.MinViewportX * mainCamera.orthographicSize, mainCamera.MaxViewportX * mainCamera.orthographicSize);
        // newCameraPosition.y = Mathf.Clamp(newCameraPosition.y, mainCamera.MinViewportY * mainCamera.orthographicSize, mainCamera.MaxViewportY * mainCamera.orthographicSize);

        // Set camera position and orthographic size
        mainCamera.transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, mainCamera.transform.position.z);
        mainCamera.orthographicSize = newSize;
    }
}
