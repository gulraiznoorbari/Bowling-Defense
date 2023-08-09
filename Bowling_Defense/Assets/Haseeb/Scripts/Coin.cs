using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform Target;
    // Start is called before the first frame update
    private void Update()
    {
        CoinMovement();
    }

    private void CoinMovement()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, speed * Time.deltaTime);
    }
}
