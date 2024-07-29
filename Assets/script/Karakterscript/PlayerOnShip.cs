using UnityEngine;

public class PlayerOnShip : MonoBehaviour
{
    public Transform player; // Oyuncunun transformu
    public Transform ship;   // Geminin transformu

    private void OnCollisionEnter(Collision collision) // floor hitboxýna girince player gemiyle birleþir
    {
        if (collision.transform == player)
        {
            player.SetParent(ship);
        }
    }
    private void OnCollisionExit(Collision collision)// floor hitboxýndan çýkýnca player gemiden ayrýlýr
{
        if (collision.transform == player)
        {
            player.SetParent(null);
        }
    }
}
