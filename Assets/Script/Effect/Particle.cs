using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private bool isFloating;
    [SerializeField] private float speed;
    [SerializeField] private float lifeSpan;
    private float spawnTime;
    private void OnEnable()
    {
        spawnTime = Time.time;
    }
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (isFloating)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Time.time - spawnTime >= lifeSpan)
        {
            SelfDestruct();
        }
    }
}
