using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementVector = Vector2.zero;

    public Rigidbody2D rb;
    private CustomInput input = null;

    public Vector2 facing = Vector2.left;

    public DetectPocketsRaycast scriptDP;
    public StealingMovement scriptSM;
    public CompletionBarTracking scriptCBT;
    public MoneyMovement scriptMM;

    private bool pickingPocket = false;
    public GameObject pocketUi;

    public Slider stealingSlider;

    public int money = 0;

    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new CustomInput();
        EnableInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickingPocket)
        {
            if (stealingSlider.value <= 0 || !scriptDP.pockets)
            {
                Lose();
            }
            else if (stealingSlider.value >= 1)
            {
                Steal();
            }
        }
        
    }

    void FixedUpdate() 
    {
        if(movementVector != Vector2.zero)
        {
            rb.MovePosition(rb.position + movementVector * speed * Time.fixedDeltaTime);
            if (movementVector != facing)
            {
                ChangeFacing(movementVector);
            }
        }
    }

    private void EnableInput()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
        input.Player.PickingPockets.performed += OnPocketPick;
        input.Player.PickingPockets.canceled += OnPocketPickCancel;
    }

    private void DisableInput()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
        input.Player.PickingPockets.performed -= OnPocketPick;
        input.Player.PickingPockets.canceled -= OnPocketPickCancel;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value) 
    {
        movementVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        movementVector = Vector2.zero;
    }

    private void OnPocketPick(InputAction.CallbackContext value)
    {
        Debug.Log("1");
        if (scriptDP.pockets)
        {
            Debug.Log("2");
            if (pickingPocket)
            {
                scriptSM.SetMove(true);
            }
            else
            {
                
                scriptDP.currentPocket.layer = 8;
                scriptDP.pickingPockets = true;
                scriptCBT.ResetBar();
                pocketUi.SetActive(true);
                pickingPocket = true;
            }
        }
        
    }

    private void OnPocketPickCancel(InputAction.CallbackContext value)
    {
        if (scriptDP.pockets)
        {
            if (pickingPocket)
            {
                scriptSM.SetMove(false);
            }
        }

    }

    private void Lose()
    {
        pocketUi.SetActive(false);
        DisableInput();
        loseScreen.SetActive(true);
    }

    private void Steal()
    {
        pocketUi.SetActive(false);
        pickingPocket = false;
        money += scriptDP.currentPocket.GetComponent<EnemyValues>().gold;
        scriptDP.currentPocket.GetComponent<EnemyValues>().Steal();
        scriptMM.speed -= scriptMM.speedDecrease;
        if(scriptMM.speed < scriptMM.speedMin)
        {
            scriptMM.speed = scriptMM.speedMin;
        }
    }

    private void ChangeFacing(Vector2 newFacing)
    {
        facing = newFacing;
        scriptDP.facing = newFacing;

    }
}
