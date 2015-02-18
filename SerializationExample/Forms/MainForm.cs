using System;
using System.Reflection;
using System.Windows.Forms;
using SerializationExample.Entities;
using SerializationExample.Serializator;
using SerializationExample.Services;

namespace SerializationExample.Forms
{
    public partial class MainForm : Form
    {
        private Person _person;
        private Car _car;
        private const string FileName = "person.dat";
        private ISerializator<Car> _serializator;

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
            _car = new Car
            {
                CarName = firstNameTextBox.Text,
                CarCost = Convert.ToInt16(lastNameTextBox.Text)
            };

            //_serializator = new XmlSerializator<Person>();
            
            _serializator = new XmlSerializator<Car>();
            _serializator.Serialize(_car, FileName);
        }

        private void loadButton_Click(object sender, System.EventArgs e)
        {
            //_person = _serializator.Deserialize(FileName);
            _car = _serializator.Deserialize(FileName);

            //firstNameTextBox.Text = _person.FirstName;
            //lastNameTextBox.Text = _person.LastName;
            //birthdayDateTimePicker.Value = _person.Birthday;

            firstNameTextBox.Text = _car.CarName;
            lastNameTextBox.Text = _car.CarCost.ToString();
            
        }

        private void ChangeSerializatorType(object sender, System.EventArgs e)
        {
            if (toXmlRadio.Checked)
                _serializator = new XmlSerializator<Car>();
            else if (toBinaryRadio.Checked)
                _serializator = new BinarySerializator<Car>();
        }
    }
}
