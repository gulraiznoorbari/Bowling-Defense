using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    private Vector3 startPosition;
    public UIManager uIManager;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        startPosition = transform.localPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Pin"))
        {
            if (transform.position != startPosition)
            {
                uIManager.pins.Remove(this.gameObject.GetComponent<Pins>());
                Destroy(gameObject, 3f);
            }
        }
    }
}
