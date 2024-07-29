using UnityEngine;

public class PlayerOnShip : MonoBehaviour
{
    public Transform player; // Oyuncunun transformu
    public Transform ship;   // Geminin transformu

    private void OnCollisionEnter(Collision collision) // floor hitbox�na girince player gemiyle birle�ir
    {
        if (collision.transform == player)
        {
            player.SetParent(ship);
        }
    }
    private void OnCollisionExit(Collision collision)// floor hitbox�ndan ��k�nca player gemiden ayr�l�r
{
        if (collision.transform == player)
        {
            player.SetParent(null);
        }
    }
}
