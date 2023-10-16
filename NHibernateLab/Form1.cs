using NHibernate;
using NHibernateLab.NHibernate;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace NHibernateLab {
    public partial class Form1 : Form {
        private int count;

        public Form1() {
            InitializeComponent();

            NHibernateHelper.CreateDatabase();

            MessageBox.Show("Tables created successful");
        }
    }
}
