using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed;

    private Transform transform;
    private Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //8-Directional WASD player movmenet
        Direction = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            Direction.z += -1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction.z += 1.0f;
        }if (Input.GetKey(KeyCode.A))
        {
            Direction.x += 1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction.x += -1.0f;
        }
        float angle = Vector3.Angle(transform.forward, Direction);
        if (angle > 5) transform.Rotate(0.0f, angle, 0.0f);


        //Bullet Firing using Object Poolings
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = BulletPool.SharedInstance.GetPooledObject();
            Debug.Log(bullet);
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    void FixedUpdate() //50 updates/s
    {
        if (Direction.z != 0 | Direction.x != 0)
        {
            transform.Translate(Direction * moveSpeed, Space.World);
        }
    }
}
