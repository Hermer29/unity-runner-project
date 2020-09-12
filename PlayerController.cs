using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector3.right * 0.1f);
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * 0.1f);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                transform.Translate(Vector3.up);
            }
        }
    }
}
