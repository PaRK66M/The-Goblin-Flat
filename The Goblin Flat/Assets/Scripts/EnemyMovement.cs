using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] movementPositions;
    private int positionNumber = 0;
    private int listSize;

    public float speed = 10;
    private float timeValue = 0;
    private float timeIncrement;

    // Start is called before the first frame update
    void Start()
    {
        listSize = movementPositions.Length;
        NextPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == movementPositions[positionNumber].position)
        {
            NextPosition();
        }

        timeValue += timeIncrement * Time.deltaTime;

        Debug.Log(timeValue);

        transform.position = new Vector3(Mathf.Lerp(movementPositions[positionNumber - 1].position.x, movementPositions[positionNumber].position.x, timeValue),
                                         Mathf.Lerp(movementPositions[positionNumber - 1].position.y, movementPositions[positionNumber].position.y, timeValue),
                                         0);
    }

    private void NextPosition()
    {
        positionNumber++;
        if(positionNumber == listSize)
        {
            positionNumber = 1;
        }

        timeValue = 0;
        float distanceX = Mathf.Abs(movementPositions[positionNumber - 1].transform.position.x - movementPositions[positionNumber].transform.position.x);
        float distanceY = Mathf.Abs(movementPositions[positionNumber - 1].transform.position.y - movementPositions[positionNumber].transform.position.y);
        float totalDistance = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY);


        timeIncrement = speed / totalDistance;

    }
}
