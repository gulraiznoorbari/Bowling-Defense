using System.Collections;
using System.Collections.Generic;
using Autodesk.Fbx;
using UnityEngine;
using UnityEngine.UIElements;

public class Pins : MonoBehaviour
{
    private Vector3 StartPoisiton;
    UIManager uIManager;
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        StartPoisiton = transform.localPosition;
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Pin"))
        {
            if (transform.position != StartPoisiton)
            {
                uIManager.pins.Remove(this.gameObject.GetComponent<Pins>());
                Destroy(gameObject, 3f);
            }
        }
    }
}
