using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private int BPM;
    [SerializeField] private int speed;
    private float timer;
    private float spawningdelay;
    [SerializeField] private List<GameObject> objectsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        spawningdelay = (float)60 / BPM;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > spawningdelay)
        {
            int r = Random.Range(0, objectsToSpawn.Count);
            int x = Random.Range(-1, 2);
            int z = Random.Range(-1, 2);
            var g=Instantiate(objectsToSpawn[r],transform.position + new Vector3(x,0,z/2),transform.rotation);
            g.GetComponent<Movingobjects>().speed = speed;
            Destroy(g,2);
            timer = 0 ;
        }
        timer += Time.deltaTime;
        Debug.Log(timer + "  : " + spawningdelay);
    }
}
