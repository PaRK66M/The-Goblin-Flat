using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMovement : MonoBehaviour
{
    private Vector2 nextPosition;
    public Vector2 currentPosition;

    public Transform top;
    public Transform bottom;

    private float time;

    public float speed;
    public float speedDecrease;
    public float speedMin;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        nextPosition = currentPosition;
        Debug.Log(top.position.y);
        Debug.Log(bottom.position.y);
        NewPosition();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > speed)
        {
            NewPosition();
        }

        transform.position = new Vector3(Mathf.SmoothStep(currentPosition.x, nextPosition.x, time / speed),
                                         Mathf.SmoothStep(currentPosition.y, nextPosition.y, time / speed),
                                         0);
    }

    private void NewPosition()
    {
        time -= speed;
        currentPosition = nextPosition;
        nextPosition = new Vector2(top.position.x, Random.Range(bottom.position.y, top.position.y));
    }
}
