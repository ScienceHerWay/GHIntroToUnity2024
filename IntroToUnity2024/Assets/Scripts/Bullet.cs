using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
      {
        Destroy(gameObject);
      }

    }

    private void OnTriggerEnter(Collider other)
    {
      Destroy(gameObject);
    }
}
