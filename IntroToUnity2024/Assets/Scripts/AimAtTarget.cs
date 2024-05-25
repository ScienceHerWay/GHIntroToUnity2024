using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTarget : MonoBehaviour
{

    public GameObject target = null;
    public float aimingSpeed = 1.0f;


    // Update is called once per frame
    void Update()
    {
      // Determine which direction to rotate towards
      Vector3 targetDirection = target.transform.position - transform.position;

      // The step size is equal to speed times frame time.
      float singleStep = aimingSpeed * Time.deltaTime;

      // Rotate the forward vector towards the target direction by one step
      Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

      transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
