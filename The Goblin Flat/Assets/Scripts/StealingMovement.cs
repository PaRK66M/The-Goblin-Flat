using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealingMovement : MonoBehaviour
{
    public Transform maxHeight;
    public Transform minHeight;

    public float baseFallSpeed = 5;
    public float fallSpeedAcceleration = 1.2f;
    public float baseRiseSpeed = 5;
    public float riseSpeedAcceleration = 1.2f;

    private float fallSpeed = 5;
    private float riseSpeed = 5;

    public bool move = false;
    public bool consistent = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Frame");
        if (move)
        {
            Debug.Log("Move");
            fallSpeed = baseFallSpeed;

            if (consistent)
            {
                riseSpeed += riseSpeed * riseSpeedAcceleration * Time.deltaTime;
            }
            else
            {
                consistent = true;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y + riseSpeed, transform.position.z);

            if (transform.position.y > maxHeight.position.y)
            {
                transform.position = new Vector3(transform.position.x, maxHeight.position.y, transform.position.z);
            }

            

        }
        else
        {
            riseSpeed = baseRiseSpeed;

            if (!consistent)
            {
                fallSpeed += fallSpeed * fallSpeedAcceleration * Time.deltaTime;
            }
            else
            {
                consistent = false;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);

            if (transform.position.y < minHeight.position.y)
            {
                transform.position = new Vector3(transform.position.x, minHeight.position.y, transform.position.z);
            }
        }
    }

    public void SetMove(bool condition)
    {
        move = condition;
    }
}
