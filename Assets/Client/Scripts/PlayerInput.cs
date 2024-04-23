using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputManager _input;
    private Player _player;
    private GameMachine _gameMachine;

    public void Initialize(Player player, InputManager input, GameMachine gameMachine)
    {
        _player = player;
        _input = input;
        _gameMachine = gameMachine;
        SubscribePlayer();
    }

    private void SubscribePlayer()
    { 
        _input.PlayerActions.MousePosition.performed += OnMousePosition;
        _input.PlayerActions.Jump.started += OnJump;
        _input.PlayerActions.Recharge.started += OnRecharge;
        _input.PlayerActions.Move.performed += OnChangeDirection;
        _input.PlayerActions.Move.canceled += OnChangeDirection;
        _input.PlayerActions.FirstWeapon.started += OnChooseFirstWeapon;
        _input.PlayerActions.SecondWeapon.started += OnChooseSecondWeapon;
        _input.PlayerActions.Shoot.started += OnShoot;
        _input.PlayerActions.Dash.started += OnDash;
        _input.PlayerActions.Map.started += OnMap;
        _input.PlayerActions.Pause.started += OnPause;
    }

    public void UnsubscribePlayer()
    { 
        _input.PlayerActions.MousePosition.performed -= OnMousePosition;
        _input.PlayerActions.Jump.started -= OnJump;
        _input.PlayerActions.Recharge.started -= OnRecharge;
        _input.PlayerActions.Move.performed -= OnChangeDirection;
        _input.PlayerActions.Move.canceled -= OnChangeDirection;
        _input.PlayerActions.FirstWeapon.started -= OnChooseFirstWeapon;
        _input.PlayerActions.SecondWeapon.started -= OnChooseSecondWeapon;
        _input.PlayerActions.Shoot.started -= OnShoot;
        _input.PlayerActions.Dash.started -= OnDash;
        _input.PlayerActions.Map.started -= OnMap;
        _input.PlayerActions.Pause.started -= OnPause;
    }

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        _player.CameraMovement.RotateCamera(context.ReadValue<Vector2>());
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _player.Movement.Jump();
    }

    private void OnRecharge(InputAction.CallbackContext context)
    {
        _player.Weapons.ReloadWeapon();
    }

    private void OnChangeDirection(InputAction.CallbackContext context)
    {
        _player.Movement.ChangeDirection(context.ReadValue<Vector2>());
    }

    private void OnChooseFirstWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChooseWeapon(1);
    }

    private void OnChooseSecondWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChooseWeapon(2);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        _player.Weapons.Shoot();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        _player.Movement.Dash();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        _gameMachine.StopGame();
    }

    private void OnMap(InputAction.CallbackContext context)
    {
        _gameMachine.StopGame();
    }
}