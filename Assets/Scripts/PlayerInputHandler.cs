using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Inpute Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name References")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string move = "Move";
    [SerializeField] private string missile = "Missile";
    [SerializeField] private string autogun = "Autogun";

    private InputAction moveAction;
    private InputAction missileAction;
    private InputAction autogunAction;

    public Vector2 MoveInput { get; private set; }

    public bool MissileTriggered { get; private set; }

    public bool AutogunTriggered { get; private set; }

    public static PlayerInputHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        missileAction = playerControls.FindActionMap(actionMapName).FindAction(missile);
        autogunAction = playerControls.FindActionMap(actionMapName).FindAction(autogun);
        RegisterInputActions();

    }

    void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        missileAction.performed -= context => MissileTriggered = true;
        missileAction.canceled -= context => MissileTriggered = false;

        autogunAction.performed -= context => AutogunTriggered = true;
        autogunAction.canceled -= context => AutogunTriggered = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        missileAction.Enable();
        autogunAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        missileAction.Disable();
        autogunAction.Disable();
    }

}