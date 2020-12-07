using System.Windows.Forms;

namespace ThickInspector
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
