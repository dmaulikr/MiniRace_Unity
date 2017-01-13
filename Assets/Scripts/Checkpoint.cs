using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (transform == CheckpointController.checkpointA[CheckpointController.currentCheckpoint].transform) {
                if (CheckpointController.currentCheckpoint + 1 < CheckpointController.checkpointA.Length) {
                    if (CheckpointController.currentCheckpoint == 0) {
                        CheckpointController.currentLap++;
                    }
                    CheckpointController.currentCheckpoint++;
                } else {
                    CheckpointController.currentCheckpoint = 0;
                }
            }
        }
    }
}
