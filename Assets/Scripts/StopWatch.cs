using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StopWatch : MonoBehaviour {

    public Text timerText;
    private float m_secondsCount;
    private int m_minCount;
    private int m_hrCount;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (CheckpointController.currentLap != 2) {
            UpdateTimerUI();
        }
	}

    private void UpdateTimerUI() {
        m_secondsCount += Time.deltaTime;
        timerText.text = m_hrCount + " : " + m_minCount + " : " + m_secondsCount;
        if (m_secondsCount >= 60) {
            m_minCount++;
            m_secondsCount = 0;
        }
        if (m_minCount >= 60) {
            m_hrCount++;
            m_minCount = 0;
        }
    }
}
