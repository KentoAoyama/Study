using UnityEngine;

/// <summary>
/// 依存性注入をするクラス
/// </summary>
public class Example : IExample
{
    public void Test()
    {
        Debug.Log("Test");
    }
}
