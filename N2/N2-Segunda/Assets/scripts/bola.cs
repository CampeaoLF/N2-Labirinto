using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class bola : MonoBehaviour
{
 public float speed = 10.0f;    
 public float deadZone = 0.012f;    
 public float sleepVel = 0.2f;  
 public Vector3 rotFixeuLer = new Vector3(90, 0, 0);
 public bool autoCalibrationStart = true;

    Rigidbody rb;
    Quaternion calib = Quaternion.identity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 0.3f;
        rb.angularDamping = 0.2f;
        Input.gyro.enabled = true;

        if (autoCalibrationStart)
        {
            calib = GetWorldAttitude();
        }

        ZeroMotion();
    }

    Quaternion GetWorldAttitude()
    {
        var q = Input.gyro.attitude;
        var Q = new Quaternion(q.x, q.y, -q.z, -q.w);
        return Quaternion.Euler(rotFixeuLer) * Q;
    }

    void ZeroMotion()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Quaternion worldRotation = GetWorldAttitude();
        Quaternion rel = Quaternion.Inverse(calib) * worldRotation;

        Vector3 fwd = rel * Vector3.forward;    
        Vector3 dir = new Vector3(fwd.x, 0f, fwd.z);

        if (dir.magnitude < deadZone)
        {
            if (rb.linearVelocity.magnitude < sleepVel && rb.angularVelocity.magnitude < sleepVel)
            {
               rb.Sleep();
            }
            return;
        }
        rb.WakeUp();
        rb.AddForce(dir.normalized * dir.magnitude * speed, ForceMode.Acceleration);
    }
}

