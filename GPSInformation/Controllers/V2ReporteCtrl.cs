using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Request;
using GPSInformation.Responses;
using GPSInformation.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GPSInformation.Controllers
{
    public class V2ReporteCtrl
    {
        #region Atributos
        /// <summary>
        /// controlador de objetos 
        /// </summary>
        public DarkManager _darkM;
        /// <summary>
        /// controlador para acciones de usuario
        /// </summary>
        public UsuarioCtrl _UsrCrt;
        /// <summary>
        /// Cargar transacciones por metodo
        /// </summary>
        public bool LoadTranssByMethod { get; set; }
        /// <summary>
        /// Id del usuario
        /// </summary>
        public int _IdUsuario { get; internal set; }
        /// <summary>
        /// Id de la persona
        /// </summary>
        public int _IdPersona { get; internal set; }
        public readonly int _AdminReportes = 1056;
        public readonly int _VerReportes = 1057;
        /// <summary>
        /// ids de permisos por usuario en session
        /// </summary>
        public List<AccesosUs> _Accesos { get; internal set; }
        #endregion

        #region Constructores
        public V2ReporteCtrl(DarkManager darkManager, int IdUsuario, int IdPersona)
        {
            this._darkM = darkManager;
            this._IdUsuario = IdUsuario;
            this._IdPersona = IdPersona;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.Reporte);
            this._darkM.LoadObject(GpsManagerObjects.ReporteAccss);
            this._darkM.LoadObject(GpsManagerObjects.SystSelect);

            _UsrCrt = new UsuarioCtrl(_darkM, true);

            //obtener permisos
            _Accesos = _UsrCrt.ValidatePermis(IdUsuario, new int[] { _AdminReportes, _VerReportes });
        }
        #endregion
        public int Edit(Reporte reporte)
        {
            var accesos = _Accesos.Find(a => a.IdSubModulo == _AdminReportes);
            if (accesos != null && !accesos.TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para administrar", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }

            var data = Details(reporte.IdReporte);


            data.Activo = reporte.Activo;
            data.Descripcion = reporte.Descripcion;
            data.Parametros = reporte.Parametros;
            data.Sentencia = reporte.Sentencia;
            data.Editado = DateTime.Now;
            //data.Columnas = reporte.Columnas;
            _darkM.Reporte.Element = data;
            _darkM.Reporte.Update();
            return reporte.IdReporte;
        }
        public int Create(Reporte reporte)
        {
            var accesos = _Accesos.Find(a => a.IdSubModulo == _AdminReportes);
            if (accesos != null && !accesos.TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para administrar", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            reporte.IdReporte = _darkM.Reporte.GetLastId() + 1;
            reporte.Activo = false;
            reporte.Creado = DateTime.Now;
            reporte.Editado = DateTime.Now;

            // obtener pisibles vaariables
            //string pattern = @"\b_var_\w+\b";
            //MatchCollection matches = Regex.Matches(reporte.Sentencia, pattern);

            //List<Rpt_Aux_parame> ParametrosD = new List<Rpt_Aux_parame>();

            //for (int i = 0; i < matches.Count; i++)
            //{
            //    string variable = matches[i].Value.ToString();
            //    if(ParametrosD.Find( a => a.Variable == variable) == null)
            //    {
            //        ParametrosD.Add(new Rpt_Aux_parame
            //        {
            //            Descripcion = $"variable: {variable}",
            //            Multiple = 2,
            //            Valor = "a",
            //            Variable = variable,
            //            OptionsSQL = "",
            //            Tipo = "string"
            //        });
            //    }
            //}

            //reporte.Parametros =  JsonConvert.SerializeObject(ParametrosD);

            _darkM.Reporte.Element = reporte;
            _darkM.Reporte.Add();
            return reporte.IdReporte;
        }

        /// <summary>
        /// obtener select
        /// </summary>
        /// <param name="Sentence"></param>
        /// <returns></returns>
        public List<SystSelect> GetSystSelects(string Sentence)
        {
            return _darkM.SystSelect.GetSpecialStat(Sentence);
        }
        /// <summary>
        /// Ejecutar reporte existente
        /// </summary>
        /// <param name="IdReporte"></param>
        /// <param name="OmitCols"></param>
        /// <param name="Parametros"></param>
        /// <returns></returns>
        public ResReporteRun EjecutarExistente(int IdReporte, List<string> OmitCols, List<Rpt_Aux_parame> Parametros)
        {
            //extraer datos del reporte
            var reporte = Details(IdReporte);
            string reporteSentencia = reporte.Sentencia;
            //validar parametros
            if (reporte.ParametrosD.Count > 0)
            {
                if( Parametros is null  || Parametros != null && Parametros.Count <= 0 || Parametros != null && Parametros.Count(a => string.IsNullOrEmpty(a.Valor)) > 0)
                    throw new GPException { Description = $"Estimado usuario por favor llena los parametros requeridos", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };


                reporte.ParametrosD.ForEach(par =>
                {
                    var variable = Parametros.Find(a => a.Variable == par.Variable);
                    if (variable is null)
                        throw new GPException { Description = $"Estimado usuario por favor introduce un valor para: {par.Descripcion}", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

                    if(par.Tipo == "DateTime")
                    {
                        DateTime Fecha = DateTime.Now;
                        if(!DateTime.TryParse(variable.Valor, out Fecha))
                            throw new GPException { Description = $"El parametro: '{par.Descripcion}' no es valido", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

                        reporte.Sentencia = reporte.Sentencia.Replace(par.Variable, Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else  if (par.Tipo == "Date")
                    {
                        DateTime Fecha = DateTime.Now;
                        if (!DateTime.TryParse(variable.Valor, out Fecha))
                            throw new GPException { Description = $"El parametro: '{par.Descripcion}' no es valido", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

                        reporte.Sentencia = reporte.Sentencia.Replace(par.Variable, Fecha.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        reporte.Sentencia = reporte.Sentencia.Replace(par.Variable, variable.Valor);
                        
                    }
                });
            }

            var dataInfo = _darkM.dBConnection.GetDataReader(reporte.Sentencia);
            var columns = new List<string>();
            var ReqReporteRun = new ResReporteRun {
                Columnas = new List<string>(),
                Filas =  new List<object[]>(),
                NombreReporte = reporte.Descripcion
            };
            // extraer columnas
            for (int i = 0; i < dataInfo.FieldCount; i++)
            {
                columns.Add(dataInfo.GetName(i));
                if (OmitCols != null  || OmitCols.Count > 0)
                {
                    if(!OmitCols.Contains(dataInfo.GetName(i)))
                        ReqReporteRun.Columnas.Add(dataInfo.GetName(i));
                }
                else
                {
                    ReqReporteRun.Columnas.Add(dataInfo.GetName(i));
                }
                
            }




            //obtener datos de filas
            while (dataInfo.Read())
            {
                List<object> Valores = new List<object>();

                ReqReporteRun.Columnas.ForEach(Col =>
                {
                    var dato = dataInfo.GetValue(dataInfo.GetOrdinal(Col));
                    Valores.Add(dato is System.DBNull ? "" : dato);
                });
                ReqReporteRun.Filas.Add(Valores.ToArray());
            }
            dataInfo.Close();

            reporte.Columnas = JsonConvert.SerializeObject(columns);
            reporte.Sentencia = reporteSentencia;
            _darkM.Reporte.Element = reporte;
            _darkM.Reporte.Update();


            return ReqReporteRun;
        }
        /// <summary>
        /// Ver detalles de reporte(sin ejecutar consulta)
        /// </summary>
        /// <param name="IdReporte"></param>
        /// <returns></returns>
        public Reporte Details(int IdReporte)
        {
            //validar permisos admin y lectura
            if (_Accesos.Count(ac => ac.TieneAcceso) == 0)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para ver detalles del reporte", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            var reporte = _darkM.Reporte.Get(IdReporte);
            
            //vaidar existencia del reporte solicitado
            if(reporte is null)
                throw new GPException { Description = $"Estimado usuario no fue encontrado el reporte solicitado", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            
            //valdiar que el 
            var asignado = _darkM.ReporteAccss.GetOpenquerys($"where IdUsuario = {_IdUsuario} and Access = 1 and IdReporte = {IdReporte}");
            var accesosLec = _Accesos.Find(a => a.IdSubModulo == _VerReportes);
            if (accesosLec.TieneAcceso && asignado is null || accesosLec.TieneAcceso && !asignado.Access)
                throw new GPException { Description = $"Estimado usuario no tiene permisos para ver detalles de este reporte, por favor contacte al administrador del sitio", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

            return reporte;
        }
        /// <summary>
        /// obtener reportes modo administrativo
        /// </summary>
        /// <returns></returns>
        public List<Reporte> GetAdmin()
        {
            //var data = new List<Reporte>();
            var asignados = new List<ReporteAccss>();

            var accesos = _Accesos.Find(a => a.IdSubModulo == _AdminReportes);
            if (accesos != null && !accesos.TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para administrar", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            //asignados = _darkM.ReporteAccss.Get();

            //asignados.ForEach(ac =>
            //{
            //    var reporte = _darkM.Reporte.Get(ac.IdReporte);
            //    data.Add(reporte);
            //});
            return _darkM.Reporte.Get();
        }
        /// <summary>
        /// ver reportes por usuario
        /// </summary>
        /// <returns></returns>
        public List<Reporte> GetByUsuario()
        {
            var data = new List<Reporte>();
            var asignados = new List<ReporteAccss>();

            var accesos = _Accesos.Find(a => a.IdSubModulo == _VerReportes);
            if (accesos != null && !accesos.TieneAcceso)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para visualizar reportes", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            
            asignados = _darkM.ReporteAccss.GetOpenquery($"where IdUsuario = {_IdUsuario} and Access = 1", "");
            
            asignados.ForEach(ac =>
            {
                var reporte = _darkM.Reporte.Get(ac.IdReporte);
                data.Add(reporte);
            });
            return data;
        }
        /// <summary>
        /// terminar controllador
        /// </summary>
        public void Terminar()
        {
            _darkM.CloseConnection();
            _darkM.Reporte = null;
            _darkM.ReporteAccss = null;
            _UsrCrt = null;
            _darkM = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    
}
