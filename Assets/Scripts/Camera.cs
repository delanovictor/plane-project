using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform playerTransform;
    public float cameraHeight;
    public float cameraDistance;
    public float lookAheadDistance;
    public float bias;

    void Start() {
    }

    private void LateUpdate() {
        Vector3 moveCameraTo = playerTransform.position - transform.forward * cameraDistance + Vector3.up * cameraHeight;

        transform.position = (transform.position * bias) + 
                             (moveCameraTo * (1.0f - bias));

        transform.LookAt(playerTransform.position + playerTransform.forward * lookAheadDistance);
    }
}
