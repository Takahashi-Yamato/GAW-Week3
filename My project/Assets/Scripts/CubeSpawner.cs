using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject[] cubePrefabs;   // 箱の種類（配列）

    public float rangeX = 30f;
    public float rangeZ = 20f;

    void Start()
    {
        SpawnCube();
    }

    public void SpawnCube()
    {
        // ランダム位置
        Vector3 randomPos = new Vector3(
            Random.Range(-rangeX, rangeX),
            0.5f,
            Random.Range(-rangeZ, rangeZ)
        );

        // ランダム箱
        GameObject prefab = cubePrefabs[Random.Range(0, cubePrefabs.Length)];

        // 生成
        Instantiate(prefab, randomPos, Quaternion.identity);
    }
}