using System.Collections;
using System.Numerics;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float thrustSpeed;
    public float turnSpeed;

    private float thrustInput;
    private float turnInput;
    private Rigidbody shipRigidBody;

    public float hoverPower;
    public float hoverHeight;

    Transform myTransform;
    MeshRenderer myRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shipRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        Debug.LogFormat($"Thrust Input: {thrustInput}" );
        Debug.LogFormat($"Turn Input: {turnInput}");
    }

    //private void FixedUpdate()
    //{
    //    // Turn the ship
    //    //shipRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
    //    shipRigidBody.MovePosition(transform.forward *  thrustSpeed * Time.fixedDeltaTime);

    //    // Move the ship
    //    shipRigidBody.AddRelativeForce(0f, 0f, thrustInput * thrustSpeed);

    //    // Hovering
    //    Ray ray = new Ray(transform.position, -transform.up);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, hoverHeight))
    //    {
    //        float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
    //        UnityEngine.Vector3 appliedHoverForce = UnityEngine.Vector3.up * proportionalHeight * hoverPower;
    //        shipRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
    //    }
    //}

    private void FixedUpdate()
    {
        // Move the ship forward based on input
        shipRigidBody.MovePosition(shipRigidBody.position + transform.forward * thrustInput * thrustSpeed * Time.fixedDeltaTime);

        // Turn the ship
        shipRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f, ForceMode.Acceleration);

        // Hovering Mechanic
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            UnityEngine.Vector3 appliedHoverForce = UnityEngine.Vector3.up * proportionalHeight * hoverPower;
            shipRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }
    }


    // New function to boost speed temporarily
    public void BoostSpeed(float boostMultiplier, float duration)
    {
        StartCoroutine(BoostCoroutine(boostMultiplier, duration));
    }

    private IEnumerator BoostCoroutine(float boostMultiplier, float duration)
    {
        thrustSpeed *= boostMultiplier;
        yield return new WaitForSeconds(duration);
        thrustSpeed /= boostMultiplier;
    }
}
