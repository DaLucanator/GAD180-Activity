using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoWalker : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;
    [SerializeField] private GameObject _cloudParticlePrefab2;
    public bool explosion = false;

    public Vector2 eggPosition = new Vector2(0, 0);
    void Update()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), eggPosition, 3 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject newParticle = (GameObject)Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(newParticle,3);
            CaveManEggSave_Controller.dinosKilled++;
        }

        if(collision.gameObject.tag == "Egg")
        {
            Destroy(gameObject);
            GameObject newParticle = (GameObject)Instantiate(_cloudParticlePrefab2, transform.position, Quaternion.identity);
            Destroy(newParticle, 3);
            CaveManEggSave_Controller.eggHealth -= 10;
        }
    }
}
