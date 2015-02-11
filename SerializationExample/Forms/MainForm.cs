using System.Windows.Forms;
using SerializationExample.Entities;

namespace SerializationExample.Forms
{
    public partial class MainForm : Form
    {
        private readonly Person _person;

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
