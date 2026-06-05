using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public Cube.PackageColor goalColor;

    public CubeSpawner spawner;

    public int scorePoint = 10; // 加算点数

    void OnTriggerEnter(Collider other)
    {
        Cube cube = other.GetComponent<Cube>();

        if (cube != null)
        {
            if (cube.color == goalColor)
            {
                Debug.Log("成功！");

                // スコア加算
                ScoreManager.Instance.AddScore(scorePoint);

                Destroy(cube.gameObject);

                spawner.SpawnCube();
            }
            else
            {
                Debug.Log("失敗！");
            }
        }
    }
}