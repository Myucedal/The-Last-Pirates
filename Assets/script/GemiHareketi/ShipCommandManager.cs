using script.Dumen_Yonetimi;
using UnityEngine;

namespace script.GemiHareketi
{
    public class ShipCommandManager : MonoBehaviour
    {
        public IShipCommand sailOpenCommand;
        public IShipCommand sailCloseCommand;
        public IShipCommand anchorDropCommand;
        public IShipCommand anchorLiftCommand;

        
        
        private void Start()
        {
            sailOpenCommand = GetComponent<SailOpenCommand>();
            anchorDropCommand = GetComponent<AnchorDropCommand>();
        }
        private void Update()
        {
            if (!PlayerInteraction.Instance.IsInWheel) return;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                sailOpenCommand?.Execute();
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                sailCloseCommand?.Undo();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                anchorDropCommand?.Execute();
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                anchorLiftCommand?.Undo();
            }
        }
    }

    
}