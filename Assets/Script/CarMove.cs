using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float carSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = new Vector3(0, 0, 1);
        transform.position += moveVec * carSpeed * Time.deltaTime;
    }
}
