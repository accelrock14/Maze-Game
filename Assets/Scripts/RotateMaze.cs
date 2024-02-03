using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateMaze : MonoBehaviour
{
    public Button rotateCWButton;
    public Button rotateCCWButton;

    public float rotationSpeed = 90f;
    public Vector3 axis = Vector3.up;

    private ButtonPressed rotateCW;
    private ButtonPressed rotateCCW;

    void Start()
    {
        rotateCW = rotateCWButton.GetComponent < ButtonPressed>();
        rotateCCW = rotateCCWButton.GetComponent < ButtonPressed>();
    }

    void Update()
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
        transform.Rotate(Vector3.forward * -Time.deltaTime * rotationSpeed);
    }

    private void RotateCCW()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
