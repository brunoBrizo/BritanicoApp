﻿using BibliotecaBritanico.Utilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBritanico.Modelo
{
    public class Convenio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; } //momento que se lo creo
        public int Anio { get; set; } //año al que hace referencia
        public string AsociadoNombre { get; set; } //nombre de la empresa asociada al convenio
        public string AsociadoTel { get; set; }
        public string AsociadoMail { get; set; }
        public string AsociadoDireccion { get; set; }
        public List<Estudiante> LstEstudiantes { get; set; } = new List<Estudiante>(); //el estudiante tiene el convenio tambien
        public decimal Descuento { get; set; }

        //validar que exista un convenio con la misma empresa por año, no mas de uno
        //hacer metodo y chequearlo en el guardar o hacer un validar

        public Convenio() { }

        public static bool ValidarConvenioInsert(Convenio convenio)
        {
            string errorMsg = String.Empty;
            if (convenio.Nombre.Equals(String.Empty))
            {
                errorMsg = "Debe ingresar el nombre del Convenio \n";
            }
            if (convenio.Anio < 2010)
            {
                errorMsg += "Verifique el año del Convenio \n";
            }
            if (convenio.AsociadoNombre.Equals(String.Empty) || convenio.AsociadoTel.Equals(String.Empty))
            {
                errorMsg += "Debe ingresar Nombre y Telefono del asociado \n";
            }
            if (!convenio.AsociadoMail.Equals(String.Empty) && !Herramientas.ValidarMail(convenio.AsociadoMail))
            {
                errorMsg += "Mail invalido \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }

        public static bool ValidarConvenioModificar(Convenio convenio)
        {
            string errorMsg = String.Empty;
            if (convenio.Nombre.Equals(String.Empty))
            {
                errorMsg = "Debe ingresar el nombre del Convenio \n";
            }
            if (convenio.ID < 1)
                errorMsg += "Debe asignar un ID al convenio \n";
            if (convenio.Anio < 2010)
            {
                errorMsg += "Verifique el año del Convenio \n";
            }
            if (convenio.AsociadoNombre.Equals(String.Empty) || convenio.AsociadoTel.Equals(String.Empty))
            {
                errorMsg += "Debe ingresar Nombre y Telefono del asociado \n";
            }
            if (!convenio.AsociadoMail.Equals(String.Empty) && !Herramientas.ValidarMail(convenio.AsociadoMail))
            {
                errorMsg += "Mail invalido \n";
            }
            if (!errorMsg.Equals(String.Empty))
            {
                throw new ValidacionException(errorMsg);
            }
            return true;
        }
        
        public override string ToString()
        {
            return Nombre;
        }

    }
}
