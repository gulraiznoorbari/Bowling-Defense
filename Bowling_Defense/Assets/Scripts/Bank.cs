using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_cashText;
    [SerializeField] int m_startingCash;
    [SerializeField] int m_currentCash;
    [SerializeField] string m_string;
    public int CurrentCash() => m_currentCash;
    void Start()
    {
        m_currentCash = m_startingCash;
    }
    void Update()
    {
        m_cashText.text = m_string + m_currentCash.ToString();
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
