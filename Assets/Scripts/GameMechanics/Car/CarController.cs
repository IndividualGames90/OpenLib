using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float topSpeed = 50f;
    [SerializeField] private float traction = 1f;
    [SerializeField] private Transform carObject;

    private Vector3 moveForce;
    private float drag = .98f;
    private float steerAngle = 20;

    private void Update()
    {
        ForwardAcceleration(Input.GetAxis("Vertical"));
    }

    private void ForwardAcceleration(float verticalInput)
    {
        moveForce += transform.forward * acceleration * verticalInput * Time.deltaTime;
        carObject.position += moveForce * Time.deltaTime;//why double mult with deltatime?

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle * Time.deltaTime);

        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, topSpeed);

#if UNITY_EDITOR
        Debug.DrawRay(transform.position, moveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
#endif

        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
    }
}
