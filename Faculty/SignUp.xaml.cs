using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Faculty
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        finalEntities db = new finalEntities();

        public SignUp()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(passTxt.Text == confirmPassText.Text)
            {
                
                if (db.Students.FirstOrDefault(x => x.email == emailTxt.Text) == null)
                {
                    Student student = new Student();
                    student.passwordd = passTxt.Text;
                    student.email = emailTxt.Text;
                    student.studname = nameTxt.Text;
                    db.Students.Add(student);
                    db.SaveChanges();
                    NavigationService.Navigate(new Login());
                }
                else
                {
                    MessageBox.Show("The Email Have account!");
                }
                
            }
            else
            {
                MessageBox.Show("Password is not Same");
            }
            //    string passwordPattern = ^([a-z])([A-Z])(\\d)([@!#$%^&*-_]){8,20}$";

            /*
            if (passTxt.Text == confirmPassText.Text)
            {
                Student student = new Student
                {
                    Name = nameTxt.Text,
                    Password = passTxt.Text,
                    Email = emailTxt.Text
                };
                db.Students.Add(student);
                db.SaveChanges();
                Login login = new Login();
                NavigationService.Navigate(login);
            }
            else
                MessageBox.Show("Login faild");*/

        }
    }
}
