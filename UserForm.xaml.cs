using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

namespace Task
{
    /// <summary>
    /// Lógica de interacción para UserForm.xaml
    /// </summary>
    public partial class UserForm : Page
    {
        public int id = 0;
        public UserForm(int id=0)
        {
            InitializeComponent();
            List<AreasViewModel> areas = new List<AreasViewModel>();
            using (Model.task_masterEntities DB = new Model.task_masterEntities())
            {
                areas = (from d in DB.areas
                         select new AreasViewModel
                         {
                             id_area = d.id_area,
                             nombre = d.nombre,
                         }).ToList();
            }
                txtId_Area.ItemsSource = areas;
            this.id = id;
            if (this.id != 0)
            {
                using (Model.task_masterEntities DB = new Model.task_masterEntities())
                {
                    var user = DB.usuarios.Find(this.id);
                    txtNombre.Text = user.nombre;
                    txtNombre.IsReadOnly = true;
                    txtApellido.Text=user.apellido;
                    txtApellido.IsReadOnly = true;
                    txtCorreo.Text=user.correo;
                    txtFechaNac.DisplayDate = user.fecha_nacimiento.Date;
                    txtFechaNac.SelectedDate = user.fecha_nacimiento.Date;
                    txtGenero.Text = user.genero;
                    txtGenero.IsReadOnly = true;
                    txtEdad.Text = user.edad.ToString();
                    txtEdad.IsReadOnly = true;
                    txtTelefono.Text = user.telefono;
                    txtDireccion.Text = user.direccion;
                    txtId_Area.SelectedIndex = user.id_area-1;
                }
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (id == 0)
            {
                using (Model.task_masterEntities DB = new Model.task_masterEntities())
                {
                    var user = new Model.usuarios();
                    user.nombre = txtNombre.Text;
                    user.apellido = txtApellido.Text;
                    user.correo = txtCorreo.Text;
                    user.fecha_nacimiento = DateTime.Parse(txtFechaNac.Text);
                    user.genero=txtGenero.Text;
                    user.edad=int.Parse(txtEdad.Text);
                    user.telefono=txtTelefono.Text;
                    user.direccion=txtDireccion.Text;
                    user.id_area = txtId_Area.SelectedIndex+1;
                    user.fecha_creacion = DateTime.Now;
                    user.fecha_actualizacion = DateTime.Now;
                    DB.usuarios.Add(user);
                    DB.SaveChanges();
                    MainWindow.StaticMainFrame.Content = new listado();
                }
            }
            else 
            {
                using (Model.task_masterEntities DB = new Model.task_masterEntities())
                {
                    var user = DB.usuarios.Find(id);
                    user.nombre = txtNombre.Text;
                    user.apellido = txtApellido.Text;
                    user.correo = txtCorreo.Text;
                    user.fecha_nacimiento = DateTime.Parse(txtFechaNac.Text);
                    user.genero = txtGenero.Text;
                    user.edad = int.Parse(txtEdad.Text);
                    user.telefono = txtTelefono.Text;
                    user.direccion = txtDireccion.Text;
                    user.id_area = txtId_Area.SelectedIndex+1;
                    user.fecha_creacion = DateTime.Now;
                    user.fecha_actualizacion = DateTime.Now;
                    DB.Entry (user).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                    MainWindow.StaticMainFrame.Content = new listado();
                }
            }
        }
        public class AreasViewModel {
            public int id_area { get; set; }
            public String nombre { get; set; }
        }
    }
}
