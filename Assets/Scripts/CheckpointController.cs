using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

    public Transform[] checkpointArray;
    public static Transform[] checkpointA;
    public static int currentCheckpoint = 0;
    public static int currentLap = 0;
    public int Lap;

    private Vector3 startPos;

    void Start() {
        startPos = GetComponent<Transform>().position;
        currentCheckpoint = 0;
        currentLap = 0;
    }

    void Update() {
        Lap = currentLap;
        checkpointA = checkpointArray;
    }
}
