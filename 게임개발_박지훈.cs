using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{

    private Camera mainCamera;


    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector2(x, y);

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector2(size, size);

        mainCamera = Camera.main; 
    }

    
    void Update()
    {
        Vector2 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // ����ī�޶� ���������� ���� ���氡��
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject); // ������Ʈ �ı� , �������� ����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
