using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour: MonoBehaviour
{
    public int projectileVelocity = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //FixedUpdate is called 50 times/s
    void FixedUpdate()
    {
        this.transform.Translate(transform.forward * projectileVelocity, Space.World);
    }

    private void OnTriggerEnter(Collider c)
    {
        gameObject.SetActive(false);
    }
       
}
