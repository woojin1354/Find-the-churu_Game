using System.Collections;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject coinObject;

    [HideInInspector]
    public float coinPositionY;

    void Start()
    {
        StartCoinGenerator();
    }

    void StartCoinGenerator()
    {
        StartCoroutine("CoinRoutine");
    }

    // 코인, 몹 생성 중단
    public void stopCoinGen()
    {
        StopCoroutine("CoinRoutine");
    }

    IEnumerator CoinRoutine() // 코인 생성 + 몹 생성 모두 호출
    {
        float interval = GameManager.instance.gameSpeed / 2;
        float nextCoinSpawn = Time.time + GameManager.instance.gameSpeed / 4;
        float nextSpawnTime = Time.time;
        yield return new WaitForSeconds(nextCoinSpawn);
        EnemyGenerator enemyGen = FindAnyObjectByType<EnemyGenerator>();
        while (true)
        {
            yield return new WaitForSeconds(interval);
            CoinGen();
            if (Time.time - nextSpawnTime > interval * 5)
            {
                enemyGen.spawnEnemy();
                nextSpawnTime = Time.time;
            }
        }
    }

    void CoinGen()
    {
        coinPositionY += Random.Range(-1, 2);
        if (coinPositionY < -3)
        {
            coinPositionY = -3;
        }
        else if (coinPositionY > 0)
        {
            coinPositionY = 0;
        }
        Vector3 pos = new Vector3(transform.position.x, coinPositionY, transform.position.z);
        Instantiate(coinObject, pos, Quaternion.identity);
    }
}
