using System.Collections.Generic;
using System.Windows.Forms;

namespace CKG
{
    public static class ControlExtensions
    {
        public static void SetControlGroupActive(this IReadOnlyList<Control> controls, bool active)
        {
            foreach (var control in controls)
            {
                control.Enabled = active;
            }
        }
    }
}
