using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public float followDistance = 1.0f;
    public Transform target;
    public float followSpeed = 0.5f;


    // Update is called once per frame
    void Update()
    {
      Vector3 targetPosition = target.position + new Vector3(0.0f, 0.0f, -followDistance);

      transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
