using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void DisableAfterTime()
    {
        StartCoroutine(DisableStartMenu());
    }

    private IEnumerator DisableStartMenu()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
