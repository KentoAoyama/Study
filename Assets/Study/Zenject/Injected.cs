using UnityEngine;
using Zenject;

/// <summary>
/// Zenjectによって依存性注入をされるクラス
/// </summary>
public class Injected : MonoBehaviour
{
    [Inject]
    private IExample _example;

    private void Start()
    {
        _example.Test();
    }
}
