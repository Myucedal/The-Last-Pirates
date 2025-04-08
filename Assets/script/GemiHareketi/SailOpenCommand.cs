using UnityEngine;

namespace script.GemiHareketi
{
    public class SailOpenCommand : MonoBehaviour, IShipCommand
    {
        public void Execute()
        {
            Debug.Log("Yelken açıldı.");
        }

        public void Undo()
        {
            
        }
    }
}