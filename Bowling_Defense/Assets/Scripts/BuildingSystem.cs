using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    [SerializeField] float CameraShakeDuration;
    [SerializeField] float CameraShakeMagnitude;
    RaycastHit hit;
    private bool IsButtonDown;
    [SerializeField] private bool m_gridOn;
    [SerializeField] private float m_gridSize;
    [SerializeField] private Toggle m_gridToggle;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private GameObject[] m_effect;
    [SerializeField] private int[] m_effectPrices;
    [SerializeField] private GameObject CursorEffect;
    [SerializeField] private Vector3 m_mousePosition;
    [SerializeField] private GameObject m_pendingObject;
    [SerializeField] private GameObject m_reserveObject;
    private Vector3 CursorOffset = new Vector3(0, 0.1f, 0);
    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
        CursorEffect.SetActive(false);
    }
    private void Update()
    {
        if (m_pendingObject != null)
        {
            if (m_gridOn)
            {
                m_pendingObject.transform.position = new Vector3(RoundToNearestGrid(m_mousePosition.x), RoundToNearestGrid(m_mousePosition.y), RoundToNearestGrid(m_mousePosition.z));
                CursorEffect.transform.position = new Vector3(RoundToNearestGrid(m_mousePosition.x), RoundToNearestGrid(m_mousePosition.y + 0.1f), RoundToNearestGrid(m_mousePosition.z));
            }
            else
            {
                m_pendingObject.transform.position = m_mousePosition + new Vector3(0, 0.2f, 0);
                CursorEffect.transform.position = m_mousePosition + CursorOffset;
            }
        }
    }

    public void YesPlace()
    {
        if (m_pendingObject != null)
        {
            m_pendingObject.SetActive(true);
            StartCoroutine(cameraShake.Shake(CameraShakeDuration, CameraShakeMagnitude));
            CursorEffect.SetActive(false);
            Pendingobject();
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_layerMask))
        {
            m_mousePosition = hit.point;
        }
    }
    public void PointerDown(int index)
    {
        IsButtonDown = true;
        if (IsButtonDown)
        {
            int Cash = bank.CurrentCash();

            if (Cash >= m_effectPrices[index])
            {
                int Cost = m_effectPrices[index];
                bank.CaseWithdrawl(Cost);
                m_pendingObject = Instantiate(m_effect[index]);
                m_pendingObject.SetActive(false);
                m_reserveObject = m_pendingObject;
                CursorEffect.SetActive(true);
            }
        }
    }
    public void PointerUp(int index)
    {
        IsButtonDown = false;

    }

    private void Pendingobject()
    {
        m_pendingObject = null;
        Destroy(m_reserveObject, 3.8f);
    }

    public void GridToggle()
    {
        if (m_gridToggle.isOn)
        {
            m_gridOn = true;
        }
        else
        {
            m_gridOn = false;
        }
    }

    private float RoundToNearestGrid(float pos)
    {
        float xDiff = pos % m_gridSize;
        pos -= xDiff;
        if (pos > (m_gridSize / 2))
        {
            pos += m_gridSize;
        }
        return pos;
    }
}
