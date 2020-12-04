using System.Windows.Forms;

namespace SInspector
{
    class DoubleBufferPanel:Panel
    {
        public DoubleBufferPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint, true);
        }
    }
}
