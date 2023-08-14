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
    private bool IsButtonDown; // After
    // private float EffectDuration; // After
    // [SerializeField] float Reset; // After
    // [SerializeField] float EffectTime; // After
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
    // [SerializeField] bool IsPendingTrue;
    // [SerializeField] bool IsYes;
    private Vector3 CursorOffset = new Vector3(0, 0.1f, 0);
    Bank bank;
    // Update is called once per frame
    private void Start()
    {
        bank = FindObjectOfType<Bank>();
        //EffectDuration = 0f;
        CursorEffect.SetActive(false);
        // foreach (GameObject effect in m_effect)
        // {
        //     effect.SetActive(false);
        // }
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
            //IsYes = true;
        }

        // if (!IsPlaying && IsPendingTrue) // After
        // {
        //     //IsPendingTrue = false;
        //     // EffectTime -= Time.deltaTime;
        //     // if (EffectTime <= EffectDuration)
        //     // {
        //     //     foreach (GameObject effect in m_effect)
        //     //     {
        //     //         effect.SetActive(false);
        //     //         IsPendingTrue = false;
        //     //     }
        //     // }
        // }
    }

    public void YesPlace()
    {
        if (m_pendingObject != null)
        {
            m_pendingObject.SetActive(true); //After
            StartCoroutine(cameraShake.Shake(CameraShakeDuration, CameraShakeMagnitude));
            CursorEffect.SetActive(false);
            Pendingobject();
        }
        // if (IsYes)
        // {
        //     m_pendingObject.SetActive(true); //After
        //     CursorEffect.SetActive(false);
        //     //IsPendingTrue = true;
        //     //Invoke("Pendingobject", EffectTime); //After
        //     Pendingobject();
        //     IsYes = false;
        //     // if (Input.GetMouseButtonDown(0))
        //     // {
        //     //     m_pendingObject.SetActive(true); //After
        //     //     IsPendingTrue = true;
        //     //     //Invoke("Pendingobject", EffectTime); //After
        //     //     Pendingobject();
        //     //     IsYes = false;
        //     // }

        // }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_layerMask))
        {
            m_mousePosition = hit.point;
        }
    }
    public void PointerDown(int index) // After
    {
        IsButtonDown = true;
        if (IsButtonDown)
        {
            int Cash = bank.CurrentCash();

            if (Cash >= m_effectPrices[index])
            {
                //EffectTime = Reset;
                int Cost = m_effectPrices[index];
                bank.CaseWithdrawl(Cost);
                m_pendingObject = Instantiate(m_effect[index]);
                m_pendingObject.SetActive(false);
                m_reserveObject = m_pendingObject;
                //m_pendingObject = m_effect[index];
                //m_effect[index].SetActive(false);
                CursorEffect.SetActive(true);

                //Effect[item].SetActive(true);
            }
        }
    }
    public void PointerUp(int index) // After
    {
        IsButtonDown = false;

    }

    private void Pendingobject()
    {
        m_pendingObject = null;
        Destroy(m_reserveObject, 3.8f);
    }

    // public void placement(int index)
    // {
    //     m_pendingObject = m_object[index]; // After
    //     //var range = Random.Range(0, m_object.Length);
    //     //m_pendingObject = Instantiate(m_object[index], m_object[index].transform.position, m_object[index].transform.rotation);
    // }

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
