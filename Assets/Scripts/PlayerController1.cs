using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float forwardSpeed;
    public float strafeSpeed;
    public float hoverSpeed;

    public float directionForwardSpeed;
    public float directionStrafeSpeed;
    public float directionHoverSpeed;

    public float forwardAcceleration;
    public float strafeAcceleration;
    public float hoverAcceleration;

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
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x)/screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y)/screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput,Input.GetAxis("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        directionForwardSpeed  = Mathf.Lerp(directionForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        directionStrafeSpeed  = Mathf.Lerp(directionStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        directionHoverSpeed  = Mathf.Lerp(directionHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * 1 * forwardSpeed * Time.deltaTime; 
        transform.position += transform.right * directionStrafeSpeed * strafeSpeed * Time.deltaTime; 
        transform.position += transform.up * directionHoverSpeed * hoverSpeed * Time.deltaTime; 

    }
}
