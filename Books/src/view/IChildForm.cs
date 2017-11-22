using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    using Book = BookModel;

    interface IChildForm
    {
        ToolStrip GetToolStrip();
        StatusBar GetStatusBar();
    }
}
