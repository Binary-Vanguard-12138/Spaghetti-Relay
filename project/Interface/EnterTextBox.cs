using System.Windows.Forms;

namespace Message_Relay_GUI
{
    public class EnterTextBox : TextBox
    {
        protected override bool IsInputKey(Keys key)
        {
            if (key == Keys.Enter)
                return true;

            return base.IsInputKey(key);
        }
    }
}
