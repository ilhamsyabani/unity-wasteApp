using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] public GameObject target;
    // [SerializeField]public float distance;
    // [SerializeField]public float followSpeed;

    void Update()
    {
        if (target != null)
        {
            // Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            // transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            // Calculate the desired camera position, clamped within specified bounds
            Vector3 targetPosition = new Vector3(
                Mathf.Clamp(target.transform.position.x, -34f, 34f),
                Mathf.Clamp(target.transform.position.y, -11f, 13f),
                transform.position.z
            );

            // Update the camera's position to the clamped target position
            transform.position = targetPosition;

        }
    }
}
