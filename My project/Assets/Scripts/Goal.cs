using UnityEngine;

public class Goal : MonoBehaviour
{
    // このゴールの色
    public Cube.PackageColor goalColor;

    // 成功時のイベント（あとで使う）
    public System.Action onCorrect;
}
