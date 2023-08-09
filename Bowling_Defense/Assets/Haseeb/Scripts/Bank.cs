using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int m_startingCash;
    [SerializeField] int m_currentCash;
    public int CurrentCash() => m_currentCash;
    // Start is called before the first frame update
    void Start()
    {
        m_currentCash = m_startingCash;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Current Cash {m_currentCash}");
    }
    public void CashDeposite(int Amount)
    {
        m_currentCash += Amount;
    }
    public void CaseWithdrawl(int Amount)
    {
        m_currentCash -= Amount;
    }

}
