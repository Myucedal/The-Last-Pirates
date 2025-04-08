using UnityEngine;

namespace script.GemiHareketi
{
    public class AnchorDropCommand : MonoBehaviour, IShipCommand
    {
        public void Execute()
        {
            Debug.Log("Çapa denize atıldı.");
        }

        public void Undo()
        {
        }
    }
}