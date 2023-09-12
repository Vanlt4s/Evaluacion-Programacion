using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public PlayerController pc;
    public static event System.Action<Vector2> OnMovement;
    public static event System.Action OnJump;
    public static event System.Action onPause;

    [SerializeField] PlayerInput playerinput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        playerinput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerinput.onActionTriggered -= HandleInput;
    }

    private void HandleInput(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch (action)
        {
            case "Move":

                Vector2 input = context.ReadValue<Vector2>();
                OnMovement?.Invoke(input);
                break;

            case "Jump":

                if (context.started) OnJump?.Invoke();
                break;

            case "Pause":

                if (context.started) onPause?.Invoke();
                break;

        }
    }
}
