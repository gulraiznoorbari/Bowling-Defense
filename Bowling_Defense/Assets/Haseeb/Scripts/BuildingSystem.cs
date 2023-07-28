using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] bool m_gridOn;
    [SerializeField] float m_gridSize;
    [SerializeField] Toggle m_gridToggle;
    [SerializeField] LayerMask m_layerMask;
    [SerializeField] GameObject[] m_object;
    [SerializeField] Vector3 m_mousePosition;
    [SerializeField] GameObject m_pendingObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_pendingObject != null)
        {
            if (m_gridOn)
            {
                m_pendingObject.transform.position = new Vector3(RoundToNearestGrid(m_mousePosition.x), RoundToNearestGrid(m_mousePosition.y), RoundToNearestGrid(m_mousePosition.z));
            }
            else
            {
                m_pendingObject.transform.position = m_mousePosition;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Pendingobject();
            }
        }
    }

    void Pendingobject()
    {
        m_pendingObject = null;
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_layerMask))
        {
            m_mousePosition = hit.point;
        }
    }

    public void placement(int index)
    {
        m_pendingObject = Instantiate(m_object[index], m_mousePosition, transform.rotation);
    }

    public void GridToggle()
    {
        if(m_gridToggle.isOn)
        {
            m_gridOn = true;
        }
        else
        {
            m_gridOn = false;
        }
    }
    
    float RoundToNearestGrid(float pos)
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
