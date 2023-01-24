using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingManager : MonoBehaviour
{
    
    [SerializeField] private float _height;
    [SerializeField] private float frequency;
    
    private Vector3 _initialPosition, _finalPosition, initialheight;
    private float timer = 0;
    private bool up=true;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position + new Vector3(0, Random.Range(-0.1f,0.1f), 0.0f);
        _finalPosition = transform.position + new Vector3(0, _height, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > frequency)
        {
            timer = 0;
            frequency  =Random.Range(2.0f, 3.0f);
            up = !up;
        }

        
        if (up)
        {
            transform.position = Vector3.Slerp(_initialPosition, _finalPosition,timer/frequency);
        }
        else
        {
            transform.position = Vector3.Slerp(_finalPosition, _initialPosition,timer/frequency);
        }
        timer += Time.deltaTime;
    }
    
    
}
