using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
       if(Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 400);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
