using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerColliders : MonoBehaviour
{
    [SerializeField] private bool upper;
    [SerializeField] private PlayerMovement m_playerScript;
    //8 is the ground layer (didnt work with layermask?)

   //private void OnCollisionEnter(Collision collision)
   //{
   //    if (collision.gameObject.layer == 8)
   //    {
   //        if (upper)
   //        {
   //            m_playerScript.UpperColliding = true;
   //        }
   //        else
   //        {
   //            m_playerScript.LowerColliding = true;
   //        }
   //    }
   //}
   //
   //private void OnCollisionExit(Collision collision)
   //{
   //    if (collision.gameObject.layer == 8)
   //    {
   //        if (upper)
   //        {
   //            m_playerScript.UpperColliding = false;
   //        }
   //        else
   //        {
   //            m_playerScript.LowerColliding = false;
   //        }
   //    }
   //}
}
