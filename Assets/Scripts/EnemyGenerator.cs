using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Bird;

    [SerializeField]
    private GameObject Trap;

    public void spawnEnemy()
    {
        if (Random.Range(0, 2) == 1)
        {
            Instantiate(Bird, new Vector3(transform.position.x, 0f, transform.position.z), Quaternion.identity);
        }
        else
        {
            Instantiate(Trap, transform.position, Quaternion.identity);
        }
    }
}
