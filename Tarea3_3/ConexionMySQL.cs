﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace Tarea3_3
{
 
        public  class ConexionMySQL
        {
            public  string GetConnectionString()
            {
    
             
                String servidor = "localhost";
                String puerto = "3306";
                String usuario = "root";
                String password = "root";
                String database = "Tarea3_3";
                //Cadena de conexion

                return String.Format("server={0};port={1};user id={2}; password={3}; database={4}", servidor, puerto, usuario, password, database);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sqlCom"></param>
            public  void EjecutaSQLComando(MySqlCommand sqlCom)
            {
                MySqlConnection sqlConn = new MySqlConnection();
                //MySqlCommand sqlCom = new MySqlCommand();
                try
                {
                    sqlConn.ConnectionString = GetConnectionString();
                    sqlConn.Open();
                    sqlCom.Connection = sqlConn;
                    //sqlCom.CommandText = sComandoSql;
                    sqlCom.ExecuteNonQuery();
                }catch (Exception e){

                }
                finally
                {
                    sqlConn.Close();
                }
            }

            public DataSet LLenaComboGrid(string mysql)
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlConnection cnn = new MySqlConnection();
                MySqlCommand cmd = new MySqlCommand();
                try
                {
                    cnn.ConnectionString = GetConnectionString();
                    cnn.Open();
                    cmd.CommandText = mysql;
                    da.SelectCommand = cmd;
                    da.SelectCommand.Connection = cnn;
                    da.Fill(ds);
                }
                finally
                {

                    cnn.Close();
                }
                return ds;
            }

            public DataSet LLenaComboGrid(MySqlCommand cmd)
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                MySqlConnection cnn = new MySqlConnection();
                try
                {
                    cnn.ConnectionString = GetConnectionString();
                    cnn.Open();
                    //cmd.CommandText = mysql;
                    da.SelectCommand = cmd;
                    da.SelectCommand.Connection = cnn;
                    da.Fill(ds);
                }
                finally
                {

                    cnn.Close();
                }
                return ds;
            }
        }
}