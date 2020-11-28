using UnityEngine;
using System.Collections;
using System.IO;

public class SplineWalker : MonoBehaviour {

	public BezierSpline spline;

	public float duration;

	public bool lookForward;

	public SplineWalkerMode mode;
    public int passengersCounter = 0;
    private byte[] map;

    private float progress;
	private bool goingForward = true;
    // private bool isCoroutineExecuting = false;

    public Camera trainCamera;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Passengers: " + passengersCounter);

        //if (Input.GetKeyDown(KeyCode.M))
        //{
            Texture2D tex = null;

            map = File.ReadAllBytes("map.png");
            tex = new Texture2D(2, 2);
            tex.LoadImage(map); //..this will auto-resize the texture dimensions.

            GUI.DrawTexture(new Rect(10, 30, 100, 20), tex);
        //}
}

    private void Update () {
        trainCamera.enabled = true;
        if (goingForward) {
			progress += (Time.deltaTime / duration);
			if (progress > 1f) {
				if (mode == SplineWalkerMode.Once) {
					progress = 1f;
				}
				else if (mode == SplineWalkerMode.Loop) {
					progress -= 1f;
				}
				else {
					progress = 2f - progress;
                    // Invoke("SetGoingForward(false)", 10);
                    // goingForward = false;
                    StartCoroutine(ExecuteAfterTime(10, false));
                }
            }
		}
		else {
			progress -= Time.deltaTime / duration;
			if (progress < 0f) {
				progress = - progress;
                // Invoke("SetGoingForward(true)", 10);
				// goingForward = true;
                StartCoroutine(ExecuteAfterTime(10, true));
            }
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		if (lookForward) {
			transform.LookAt(position + spline.GetDirection(progress));
		}
    }

    void SetGoingForward(bool gf)
    {
        goingForward = gf;
    }

    IEnumerator ExecuteAfterTime(float time, bool gf)
    {
        // if (isCoroutineExecuting)
        //     yield break;

        // isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);
        // Code to execute after the delay
        goingForward = gf;

        // isCoroutineExecuting = false;  
    }
}