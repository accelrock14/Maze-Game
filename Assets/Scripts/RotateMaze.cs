using UnityEngine;

public class RotateMaze : MonoBehaviour
{
    public float rotationSpeed = 90f;
    private Vector3 axis = Vector3.forward;

    [SerializeField]private ButtonPressed rotateCW;
    [SerializeField]private ButtonPressed rotateCCW;

    void LateUpdate()
    {
        if (rotateCW.buttonPressed)
        {
            RotateCW();
        }
        else if (rotateCCW.buttonPressed)
        {
            RotateCCW();
        }
    }

    private void RotateCW()
    {
        transform.Rotate(rotationSpeed * -Time.deltaTime * axis);
    }

    private void RotateCCW()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * axis);
    }
}
