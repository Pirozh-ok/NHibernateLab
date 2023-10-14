using NHibernate;
using NHibernateLab.NHibernate;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace NHibernateLab {
    public partial class Form1 : Form {
        private int count;

        public Form1() {
            InitializeComponent();

            using (var session = NHibernateHelper.OpenSession()) {
                using (var tx = session.BeginTransaction()) {
                    count = (int)session.CreateQuery("select count(*) from Marks").UniqueResult();
                    tx.Commit();
                }
            }
        }
    }
}
