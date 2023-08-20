using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDuration : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float TotalPrice;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        int cash = bank.CurrentCash();
        image.fillAmount = cash / TotalPrice;
    }
}
