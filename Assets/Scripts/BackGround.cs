using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime;
        if (transform.position.x < -15f)
        {
            transform.position = new Vector3(15.3f, transform.position.y, transform.position.z);
        }
    }
}
