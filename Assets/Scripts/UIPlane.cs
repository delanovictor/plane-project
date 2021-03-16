using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPlane : MonoBehaviour
{
   public float speed;
   public float height;

   public Text speedText;
   public Text heightText;
    
//    public GameObject plane;
   public PlaneController planeScript;

   private void Start() {
        // planeScript = plane.GetComponent<PlaneController>();
   }
   
   private void Update() {
        speed = planeScript.planeSpeed;
        height = planeScript.GetHeight();

       speedText.text = "Speed: " + speed.ToString("F2") + "km/h";
       heightText.text = "Height: " + height.ToString("F2") + "m";
   }
}
