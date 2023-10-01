using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] movementPositions;
    private int positionNumber = 0;
    private int listSize;

    public float speed = 5;
    public float changeDelay = 4;
    private float timeValue = 0;
    private float timeIncrement;

    private float delayTimer;

    public Sprite[] images;
    public Sprite[] otherImages;
    public GameObject spriteRenderer;
    public GameObject otherSpriteRenderer;
    private bool isRotated = false;

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

        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
        }
        else 
        {
            timeValue += timeIncrement * Time.deltaTime;
            transform.position = new Vector3(Mathf.Lerp(movementPositions[positionNumber - 1].position.x, movementPositions[positionNumber].position.x, timeValue),
                                             Mathf.Lerp(movementPositions[positionNumber - 1].position.y, movementPositions[positionNumber].position.y, timeValue),
                                             0);
        }

        
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


        if (isRotated)
        {
            spriteRenderer.transform.Rotate(new Vector3(0, -180, 0));
            otherSpriteRenderer.transform.Rotate(new Vector3(0, -180, 0));
            isRotated = false;
        }

        if (distanceX > 0)
        {
            spriteRenderer.GetComponent<SpriteRenderer>().sprite = images[2];
            spriteRenderer.transform.Rotate(new Vector3(0, 180, 0));
            otherSpriteRenderer.GetComponent<SpriteRenderer>().sprite = otherImages[2];
            otherSpriteRenderer.transform.Rotate(new Vector3(0, 180, 0));
            isRotated = true;
        }
        else if (distanceX < 0)
        {
            spriteRenderer.GetComponent<SpriteRenderer>().sprite = images[2];
            otherSpriteRenderer.GetComponent<SpriteRenderer>().sprite = otherImages[2];
        }
        else if (distanceY > 0)
        {
            spriteRenderer.GetComponent<SpriteRenderer>().sprite = images[1];
            otherSpriteRenderer.GetComponent<SpriteRenderer>().sprite = otherImages[1];
        }
        else
        {
            spriteRenderer.GetComponent<SpriteRenderer>().sprite = images[0];
            otherSpriteRenderer.GetComponent<SpriteRenderer>().sprite = otherImages[0];
        }

        timeIncrement = speed / totalDistance;

        delayTimer = changeDelay;
    }
}
