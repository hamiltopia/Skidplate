using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D carRB;
    public Rigidbody2D frontTire;
    public Rigidbody2D backTire;

    public float speed = 80;
    public float carTorque = 5;
    public float fuelConsumption = 0.1f;

    private float movement;
    public float fuel = 1;

    public UnityEngine.UI.Image image;


    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        image.fillAmount = fuel;
    }

    private void FixedUpdate()
    {

        if (fuel > 0)
        {
            backTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            carRB.AddTorque(-movement * speed * Time.fixedDeltaTime);
        }

        fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;

    }

}
