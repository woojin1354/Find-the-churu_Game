using UnityEngine;

public class Road : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime;
        if (transform.position.x < -18f)
        {
            transform.position = new Vector3(18f, transform.position.y, transform.position.z);
        }
    }
}
