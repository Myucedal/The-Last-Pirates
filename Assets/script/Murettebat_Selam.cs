using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Murettebat_Selam : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            Movepirates.murettebatYanýnda = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Movepirates.murettebatYanýnda = false;
        }
    }
}
