using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSense=1f;
    [SerializeField] Transform player, playerArms;

    float xAxisClamp = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    //oyunda olan anlık değişiklikler
    void Update()
    {
        

        float rotateX = Input.GetAxis("Mouse X") * mouseSense;
        float rotateY = Input.GetAxis("Mouse Y") * mouseSense;

        xAxisClamp -= rotateX;

        Vector3 rotPlayerArms = playerArms.rotation.eulerAngles;
        Vector3 rotPlayer = player.rotation.eulerAngles;

        //rotPlayerArms.x -= rotateY;
        //rotPlayerArms.z = 0;
        //rotPlayer.y += rotateX;

        /*rotPlayer.x -= rotateY;
        rotPlayerArms.z = 0;
        rotPlayer.y += rotateX;
        */

        rotPlayer.x -= rotateY;
        rotPlayer.z = 0;
        rotPlayer.y += rotateX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotPlayerArms.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotPlayerArms.x = 270;
        }

        /*playerArms.rotation = Quaternion.Euler(rotPlayerArms);
        player.rotation = Quaternion.Euler(rotPlayer);
        */

        transform.rotation = Quaternion.Euler(rotPlayerArms);
        player.transform.rotation = Quaternion.Euler(rotPlayer);

    }
}
