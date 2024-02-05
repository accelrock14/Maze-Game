using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateMaze : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public Vector3 axis = Vector3.up;

    [SerializeField]private ButtonPressed rotateCW;
    [SerializeField]private ButtonPressed rotateCCW;

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
        transform.Rotate(axis * -Time.deltaTime * rotationSpeed);
    }

    private void RotateCCW()
    {
        transform.Rotate(axis * Time.deltaTime * rotationSpeed);
    }
}
