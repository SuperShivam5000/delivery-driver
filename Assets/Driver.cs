using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300;
    [SerializeField] float moveSpeed = 20;
    [SerializeField] float slowSpeed = 20;
    [SerializeField] float boostSpeed = 30;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Speed Up" && moveSpeed!=boostSpeed){
            moveSpeed = boostSpeed;
            Destroy(other.gameObject,0.5f);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
}

