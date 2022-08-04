using UnityEngine;

public class MoveV2 : MonoBehaviour
{
    private float horzinotal;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, 20 * Time.deltaTime);

        horzinotal = Input.GetAxis("Horizontal");
        transform.Translate(30 * horzinotal * Time.deltaTime * Vector3.right);

        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }

        if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
    }
}
