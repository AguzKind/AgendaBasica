using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CargarGrilla()
        {
            dgv_leer.Rows.Clear();
            StreamReader L = new StreamReader("C:\\Agenda.txt");
            int linea = 0; //Declaro contador para lineas o filas de la grilla
            for (; ; )
            {
                
                string s = L.ReadLine(); //Es una variable de tipo string cargo lo que leo del archivo (la fila)
                if (s == null) break; //Si es fin de archivo termino el bucle
                string[] array = s.Split(';'); //Declaro y cargo un array con el contenido de la fila leida separando datos por ;
                dgv_leer.Rows.Add(); //Agrego una fila en blanco a la grilla
                dgv_leer[0, linea].Value = array[0];
                dgv_leer[1, linea].Value = array[1];
                dgv_leer[2, linea].Value = array[2];
                dgv_leer[3, linea].Value = array[3];
                dgv_leer[4, linea].Value = array[4];
                dgv_leer[5, linea].Value = array[5];
                dgv_leer[6, linea].Value = array[6];
                dgv_leer[7, linea].Value = array[7];
                linea = linea + 1; //Aumento en 1 la cantidad de filas del contador
            }
            dgv_leer.ClearSelection();
            L.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if ((txt_dni.Text != "") && (txt_apellido.Text != "") && (txt_nombre.Text != "") && (txt_localidad.Text != "") && (txt_telefono.Text != "") && (txt_direccion.Text != ""))
            {
            try
            {
                string sexo = "";
                if (rbn_masc.Checked == true)
                {
                    sexo = "Masculino";
                }
                else if (rbn_fem.Checked == true) sexo = "Femenino";
                else if (rbn_otro.Checked == true) sexo = "Otro";

                string fileName = "C:\\Agenda.txt";
                FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(txt_dni.Text + ";" + sexo + ";" + txt_nombre.Text + ";" + txt_apellido.Text + ";" + txt_direccion.Text + ";" + txt_localidad.Text + ";" + cmb_tipocel.Text + ";" + txt_telefono.Text + ";");
                writer.Close();
                MessageBox.Show("La persona fue agregada correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_dni.Text = "";
                txt_nombre.Text = "";
                txt_apellido.Text = "";
                txt_direccion.Text = "";
                txt_localidad.Text = "";
                txt_telefono.Text = "";
                rbn_masc.Checked = true;
                cmb_tipocel.SelectedIndex = 0;
                txt_dni.Focus();
                CargarGrilla();
            }
            catch
            {
                MessageBox.Show("Error en la carga de los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            } else MessageBox.Show("Por favor, cargue todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void txt_telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Programa realizado por Agustin Macoggi", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            rbn_masc.Checked = true;
            cmb_tipocel.Items.Add("Fijo");
            cmb_tipocel.Items.Add("Celular");
            cmb_tipocel.SelectedIndex = 0;
            CargarGrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea salir?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                dialogResult = DialogResult.No;
            }
        }
    }
}
