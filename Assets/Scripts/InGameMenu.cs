using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InGameMenu : MonoBehaviour {

    [SerializeField]
    private Text m_time;
    [SerializeField]
    private GameObject m_gameOverMenu;
    [SerializeField]
    private GameObject m_pauseMenu;
    [SerializeField] Text m_stopwatch;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton7)) {
            if (!m_pauseMenu.activeInHierarchy && !m_gameOverMenu.activeInHierarchy) {
                m_pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
            if (m_pauseMenu.activeInHierarchy) {
                m_pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
            if (m_pauseMenu.activeInHierarchy) {
                SceneManager.LoadScene(0);
            }
        }

        if (CheckpointController.currentLap == 2) {
            m_gameOverMenu.SetActive(true);
            m_time.text = m_stopwatch.text;
            m_stopwatch.enabled = false;

            GetComponent<CarController>().enabled = false;

            if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
                SceneManager.LoadScene(0);
            }
        }
	}
}
