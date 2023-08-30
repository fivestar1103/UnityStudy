using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 0.7f;
    void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f);
    }
}
