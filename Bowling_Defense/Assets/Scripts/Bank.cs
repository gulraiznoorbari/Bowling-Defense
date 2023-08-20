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
    // Start is called before the first frame update
    void Start()
    {
        m_currentCash = m_startingCash;
    }

    // Update is called once per frame
    void Update()
    {
        m_cashText.text = m_string + m_currentCash.ToString();
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
