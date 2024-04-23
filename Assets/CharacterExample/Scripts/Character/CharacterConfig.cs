using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private AirborneStateConfig _airborneStateConfig;
    [SerializeField] private SlowWalkingStateConfig _slowWalkingStateConfig;
    [SerializeField] private FastRunningStateConfig _fastRunningStateConfig;

    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    public SlowWalkingStateConfig SlowWalkingStateConfig => _slowWalkingStateConfig;
    public FastRunningStateConfig FastRunningStateConfig => _fastRunningStateConfig;
}
