using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject cannonBallPrefab;
    [SerializeField] private int poolSize = 16; // 8 top havuzu
    private Queue<GameObject> cannonBallPool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ball = Instantiate(cannonBallPrefab);
            // ball.transform.SetParent();
            ball.SetActive(false);
            cannonBallPool.Enqueue(ball);
        }
    }

    public GameObject GetCannonBall(Vector3 position)
    {
        GameObject ball;
        if (cannonBallPool.Count > 0)
        {
            ball = cannonBallPool.Dequeue();
        }
        else
        {
            Debug.LogWarning("Havuzdaki toplar tükendi, yeni top oluşturuluyor!");
            ball = Instantiate(cannonBallPrefab);
        }
        
        ball.transform.position = position;
        ball.SetActive(true);
        return ball;
    }

    public void ReturnCannonBall(GameObject ball)
    {
        ball.SetActive(false);
        cannonBallPool.Enqueue(ball);
    }
}