using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LevelEditor.Services
{
    public interface IAlerter
    {
        bool? Dialog(Window parent, string title, string message);
    }
}
