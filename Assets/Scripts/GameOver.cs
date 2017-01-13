using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    [SerializeField]
    private Text m_time;
    [SerializeField]
    private GameObject m_gameOverMenu;
    [SerializeField] Text m_stopwatch;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
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
