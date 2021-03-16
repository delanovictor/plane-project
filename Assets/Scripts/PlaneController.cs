using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float planeSpeed;
    public float airResistance;

    public float lookRotateSpeed;
    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;

    public float rollInput;
    public float rollSpeed, rollAcceleration;
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * planeSpeed;
        planeSpeed -= transform.forward.y * Time.deltaTime * airResistance;
       
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x)/screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y)/screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, 
                          mouseDistance.x * lookRotateSpeed * Time.deltaTime, 
                          -mouseDistance.x * lookRotateSpeed/2 * Time.deltaTime, 
                          Space.Self);

        float realign = 15/(transform.rotation.eulerAngles.z - 180);
        transform.Rotate(0,0, realign * lookRotateSpeed * Time.deltaTime, Space.Self);
        // transform.Rotate(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
    }

    public float GetHeight(){
        return transform.position.y;
    }
}
