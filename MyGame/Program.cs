using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    //Павел Егоров
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Form form = new Form();
                form.Width = 1000;
                form.Height = 800;
                Game.Init(form);
                form.Show();
                Game.Draw();
                Application.Run(form);
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                MessageBox.Show($"Error: {outOfRange.Message}");
            }
        }
    }
}
