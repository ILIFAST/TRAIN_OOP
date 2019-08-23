using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms
{
    /// <summary>
    /// Форма принятия решения
    /// </summary>
    public partial class ChoiseForm : Form
    {
        /// <summary>
        /// Ссылка на выполняемый метод
        /// </summary>
        public delegate void MethodContainer();

        /// <summary>
        /// Событие при нажатии кнопки Yes
        /// </summary>
        public event MethodContainer yesEvent;

        /// <summary>
        /// Событие при нажатии кнопки No
        /// </summary>
        public event MethodContainer noEvent;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public ChoiseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public ChoiseForm(string message, string buttonText1, string buttonText2)
        {

            InitializeComponent();
            label1.Text = message;
            button1.Text = buttonText1;
            button2.Text = buttonText2;
        }
        /// <summary>
        /// Метод, выполняемый при нажатии кнопки Yes
        /// </summary>
        internal void Yes(object sender, EventArgs e)
        {
            this.Close();
            yesEvent();
        }
        /// <summary>
        /// Метод, выполняемый при нажатии кнопки No
        /// </summary>
        private void No(object sender, EventArgs e)
        {
            this.Close();
            noEvent();
        }
        /// <summary>
        /// Метод, выполняемый при нажатии кнопки Cancel
        /// </summary>
        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
