using System.Linq;
using System.Windows;
using System.Windows.Controls;

using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace Faculty
{

    public partial class AdminPage : Page
    {
        finalEntities db = new finalEntities();
        public AdminPage()
        {
            InitializeComponent();
            var studList = db.Students.Include(x => x.Department)
                .Select(s => new { s.ID, s.studname, s.addresss, s.Department.depname })
                .ToList();
            dg.ItemsSource = studList;
        }

        // Search
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dep = db.Departments.FirstOrDefault(x => x.depname == combo.Text);
            if (dep == null || combo.Text == "All")
            {
                var studList = db.Students.Include(d => d.Department)
                                    .Where(x => x.studname.Contains(searchByName.Text))
                                    .Select(s => new { s.ID, s.studname, s.addresss, s.Department.depname }).ToList();
                dg.ItemsSource = studList;

            }
            else
            {
                var studList = db.Students.Include(d => d.Department)
                                    .Where(x => x.studname == searchByName.Text || x.ID == dep.DepID)
                                    .Select(s => new { s.ID, s.studname, s.addresss, s.Department.depname }).ToList();
                dg.ItemsSource = studList;
            }

        }

        // Update
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var dep = db.Departments.FirstOrDefault(x => x.depname == combo.Text);
            if (dep == null)
            {
                var studlist = db.Students.Include(x => x.Department).Where(x => x.studname.Contains(searchByName.Text)).Select(s => new { s.ID, s.studname, s.addresss, s.Department.depname }).ToList();
                dg.ItemsSource = studlist;
            }
            else if (string.IsNullOrEmpty(searchByName.Text))
            {
                var studlist = db.Students.Include(x => x.Department).Where(x => x.DepID == dep.DepID).Select(s => new { s.ID, s.studname, s.addresss, s.Department.depname }).ToList();
                dg.ItemsSource = studlist;
            }
            else
            {
                var studList = db.Students.Include(d => d.Department)
                            .Where(x => x.studname.Contains(searchByName.Text) && x.DepID == dep.DepID)
                            .Select(s => new { s.ID, s.studname, s.addresss, s.Department.depname })
                            .ToList();
                dg.ItemsSource = studList;
            }
        }


    }

    // If condition

}

