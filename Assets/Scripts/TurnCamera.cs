using UnityEngine;
using System.Collections;

public class TurnCamera : MonoBehaviour {

    private Transform m_transform;
    private float m_angle = 45.0f;
    private Vector3 m_turnAngle;

	// Use this for initialization
	void Start () {
        m_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        m_turnAngle = m_transform.localEulerAngles;
        m_turnAngle.y = m_angle * Input.GetAxis("Camera");

        m_transform.transform.localEulerAngles = m_turnAngle;
	}
}
