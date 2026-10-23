using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        //if (Input.GetKey(KeyCode.UPArrow))
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

        //if (Input.GetKey(KeyCode.RightArrow))
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        //if (Input.GetKey(KeyCode.DownArrow))
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }

        //if (Input.GetKey(KeyCode.DownArrow))
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
    }
}