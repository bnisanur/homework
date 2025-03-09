using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Hareket yönünü belirle (sadece yatay eksende)
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Hareketi uygula
        controller.Move(move * speed * Time.deltaTime);

        // Karakterin hep aynı yükseklikte kalmasını sağla
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }
}