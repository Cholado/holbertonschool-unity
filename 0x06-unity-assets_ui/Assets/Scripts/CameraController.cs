using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private Transform t;
    private Vector3 offset;

    public GameObject player;
    public float turnSpeed = 5.0f;
    public Toggle InvertedYMode;
    public bool isInverted = false;
    private int inverted;

    // Start is called before the first frame update
    void Start()
    {
        if (InvertedYMode)
            isInverted = true;
        t = GetComponent<Transform>();
        offset = t.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted)
                    inverted = -1;
        else
                    inverted = 1;
        
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * inverted * turnSpeed, Vector3.left) * offset;
        t.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}