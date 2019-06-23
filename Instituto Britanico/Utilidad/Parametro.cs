using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaBritanico.Utilidad
{
    public class Parametro : Persistencia, IPersistencia<Parametro>
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }

        public Parametro() { }

        public Parametro(string Nombre, string Valor)
        {
            this.Nombre = Nombre;
            this.Valor = Valor;
        }



        #region Persistencia

        public bool Leer(string strCon)
        {
            SqlConnection con = new SqlConnection(strCon);
            bool ok = false;
            List<SqlParameter> lstParametros = this.ObtenerParametros();
            SqlDataReader reader = null;
            string sql = "";
            if (this.ID > 0)
            {
                sql = "SELECT * FROM Parametro WHERE ID = @ID";
            }
            else
            {
                sql = "SELECT * FROM Parametro WHERE Nombre = @Nombre";
            }
            try
            {
                con.Open();
                reader = Persistencia.EjecutarConsulta(con, sql, lstParametros, CommandType.Text);
                while (reader.Read())
                {
                    this.ID = Convert.ToInt32(reader["ID"]);
                    this.Nombre = reader["Nombre"].ToString();
                    this.Valor = reader["Valor"].ToString();
                    ok = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            return ok;
        }

        public bool Guardar(string strCon)
        {
            SqlConnection con = new SqlConnection(strCon);
            bool seGuardo = false;
            try
            {
                if (!this.Leer(strCon))
                {
                    List<SqlParameter> lstParametros = this.ObtenerParametros();
                    string sql = "INSERT INTO Parametro VALUES (@ID, @Nombre, @Valor);";
                    int res = 0;
                    res = Convert.ToInt32(Persistencia.EjecutarScalar(con, sql, CommandType.Text, lstParametros, null));
                    if (res > 0) seGuardo = true;
                }
                else
                {
                    throw new ValidacionException("Ya existe el Parametro: " + this.Nombre, "Parametro");
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return seGuardo;
        }

        public bool Modificar(string strCon)
        {
            SqlConnection con = new SqlConnection(strCon);
            bool SeModifico = false;
            List<SqlParameter> lstParametros = this.ObtenerParametros();
            string sql = "UPDATE Parametro SET Nombre = @Nombre, Valor = @Valor WHERE ID = @ID;";
            try
            {
                int res = 0;
                res = Persistencia.EjecutarNoQuery(con, sql, lstParametros, CommandType.Text, null);
                if (res > 0) SeModifico = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SeModifico;
        }

        public bool Eliminar(string strCon)
        {
            SqlConnection con = new SqlConnection(strCon);
            bool seBorro = false;
            List<SqlParameter> lstParametros = this.ObtenerParametros();
            string sql = "DELETE FROM Parametro WHERE ID = @ID";
            try
            {
                int resultado = 0;
                resultado = Persistencia.EjecutarNoQuery(con, sql, lstParametros, CommandType.Text, null);
                if (resultado > 0) seBorro = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return seBorro;
        }

        public List<Parametro> GetAll(string strCon)
        {
            SqlConnection con = new SqlConnection(strCon);
            List<Parametro> lstParametro = new List<Parametro>();
            string sql = "SELECT * FROM Parametro;";
            SqlDataReader reader = null;
            try
            {
                con.Open();
                reader = Persistencia.EjecutarConsulta(con, sql, null, CommandType.Text);
                while (reader.Read())
                {
                    Parametro par = new Parametro();
                    par.ID = Convert.ToInt32(reader["ID"]);
                    par.Nombre = reader["Nombre"].ToString();
                    par.Valor = reader["Valor"].ToString();
                    lstParametro.Add(par);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            return lstParametro;
        }

        public override List<SqlParameter> ObtenerParametros()
        {
            List<SqlParameter> lstParametros = new List<SqlParameter>();
            lstParametros.Add(new SqlParameter("@ID", this.ID));
            lstParametros.Add(new SqlParameter("@Nombre", this.Nombre));
            lstParametros.Add(new SqlParameter("@Valor", this.Valor));
            return lstParametros;
        }

        #endregion
    }
}
