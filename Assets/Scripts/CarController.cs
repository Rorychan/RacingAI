using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float Speed;
    public float Rotation;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotation = transform.eulerAngles.z;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(currentRotation, currentRotation + Rotation, Time.deltaTime));
        _rigidbody2D.velocity = transform.up * Speed * Time.deltaTime*100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
