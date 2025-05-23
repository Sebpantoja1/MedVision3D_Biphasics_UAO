using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotionInput : MonoBehaviour, PlayerControls.IPlayerLocomotionMapActions
{
    public PlayerControls PlayerControls {get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector2 MovementInput {get; private set;}

    private void OnEnable()
    {
        PlayerControls = new PlayerControls();
        PlayerControls.Enable();

        PlayerControls.PlayerLocomotionMap.Enable();
        PlayerControls.PlayerLocomotionMap.SetCallbacks(this);
    }

    private void OnDisable()
    {
        PlayerControls.PlayerLocomotionMap.Disable();
        PlayerControls.PlayerLocomotionMap.RemoveCallbacks(this);

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
