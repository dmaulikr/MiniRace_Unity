using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    static Transform playerTransform;

	// Use this for initialization
	void Start () {
         playerTransform = GameObject.FindWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (transform == CheckpointController.checkpointA[CheckpointController.currentCheckpoint].transform) {
                Debug.Log("get in");
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
