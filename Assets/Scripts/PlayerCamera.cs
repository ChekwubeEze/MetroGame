using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //[SerializeField] private GameObject playerShip;
    //private float height = 4.0f;
    //private float distance = 5.0f;

    //private float followDamping = 8f;
    //private float rotationDamping = 100.0f;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    transform.position = playerShip.transform.TransformPoint(0f, height, -distance);

    //}

    //// Update is called once per frame
    //void Update()
    //{


    //    transform.position = Vector3.Lerp(transform.position,
    //        playerShip.transform.TransformPoint(0f, height, -distance),
    //        Time.deltaTime * followDamping);
    //    Quaternion rotation =
    //        Quaternion.LookRotation(playerShip.transform.position
    //        - transform.position + Vector3.up * 3);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
    //        Time.deltaTime * rotationDamping);
    //}

    [SerializeField] private GameObject playerShip;
    private float height = 4.0f;
    private float distance = 5.0f;

    private float followDamping = 8f;
    private float rotationDamping = 100.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetCameraPosition();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    // Function to smoothly follow the player
    private void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position,
            playerShip.transform.TransformPoint(0f, height, -distance),
            Time.deltaTime * followDamping);

        Quaternion rotation = Quaternion.LookRotation(playerShip.transform.position
            - transform.position + Vector3.up * 3);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
            Time.deltaTime * rotationDamping);
    }

    // New function to reset camera position instantly
    public void ResetCameraPosition()
    {
        transform.position = playerShip.transform.TransformPoint(0f, height, -distance);
        transform.LookAt(playerShip.transform.position + Vector3.up * 3);
    }

}
