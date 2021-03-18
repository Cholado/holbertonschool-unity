using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    
    //character
    public GameObject player;
    //reference
    public GameObject reference;
    //Distance to character
    private Vector3 distanceToCharacter;

    public float turnSpeed = 5.0f;
    public Toggle InvertedYMode;
    public bool isInverted = false;
    private int inverted;

    // Start is called before the first frame update
    void Start()
    {
        if (InvertedYMode)
            isInverted = true;
        //the position actually of the cam less the position of the character 
        distanceToCharacter = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted)
                    inverted = -1;
        else
                    inverted = 1;
        //Rotation of main camera with mouse in axe X and Y
        distanceToCharacter = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) *  distanceToCharacter;
        //change camera position with regard to character position more the distance to character
        transform.position = player.transform.position + distanceToCharacter;
        //always center  with regard to character
        transform.LookAt(player.transform.position);

        //reference = rotation camera and controllers not change
        Vector3 copyRotation = new Vector3(0, transform.eulerAngles.y, 0);
        reference.transform.eulerAngles = copyRotation;
    }
}