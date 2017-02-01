using UnityEngine;
using System.Collections;

public class LockCamera : MonoBehaviour {
    private Camera myCam;
    // Use this for initialization
    void Start () {
        myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        
        myCam.orthographicSize = Mathf.Lerp(myCam.orthographicSize, 10f + Vector3.Magnitude(transform.root.gameObject.GetComponent<Rigidbody2D>().velocity),.01f);
        transform.rotation = Quaternion.identity;
    } //locks camera on player and makes it so that the velocity of the player determines the camera size.
    //om not 100% sure how it works, Chris did it
}
