using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class JetSkiManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _height;
    [SerializeField] private float frequency;
    [SerializeField] private CharacterController cc;
    [SerializeField] private TMP_Text speedText;

    private Vector3 _initialPosition, _finalPosition, initialheight;
    private float timer = 0;
    private bool up=true;
    private AudioSource _audioSource;
    


    // Start is called before the first frame update
    void Start()
    {
        initialheight = transform.position;
        _initialPosition = _target.position;
        _finalPosition = _target.position + new Vector3(0, _height, 4.0f);
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > frequency)
        {
            timer = 0;
            up = !up;
        }

        
        if (up)
        {
            _target.position = Vector3.Slerp(_initialPosition, _finalPosition,timer/frequency);
        }
        else
        {
            _target.position = Vector3.Slerp(_finalPosition, _initialPosition,timer/frequency);
        }
        timer += Time.deltaTime;
        transform.LookAt(_target);
        transform.position = new Vector3(transform.position.x, initialheight.y, transform.position.z);
        //transform.rotation *= cc.transform.rotation;
        
        
        if(cc.velocity.magnitude > 0.1f )
        {
            _audioSource.pitch = cc.velocity.magnitude/5 + 1.0f;
            if( !_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }

        speedText.text = "Speed : " + cc.velocity.magnitude.ToString() + " kn/h";


    }
}
