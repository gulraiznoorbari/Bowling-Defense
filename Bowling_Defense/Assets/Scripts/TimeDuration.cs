using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDuration : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float TotalPrice;
    Bank bank;
    
    private void Start()
    {
        image = GetComponent<Image>();
        bank = FindObjectOfType<Bank>();
    }

    private void Update()
    {
        int cash = bank.CurrentCash();
        image.fillAmount = cash / TotalPrice;
    }
}
