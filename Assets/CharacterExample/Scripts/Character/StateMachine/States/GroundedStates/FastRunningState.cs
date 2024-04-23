public class FastRunningState : GroundedState
{
    private readonly FastRunningStateConfig _config;
    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    => _config = character.Config.FastRunningStateConfig;

    //Меня почему то тревожит этот повтор кода. Я сначала думал, может создать общего предка, но конфиги у всех разные, тогда надо и конфиги под одну гребенку переделывать
    //и вот не понятно, правильно ли это.
    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }
}
