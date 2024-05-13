using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float muzzleVelocity = 1f;
    public bool isPlayer = false;
    public float firingRate = 5f;
    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        bool fireBullet = isPlayer && Input.GetKeyUp(KeyCode.F);

        if (!isPlayer)
        {
          currentTime += Time.deltaTime;
          if (currentTime >= firingRate)
          {
            currentTime = 0f;
            fireBullet = true;
          }
        }


        if (fireBullet)
        {
          Vector3 firePosition = transform.position + transform.forward * 1.5f;
          GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition, Quaternion.identity);

          Rigidbody rb = bullet.GetComponent<Rigidbody>();
          if (rb != null)
          {
            Vector3 bulletForce = transform.forward * muzzleVelocity;
            rb.AddForce(bulletForce, ForceMode.Impulse);
          }
        }
    }
}
