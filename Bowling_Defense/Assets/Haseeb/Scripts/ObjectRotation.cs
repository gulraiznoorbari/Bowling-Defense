using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] Vector3 Rotation;
    
    private void OnMouseDown()
    {
        transform.Rotate(Rotation);
    }
}
