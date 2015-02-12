using System.Windows.Forms;
using SerializationExample.Entities;
using SerializationExample.Serializator;
using SerializationExample.Services;

namespace SerializationExample.Forms
{
    public partial class MainForm : Form
    {
        private Person _person;
        private const string FileName = "person.dat";
        private ISerializator<Person> _serializator;

        public MainForm()
        {
            InitializeComponent();

            ChangeSerializatorType(null, null);
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            _person = new Person
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                Birthday = birthdayDateTimePicker.Value
            };

            _serializator.Serialize(_person, FileName);
        }

        private void loadButton_Click(object sender, System.EventArgs e)
        {
            _person = _serializator.Deserialize(FileName);

            firstNameTextBox.Text = _person.FirstName;
            lastNameTextBox.Text = _person.LastName;
            birthdayDateTimePicker.Value = _person.Birthday;
        }

        private void ChangeSerializatorType(object sender, System.EventArgs e)
        {
            if (toXmlRadio.Checked)
                _serializator = new XmlSerializator();
            else if (toBinaryRadio.Checked)
                _serializator = new BinarySerializator();
        }
    }
}
