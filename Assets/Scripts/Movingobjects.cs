using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingobjects : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 0, -1);
        transform.Translate(movement * speed * Time.deltaTime); 
    }
}
