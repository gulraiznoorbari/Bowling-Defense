using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EffectSelection : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    Vector3 StartingPosition;
    [SerializeField] Vector3 SelectionPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartingPosition = rectTransform.position;
    }

    private void OnMouseDown()
    {
        var pos = rectTransform.position;
        pos.y = SelectionPosition.y;
    }

    private void OnMouseUp()
    {
        rectTransform.position = StartingPosition;
    }
}
