using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _cloudParticlePrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        CaveManSling_Player player = collision.collider.GetComponent<CaveManSling_Player>();
        if (player != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }


        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        //hit on head less than y 0.5 on his head, kill it


        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }



    }

}