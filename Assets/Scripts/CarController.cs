using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    [SerializeField] private float m_maxTorque = 30.0f;
    [SerializeField] private float m_brakeTorque = 30.0f;
    [SerializeField] private float m_maxSteerAngle = 30.0f;
    [SerializeField] private float m_topSpeed = 200.0f;

    [SerializeField] private GameObject[] m_wheels = new GameObject[4];

    [SerializeField] private WheelCollider[] m_colliders = new WheelCollider[4];

    private Quaternion[] m_wheelLocalRotations;
    private Rigidbody m_rb;
    private Vector3 m_centreOfMass;
    private Vector3 m_wheel_angle;

    // Use this for initialization
    void Start() {
        m_rb = GetComponent<Rigidbody>();

        m_centreOfMass = m_rb.centerOfMass;
        m_centreOfMass.x = 0f;
        m_centreOfMass.y = -0.8f;
        m_centreOfMass.z = 0f;
        m_rb.centerOfMass = m_centreOfMass;

        m_wheelLocalRotations = new Quaternion[4];

        for (int i = 0; i < 4; i++) {
            m_wheelLocalRotations[i] = m_wheels[i].transform.localRotation;
        }
	}

	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate() {
        Move_Car();
        Steer_Wheels();
    }

    void Move_Car() {
        for (int i=0; i<4; i++) {
            Quaternion quat;
            Vector3 position;
            m_colliders[i].GetWorldPose(out position, out quat);
            m_wheels[i].transform.position = position;
        }

        m_colliders[2].motorTorque = m_maxTorque * Input.GetAxis("Accelerate");
        m_colliders[3].motorTorque = m_maxTorque * Input.GetAxis("Accelerate");

        m_colliders[2].brakeTorque = m_brakeTorque * Input.GetAxis("Brake");
        m_colliders[3].brakeTorque = m_brakeTorque * Input.GetAxis("Brake");

        m_colliders[0].steerAngle = m_maxSteerAngle * Input.GetAxis("Horizontal");
        m_colliders[1].steerAngle = m_maxSteerAngle * Input.GetAxis("Horizontal");
    }

    void Steer_Wheels() {
        m_wheel_angle = m_wheels[0].transform.localEulerAngles;
        m_wheel_angle.y = m_colliders[0].steerAngle;
        m_wheels[0].transform.localEulerAngles = m_wheel_angle;

        m_wheel_angle = m_wheels[1].transform.localEulerAngles;
        m_wheel_angle.y = m_colliders[1].steerAngle;
        m_wheels[1].transform.localEulerAngles = m_wheel_angle;
    }

    private void CapSpeed() {
        float speed = m_rb.velocity.magnitude;
        speed *= 3.6f;
        if (speed > m_topSpeed) {
            m_rb.velocity = (m_topSpeed / 3.6f) * m_rb.velocity.normalized;
        }
    }
}
