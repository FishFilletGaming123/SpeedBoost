using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float speedBoost = 2f;
    public float rotationSpeed = 50f;
    public float speedDuration = 10f;
    private float origSpeed;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float rotation =  Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0,0,translation);
        transform.Rotate(0,rotation,0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            StartCoroutine(BoostSpeed());
            Destroy(other.gameObject);
        }
    }

    IEnumerator BoostSpeed()
    {
        Debug.Log("SpeedingUp");
        origSpeed = moveSpeed;
        moveSpeed *= speedBoost;

        yield return new WaitForSeconds(speedDuration);
        Debug.Log("Duration Run Out");
        moveSpeed = origSpeed;
    }

}

