﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace IPS_Mejora_tu_Salud.Modelo
{
    class  IPS
    {
        Conexion conexion = new Conexion();

        //Funciones para paciente-----------------------------------------------------------------------
        public  int RegistrarPaciente(Paciente paciente)
        {
            int verificacion;
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "INSERT INTO Paciente (IdentificacionPaciente, Nombres, Apellidos," +
                           "FechaNacimiento, Direccion, Telefono, Email, FechaRegistro, Multas)" +
                           "VALUES ('" + paciente.IdentificacionPaciente + "', '" + paciente.Nombres + "'," +
                           "'" + paciente.Apellidos + "', '"+ paciente.FechaNacimiento + "', " +
                           "'" + paciente.Direccion + "', '" + paciente.Telefono + "', '" + paciente.Email + "'," +
                           "'" + paciente.FechaRegistro + "', " + paciente.Multas + ")";

            verificacion = QueryVerificacion(sqlConnection, query);
            return verificacion;
        }

        public int ActualizarPaciente(string email, string direccion, string telefono, string identificacionPaciente)
        {
            int verificacion;
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "UPDATE Paciente SET Email = '" + email + "', Direccion = '" + direccion + "', " +
                           "'" + telefono + "' WHERE IdentificacionPaciente = '" +identificacionPaciente+ "'";

            verificacion = QueryVerificacion(sqlConnection, query);
            return verificacion;
        }

        public DataSet VerMultas(string identificacionPaciente)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT Paciente.Multas, Citas.FechaCita FROM Paciente INNER JOIN Citas ON" +
                           "Paciente.IdentificacionPaciente = Citas.IdentificacionPaciente" +
                           "WHERE IdentificacionPaciente = '" + identificacionPaciente + "' ";

            string mensaje = "Cantidad de multas";
            DataSet dataSet = new DataSet();

            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        public DataSet VerCitasPaciente(string identificacionPaciente)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT IdentificacionMedico, IdentificacionPaciente, FechaCita" +
                           "FROM Cita WHERE IdentificacionPaciente = '" +identificacionPaciente+ "' ";

            string mensaje = "Citas del paciente";
            DataSet dataSet = new DataSet();

            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        public DataSet BuscarPaciente(string identificacionPaciente)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT * FROM Paciente WHERE IdentificacionPaciente = '" + identificacionPaciente + "' ";

            string mensaje = "Paciente encontrado";
            DataSet dataSet = new DataSet();

            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        public DataSet BuscarTodosPacientes()
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT * FROM Paciente";

            string mensaje = "Pacientes registrados en la IPS";
            DataSet dataSet = new DataSet();

            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        //Funciones para médico-----------------------------------------------------------------------

        public int RegistrarMedico(Medico medico)
        {
            int verificacion;
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "INSERT INTO Medico (IdentificacionMedico, Nombres, Apellidos, Especialidad," +
                           "SalarioPorCita, AñosExperiencia)" +
                           "VALUES ('" + medico.IdentificacionMedico + "', '" + medico.Nombres + "'," +
                           "'" + medico.Apellidos + "', '" + medico.Especialidad + "'," +
                           "'" + medico.SalarioPorCita + "', '" + medico.AñosExperiencia + "')";

            verificacion = QueryVerificacion(sqlConnection, query);
            return verificacion;
        }

        public int ActualizarMedico(string nombres, int salarioPorCita, string identificacionMedico)
        {
            int verificacion;
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "UPDATE Medico SET Nombres = '" + nombres + "', SalarioPorCita = '" + salarioPorCita + "', " +
                           " WHERE IdentificacionMedico = '" + identificacionMedico + "'";

            verificacion = QueryVerificacion(sqlConnection, query);
            return verificacion;
        }

        public DataSet VerValorPagar(string identificacionMedico)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT SalarioPorCita" +
                           "FROM Medico WHERE IdentificacionMedico = '" + identificacionMedico + "' ";

            string mensaje = "Salario por cita del medico";
            DataSet dataSet = new DataSet();

            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        public DataSet BuscarMedico(string identificacionMedico)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT * FROM Medico WHERE IdentificacionMedico = '" + identificacionMedico + "'";

            string mensaje = "Medico encontrado";
            DataSet dataSet = new DataSet();

            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        public DataSet BuscarTodosMedicos()
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT * FROM Medico";

            string mensaje = "Pacientes registrados en la IPS";
            DataSet dataSet = new DataSet();

            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        //Funciones de Citas-----------------------------------------------------------------------

        public int RegistarCita(Cita cita)
        {
            int verificacion;
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "INSERT INTO Cita (IdentificacionMedico, IdentificacionPaciente, FechaCita)" +
                           "VALUES ('" + cita.IdentificacionMedico + "', '" + cita.IdentificacionPaciente + "'," +
                           "'" + Convert.ToDateTime(cita.FechaCita) + "')";

            verificacion = QueryVerificacion(sqlConnection, query);
            return verificacion;
        }

        public DataSet verCitasIncumplidas(string identificacionPaciente)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion.conexion);

            string query = "SELECT IdentificacionPaciente, FechaCita, Verificada FROM Cita" +
                            "WHERE IdentificacionPaciente = '" + identificacionPaciente + "' AND Verificada = 'NO'";

            string mensaje = "Citas incumplidas del paciente";
            DataSet dataSet = new DataSet();
            
            dataSet = QueryDataSet(sqlConnection, query, mensaje);
            return dataSet;
        }

        // no poner estático
        public int QueryVerificacion(SqlConnection sqlConnection, string query)
        {
            int verificacion;

            sqlConnection.Open();

            SqlCommand command = new SqlCommand(query, sqlConnection);
            verificacion = command.ExecuteNonQuery();

            sqlConnection.Close();

            return verificacion;
        }

        public DataSet QueryDataSet(SqlConnection sqlConnection, string query, string mensaje)
        {
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, mensaje);

            sqlConnection.Close();
            return dataSet;
        }
    }
}
