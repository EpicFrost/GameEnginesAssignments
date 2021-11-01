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
        //Debug.Log("Player Position: (" + position.x + "," + position.y + "," + position.z + ")");

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

       
        


    }

    void FixedUpdate() //50 updates/s
    {
        if (Direction.z != 0 | Direction.x != 0)
        {
            float angle = Vector3.Angle(transform.forward, Direction) + 180;
            transform.Translate(Direction * moveSpeed, Space.World);
            if (angle > 0) transform.Rotate(0.0f, angle, 0.0f);
        }
    }
}
