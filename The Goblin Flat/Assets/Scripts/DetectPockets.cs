using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPockets : MonoBehaviour
{
    public Vector3 playerPosition;
    public GameObject currentPocket = null;
    public ChangeImage currentPocketScript = null;
    public bool pickingPockets = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 7 && !pickingPockets) //Enemy layer
        {
            if(currentPocket != null)
            {
                float newEnemyDistance;
                float currentEnemyDistance;

                float xDistance = Mathf.Abs(other.gameObject.transform.position.x - playerPosition.x);
                float yDistance = Mathf.Abs(other.gameObject.transform.position.y - playerPosition.y);

                if (xDistance >= yDistance)
                {
                    newEnemyDistance = xDistance;
                }
                else
                {
                    newEnemyDistance = xDistance;
                }

                xDistance = Mathf.Abs(currentPocket.transform.position.x - playerPosition.x);
                yDistance = Mathf.Abs(currentPocket.transform.position.y - playerPosition.y);

                if (xDistance >= yDistance)
                {
                    currentEnemyDistance = xDistance;
                }
                else
                {
                    currentEnemyDistance = xDistance;
                }

                if (newEnemyDistance < currentEnemyDistance)
                {
                    currentPocketScript.ChangeRender(0);
                    currentPocket = other.gameObject;
                    currentPocketScript = currentPocket.GetComponent<ChangeImage>();
                    currentPocketScript.ChangeRender(1);
                }
            }
            else
            {
                currentPocket = other.gameObject;
                currentPocketScript = currentPocket.GetComponent<ChangeImage>();
                currentPocketScript.ChangeRender(1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 && !pickingPockets && collision.gameObject == currentPocket)
        {
            currentPocketScript.ChangeRender(0);
            currentPocket = null;
            currentPocketScript = null;
        }
    }
}
