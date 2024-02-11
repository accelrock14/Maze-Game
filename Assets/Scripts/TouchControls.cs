using UnityEngine;

public class TouchControls : MonoBehaviour
{
    //[SerializeField] private float rotationSpeed = 90f;
    //private Vector3 previousAngle = Vector3.zero;

    private Camera mainCamera;
    private Vector3 screenPos;
    private float angleOffset;
    private Collider2D col;


    private void Start()
    {
        mainCamera = Camera.main;
        col = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                screenPos = mainCamera.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);

                //transform.eulerAngles = Vector3.SmoothDamp(transform.eulerAngles, new Vector3(0, 0, angle + angleOffset), ref previousAngle, rotationSpeed * Time.deltaTime);

                //float adjustedAngle = Mathf.Clamp(angle + angleOffset, -180f, 180f);
                //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + adjustedAngle * rotationSpeed * Time.deltaTime);
            }
        }
    }
}
