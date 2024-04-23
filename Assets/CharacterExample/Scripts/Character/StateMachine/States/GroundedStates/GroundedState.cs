using UnityEngine.InputSystem;

public class GroundedState : MovementState
{
    private readonly GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _groundChecker = character.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        View.StartGrounded();   
    }

    public override void Exit()
    {
        base.Exit();

        View.StopGrounded();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
            return;

        StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Jump.started += OnJumpKeyPressed;
        Input.Movement.FastRun.started += HoldShift;
        Input.Movement.FastRun.canceled += ReleaseShift;
        Input.Movement.SlowWalk.started += HoldCtrl;
        Input.Movement.SlowWalk.canceled += ReleaseCtrl;
    }

    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();

        Input.Movement.Jump.started -= OnJumpKeyPressed;
        Input.Movement.FastRun.started -= HoldShift;
        Input.Movement.FastRun.canceled -= ReleaseShift;
        Input.Movement.SlowWalk.started -= HoldCtrl;
        Input.Movement.SlowWalk.canceled -= ReleaseCtrl;

    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();

    private void HoldShift(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<FastRunningState>();

    private void ReleaseShift(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();

    private void HoldCtrl(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<SlowWalkingState>();

    private void ReleaseCtrl(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();

}
