using System.Collections;
using System.Collections.Generic;
using AssetKits.ParticleImage;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] ParticleImage CoinsEffect;
    [SerializeField] float time;
    [SerializeField] float CurrentTime;
    [SerializeField] int coins;
    [SerializeField] bool play;
    [SerializeField] UIController uIController;

    Bank bank;
    private void Start()
    {
        play = true;
        bank = FindObjectOfType<Bank>();
        uIController = FindObjectOfType<UIController>();
        CurrentTime = 0;
        CoinsEffect.Stop();
    }
    private void Update()
    {
        ParticleImage(play);
        bool win = uIController.Win();
        bool lose = uIController.lose();
        if(win)
        {
            play = false;
        }
        if(lose)
        {
            play = false;
        }
    }

    private void ParticleImage(bool Active)
    {
        if (Active == true)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= time)
            {
                CoinsEffect.Play();
            }
            if (CurrentTime >= time + 0.5f)
            {
                CoinsEffect.Stop(false);
                CurrentTime = 0;
            }
            if (CoinsEffect.isPlaying)
            {
                int Cash = 0;
                Cash += coins;
                bank.CashDeposite(Cash);
            }
        }
    }
}
