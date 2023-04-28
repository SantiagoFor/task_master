using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para listado.xaml
    /// </summary>
    public partial class listado : Page
    {
        public listado()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
             List<UsuariosViewModel> list = new List<UsuariosViewModel> ();
            using (Model.task_masterEntities DB = new Model.task_masterEntities())
            { 
                list= (from d in DB.usuarios
                       from  a in DB.areas
                       where a.id_area == d.id_area
                    select new UsuariosViewModel
                    {
                        id = d.id,
                        nombre = d.nombre,
                        apellido = d.apellido,
                        correo = d.correo,
                        fecha_nacimiento = d.fecha_nacimiento,
                        genero = d.genero,
                        edad = d.edad,
                        telefono = d.telefono,
                        direccion = d.direccion,
                        id_area = a.nombre,
                        fecha_creacion = d.fecha_creacion,
                        fecha_actualizacion = d.fecha_actualizacion

                    }).ToList();
            }
                Users.ItemsSource = list.OrderByDescending(d => d.id).Take(10);
        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            UserForm form=new UserForm(Id);
            MainWindow.StaticMainFrame.Content = form;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new UserForm();
        }
    }
    public class UsuariosViewModel
    {

        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String correo { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public String genero{ get; set; }
        public int? edad{ get; set; }
        public String telefono{ get; set; }
        public String direccion{ get; set; }
        public String id_area { get; set; }
        public DateTime  fecha_creacion { get; set; }
        public DateTime  fecha_actualizacion { get; set; }
    }
   
    }
