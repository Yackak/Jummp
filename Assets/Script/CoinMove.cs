using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coin coinScript;
    public bool enabled;
    // Start is called before the first frame update
    void Start()
    {
        coinScript = gameObject.GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position, coinScript.moveSpeed * Time.deltaTime );
        }
    }
}

