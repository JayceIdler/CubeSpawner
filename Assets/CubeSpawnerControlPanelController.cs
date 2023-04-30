using UnityEngine;

public class CubeSpawnerControlPanelController : MonoBehaviour
{
    [SerializeField] private CubeSpawnerController SpawnerController;
    [SerializeField] private DecimalInputController SpawnIntervalInput;
    [SerializeField] private DecimalInputController CubeSpeedlInput;
    [SerializeField] private DecimalInputController TargetDistanceInput;

    private void OnEnable()
    {
        SpawnIntervalInput.ValueChange += SpawnerController.SetSpawnInterval;
        CubeSpeedlInput.ValueChange += SpawnerController.SetCubeSpeed;
        TargetDistanceInput.ValueChange += SpawnerController.SetCubeTargetDistance;
    }

    private void OnDisable()
    {
        SpawnIntervalInput.ValueChange -= SpawnerController.SetSpawnInterval;
        CubeSpeedlInput.ValueChange -= SpawnerController.SetCubeSpeed;
        TargetDistanceInput.ValueChange -= SpawnerController.SetCubeTargetDistance;
    }
}
