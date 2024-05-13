using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  //This is how to make drag and drop boxes for Instantiating assets.
  public GameObject bulletPrefab;
  public float bulletSpeed = 1f;
  public bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Shoot()
    {
      if(Input.GetKeyDown(KeyCode.F))
      {
        GameObject bulletClone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //This gets the "Rigidbody" component of the Instantiated bullet and not the prefab's.
        bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
      }
    }

    // Update is called once per frame
    void Update()
    {
      Shoot();

    }
}
