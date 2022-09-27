using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryMigotti_Biblioteca
{
    public partial class frmLibros : Form
    {
        //declaración de variables
        public string[,] DatosLibros = new string[20, 5];
        int i = 0;
        char separador = Convert.ToChar(",");

        public frmLibros()
        {
            InitializeComponent();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        //procedimiento para buscar el nombre de la editorial
        //así reemplazo el número por el nombre real
        private void NombreEditorial(int E)
        {
            //primero leo el archivo
            StreamReader Editorial = new StreamReader("./EDITORIAL.txt");
            while(!Editorial.EndOfStream)
            {
                //meto en un vector los datos q se encuentran en el archivo
                //y utilizo nuevamente el separador q declaré en un principio
                string[] vecEditorial = Editorial.ReadLine().Split(separador);
                //si el nombre q recibe el vector es igual al nombre
                //que se utiliza en la matriz entonces el procedimiento
                //lo reemplaza
                if (vecEditorial[0] == DatosLibros[E,2])
                {
                    DatosLibros[E,2] = vecEditorial[1];
                }
            }

        }

        //hago lo mismo para buscar el nombre de la distribuidora
        private void NombreDistribuidora(int D)
        {
            //primero leo el archivo
            StreamReader Distribuidora = new StreamReader("./DISTRIBUIDORA.txt");
            while (!Distribuidora.EndOfStream)
            {
                //meto en un vector los datos q se encuentran en el archivo
                //y utilizo nuevamente el separador q declaré en un principio
                string[] vecDistribuidora = Distribuidora.ReadLine().Split(separador);
                //si el nombre q recibe el vector es igual al nombre
                //que se utiliza en la matriz entonces el procedimiento
                //lo reemplaza
                if (vecDistribuidora[0] == DatosLibros[D, 4])
                {
                    DatosLibros[D, 4] = vecDistribuidora[1];
                }
            }

        }


        private void frmLibros_Load(object sender, EventArgs e)
        {
            int i = 0;

            StreamReader Libros = new StreamReader("./LIBRO.txt");
            while (!Libros.EndOfStream)
            {
                //para separar los datos q se encuentran adentro del vector utilizo
                //el separador q declaré anteriormente
                string[] VecLibros = Libros.ReadLine().Split(separador);
                if (i < 20)
                {
                    //cargo en el vector q cree anteriormente todos los datos
                    //q están en la matriz
                    DatosLibros[i, 0] = VecLibros[0];
                    DatosLibros[i, 1] = VecLibros[1];
                    DatosLibros[i, 2] = VecLibros[2];
                    DatosLibros[i, 3] = VecLibros[3];
                    DatosLibros[i, 4] = VecLibros[4];
                    //utilizo los procedimientos q cree con anterioridad
                    //para q puedan mostrarse correctamente
                    //en la interfaz gráfica
                    //utilizo el mismo índice
                    NombreEditorial(i);
                    NombreDistribuidora(i);
                    i++;

                }
            }
            Libros.Close();

            //muestro los datos q se encuentran en la matriz
            txtCodigoLibro.Text = DatosLibros[0, 0];
            txtNombreLibro.Text = DatosLibros[0, 1];
            txtEditorial.Text = DatosLibros[0, 2];
            txtAutor.Text = DatosLibros[0, 3];
            txtDistribuidor.Text = DatosLibros[0, 4];
            //deshabilito el botón para q no se pueda utilizar
            //ya q no hay existen datos antes del primero jejox
            btnAnterior.Enabled = false;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //incremento el índice
            i++;

            //muestro en las cajas de texto
            //los datos q estaban en el archivo
            txtCodigoLibro.Text = DatosLibros[i, 0];
            txtNombreLibro.Text = DatosLibros[i, 1];
            txtEditorial.Text = DatosLibros[i, 2];
            txtAutor.Text = DatosLibros[i, 3];
            txtDistribuidor.Text = DatosLibros[i, 4];
            btnAnterior.Enabled = true;

            if (i == DatosLibros.GetLength(0) - 1)
            {
                btnSiguiente.Enabled = false;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            //decremento el indice
            i--;
            if (i >= 0)
            {
                //muestro todo al verre
                txtCodigoLibro.Text = DatosLibros[i, 0];
                txtNombreLibro.Text = DatosLibros[i, 1];
                txtEditorial.Text = DatosLibros[i, 2];
                txtAutor.Text = DatosLibros[i, 3];
                txtDistribuidor.Text = DatosLibros[i, 4];

                if (i == 0)
                {
                    btnAnterior.Enabled = false;
                }

            }
            else
            {
                btnAnterior.Enabled = false;
            }
        }
    }
}
