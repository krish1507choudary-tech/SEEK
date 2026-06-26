using UnityEngine;

public class MenuFlashlight : MonoBehaviour
{
    public Camera cam;
    public float rotationSpeed = 10f;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.forward, transform.position);

        if (plane.Raycast(ray, out float hit))
        {
            Vector3 target = ray.GetPoint(hit);

            Vector3 dir = transform.position - target;

            Quaternion rot = Quaternion.LookRotation(dir);

            // Change these if needed
            rot *= Quaternion.Euler(90, 180, 0);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rot,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}