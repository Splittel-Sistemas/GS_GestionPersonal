using GPSInformation.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GPSInformation.DBManagers
{
    public class DarkAttributes<T> where T : new()
    {
        private DBConnection dBConnection { get; set; }
        private string Nametable { get; set; }

        public T Element { get; set; }

        public DarkAttributes()
        {
            Nametable = GetRealNameClass();
        }

        public DarkAttributes(DBConnection dBConnection)
        {
            this.dBConnection = dBConnection;
            Nametable = GetRealNameClass();
        }
        private string GetRealNameClass()
        {
            string Nombre = "";
            TableDB tableDefinifiton = GetClassAttribute();
            if (tableDefinifiton.IsMappedByLabels)
            {
                Nombre = tableDefinifiton.Name;
            }
            else
            {
                Nombre = typeof(T).Name;
            }
            return Nombre;
        }

        public bool Add()
        {
            TableDB tableDefinifiton = GetClassAttribute();
            if (tableDefinifiton.IsStoreProcedure)
            {
                return ActionsObject(DbManagerTypes.Add);
            }
            else
            {
                return ActionsObjectCode(DbManagerTypes.Add, tableDefinifiton);
            }
            
        }

        public bool Update()
        {
            TableDB tableDefinifiton = GetClassAttribute();
            if (tableDefinifiton.IsStoreProcedure)
            {
                return ActionsObject(DbManagerTypes.Update);
            }
            else
            {
                return ActionsObjectCode(DbManagerTypes.Update, tableDefinifiton);
            }
        }

        public bool Delete()
        {
            TableDB tableDefinifiton = GetClassAttribute();
            if (tableDefinifiton.IsStoreProcedure)
            {
                return ActionsObject(DbManagerTypes.Delete);
            }
            else
            {
                return ActionsObjectCode(DbManagerTypes.Delete, tableDefinifiton);
            }
        }
        public string GetStringValue(string Sentence)
        {
            var retunrDa = dBConnection.GetStringValue(Sentence);
            return DBNull.Value.Equals(retunrDa) ? "" : (string)retunrDa;
        }
        public int GetIntValue(string Sentence)
        {
            var retunrDa = dBConnection.GetIntegerValue(Sentence);
            return DBNull.Value.Equals(retunrDa) ? 0 : (int)retunrDa;
        }
        public double GetDoubleValue(string Sentence)
        {
            var retunrDa = dBConnection.GetDoublelValue(Sentence);
            return DBNull.Value.Equals(retunrDa) ? 0 : (double)retunrDa;
        }
        /// <summary>
        /// obtener ultimo id campo definido como IsKey = true
        /// </summary>
        /// <returns></returns>
        public int GetLastId()
        {
            var retunrDa = dBConnection.GetIntegerValue(string.Format("select max(Id{0}) from {0}", Nametable));
            return DBNull.Value.Equals(retunrDa) ? 0 : (int)retunrDa;
        }
        public int Count(string where = "")
        {
            if (where == "")
            {
                var retunrDa = dBConnection.GetIntegerValue(string.Format("select count(*) from {0}", Nametable));
                return DBNull.Value.Equals(retunrDa) ? 0 : (int)retunrDa;
            }
            else
            {
                var retunrDa = dBConnection.GetIntegerValue(string.Format("select count(*) from {0} where {1}", Nametable, where));
                return DBNull.Value.Equals(retunrDa) ? 0 : (int)retunrDa;
            }
        }
        public int LastInserted(string Statement)
        {
            return dBConnection.GetIntegerValue(Statement);
        }

        public int GetLastId(string nameCol, string Value)
        {
            return dBConnection.GetIntegerValue(string.Format("select max(Id{0}) from {0} where {1} = '{2}'", Nametable, nameCol, Value));
        }

        /// <summary>
        /// Obtiene el valor maximo de la columna seleccionada en base a una condicion where
        /// </summary>
        /// <param name="colMax">Columna DB</param>
        /// <param name="nameCol">Nombre de la columna </param>
        /// <param name="Value">valor de la columna</param>
        /// <returns></returns>
        public object GetMax(string colMax, string nameCol, string Value)
        {
            return dBConnection.GetValue(string.Format("select max({1}) from {0} where {2} = '{3}'", Nametable, colMax, nameCol, Value));
        }

        /// <summary>
        /// Obtiene el valor maximo de la columna seleccionada en base a una condicion where
        /// </summary>
        /// <param name="colMax">Columna DB</param>
        /// <returns></returns>
        public object GetMax(string colMax)
        {
            return dBConnection.GetValue(string.Format("select max({1}) from {0}", Nametable, colMax));
        }
        public object GetValue(string Statement)
        {
            return dBConnection.GetValue(Statement);
        }

        public T Get(int? id)
        {
            List<T> Lista = DataReader(string.Format("select * from {0} where {1} = '{2}'", Nametable, KeyCol(), id));
            if (Lista.Count == 0)
            {
                return default(T);
            }
            return Lista.ElementAt(0);
        }

        public T GetByColumn(string id, string nameCol)
        {
            List<T> Lista = DataReader(string.Format("select * from {0} where {1} = '{2}'", Nametable, nameCol, id));
            if (Lista.Count == 0)
            {
                return default(T);
            }
            return Lista.ElementAt(0);
        }
       

        public List<T> Get(Predicate<T> match)
        {
            return DataReader(string.Format("select * from {0}", Nametable)).FindAll(match);
        }

        public List<T> Get(string id, string nameCol)
        {
            return DataReader(string.Format("select * from {0} where {1} = '{2}'", Nametable, nameCol, id));
        }

        public List<T> GetIn(int[] keys, string nameCol)
        {
            
            return DataReader(string.Format("select * from {0} where {1} in ({2})", Nametable, nameCol, string.Join(", ", keys)));
        }

        public List<T> GetIn(List<int> keys, string nameCol, List<int> keys2, string nameCol2)
        {

            return DataReader(string.Format("select * from {0} where {1} in ({2}) and {3} in ({4})", Nametable, nameCol, string.Join(", ", keys), nameCol2, string.Join(", ", keys2)));
        }

        public List<T> GetList(string Columna1, string Columna1Val, string Columna2, string Columna1Val2)
        {
            List<T> Lista = DataReader(string.Format("select * from {0} where {1} = '{2}' and  {3} = '{4}'", Nametable, Columna1, Columna1Val, Columna2, Columna1Val2));
            return Lista;
        }

        public T Get(string Columna1, string Columna1Val, string Columna2, string Columna1Val2)
        {
            List<T> Lista = DataReader(string.Format("select * from {0} where {1} = '{2}' and  {3} = '{4}'", Nametable, Columna1, Columna1Val, Columna2, Columna1Val2));
            if (Lista.Count == 0)
            {
                return default(T);
            }
            return Lista.ElementAt(0);
        }

        public List<T> Get()
        {
            return DataReader(string.Format("select * from {0}", Nametable));
        }

        public string ColumName(string Name)
        {
            string columna = "";
            if (GetClassAttribute().IsMappedByLabels)
            {
                object exFormAsObj = Activator.CreateInstance(typeof(T));
                foreach (var prop in typeof(T).GetProperties())
                {
                    PropertyInfo propertyInfo = exFormAsObj.GetType().GetProperty(prop.Name);
                    ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));

                    if (prop.Name == Name)
                    {
                        columna = hiddenAttribute.Name;
                    }
                }
            }
            else
            {
                columna = Name;
            }

            return columna;
        }
        /// <summary>
        /// Obteenrr paginacion
        /// </summary>
        /// <param name="Page">Id de la pagina</param>
        /// <param name="RowsPerPage">Numero de registros por pagina</param>
        /// <returns></returns>
        public ModelPagination<T> DataPage(int Page, int RowsPerPage,string where = "", string OrderPage = "")
        {
            int TotalRows = dBConnection.GetIntegerValue(string.Format("select count(*) from {0}", Nametable));

            if (RowsPerPage <= 0)
                RowsPerPage = 10;

            decimal paginas1 = TotalRows / RowsPerPage;
            decimal MaxPages = Math.Ceiling(paginas1);
            if(Page == 0)
            {
                Page = 1;
            }

            if (Page > MaxPages + 1)
                Page = 1;

            if (OrderPage == "")
                OrderPage = $"order by Id{Nametable}";

            List<T> Lista = DataReader($"declare @PageNo INT ={Page} " +
                $"declare @RecordsPerPage INT = {RowsPerPage} " +
                $"IF @PageNo < 1 " +
                $"  SET @PageNo = 1 " +
                $"SELECT * FROM {Nametable} {where}  {OrderPage} " +
                $"OFFSET(@PageNo - 1) * @RecordsPerPage ROWS " +
                $"FETCH NEXT @RecordsPerPage ROWS ONLY ");

            var result = new ModelPagination<T>
            {
                Maxpage = Int32.Parse(MaxPages+"") +1,
                PageSelected = Page,
                Data = Lista,
                TotalRows = TotalRows,
                MaxPages = MaxPages,
                RowsPerPage = RowsPerPage
            };

            return result;
        }
        private string KeyCol()
        {
            string columna = "";
            if (GetClassAttribute().IsMappedByLabels)
            {
                object exFormAsObj = Activator.CreateInstance(typeof(T));
                foreach (var prop in typeof(T).GetProperties())
                {
                    PropertyInfo propertyInfo = exFormAsObj.GetType().GetProperty(prop.Name);
                    ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));

                    if (hiddenAttribute.IsKey)
                    {
                        columna = hiddenAttribute.Name;
                    }
                }
            }
            else
            {
                object exFormAsObj = Activator.CreateInstance(typeof(T));
                foreach (var prop in typeof(T).GetProperties())
                {
                    PropertyInfo propertyInfo = exFormAsObj.GetType().GetProperty(prop.Name);
                    ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));

                    if (hiddenAttribute.IsKey)
                    {
                        columna = prop.Name;
                    }
                }
            }

            return columna;
        }

        public List<T> GetSpecialStat(string SqlStatements)
        {
            return DataReader(SqlStatements);
        }

        public System.Data.SqlClient.SqlDataReader GetDataReader(string SqlStatements)
        {
            System.Data.SqlClient.SqlDataReader Data = dBConnection.GetDataReader(SqlStatements);

            return Data;
        }
        public T GetUnicSatatment(string SqlStatements)
        {
            List<T> Lista = DataReader(SqlStatements);
            if (Lista.Count == 0)
            {
                return default(T);
            }
            return Lista.ElementAt(0);
        }
        public List<T> GetOpenquery(string where = "", string Order = "")
        {
            return DataReader(string.Format("select * from {0} {1} {2}", Nametable, where, Order));
        }
        public T GetOpenquerys(string where = "")
        {
            List<T> Lista = DataReader(string.Format("select * from {0} {1}", Nametable, where));
            if (Lista.Count == 0)
            {
                return default(T);
            }
            return Lista.ElementAt(0);
        }
        private List<T> DataReader(string SqlStatements)
        {
            TableDB tableDefinifiton = GetClassAttribute();

            System.Data.SqlClient.SqlDataReader Data = dBConnection.GetDataReader(SqlStatements);
            List<T> Response = new List<T>();
            while (Data.Read())
            {
                object exFormAsObj = Activator.CreateInstance(typeof(T));
                foreach (var prop in typeof(T).GetProperties())
                {
                    PropertyInfo propertyInfo = exFormAsObj.GetType().GetProperty(prop.Name);
                    ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));

                    if (hiddenAttribute == null)
                    {
                        throw new Exceptions.GpExceptions(string.Format("The attribute was not found in the attribute '{0}', if you don´t want to use mapTable, please set IsMappedByLabels = false", prop.Name));
                    }

                    if (hiddenAttribute.IsMapped)
                    {
                        string NombrePropiedad = "";
                        if (tableDefinifiton.IsMappedByLabels)
                        {
                            NombrePropiedad = hiddenAttribute.Name.Trim();
                        }
                        else
                        {
                            NombrePropiedad = prop.Name;
                        }
                        
                        if (prop.PropertyType.Equals(typeof(DateTime)))
                        {
                            var value = Data.GetValue(Data.GetOrdinal(NombrePropiedad)) is System.DBNull ? DateTime.Now : Data.GetValue(Data.GetOrdinal(NombrePropiedad));
                            propertyInfo.SetValue(exFormAsObj, Convert.ChangeType(value, TypeCode.DateTime), null);
                        }
                        if (prop.PropertyType.Equals(typeof(DateTime?)))
                        {
                            var value = Data.GetValue(Data.GetOrdinal(NombrePropiedad)) is System.DBNull ? null : Data.GetValue(Data.GetOrdinal(NombrePropiedad));
                            propertyInfo.SetValue(exFormAsObj, value, null);
                        }
                        if (prop.PropertyType.Equals(typeof(TimeSpan)))
                        {
                            var value = Data.GetValue(Data.GetOrdinal(NombrePropiedad)) is System.DBNull ? null : Data.GetValue(Data.GetOrdinal(NombrePropiedad));
                            propertyInfo.SetValue(exFormAsObj, value, null);
                        }
                        if (prop.PropertyType.Equals(typeof(double)))
                        {
                            var value = Data.GetValue(Data.GetOrdinal(NombrePropiedad)) is System.DBNull ? 0 : Data.GetValue(Data.GetOrdinal(NombrePropiedad));
                            propertyInfo.SetValue(exFormAsObj, Convert.ChangeType(value, TypeCode.Double), null);
                        }
                        if (prop.PropertyType.Equals(typeof(string)))
                        {
                            var value = Data.GetValue(Data.GetOrdinal(NombrePropiedad)) is System.DBNull ? "" : Data.GetValue(Data.GetOrdinal(NombrePropiedad));
                            propertyInfo.SetValue(exFormAsObj, Convert.ChangeType(value, TypeCode.String), null);
                        }
                        if (prop.PropertyType.Equals(typeof(bool)))
                        {
                            var value = Data.GetValue(Data.GetOrdinal(NombrePropiedad)) is System.DBNull ? false : Data.GetValue(Data.GetOrdinal(NombrePropiedad));
                            propertyInfo.SetValue(exFormAsObj, Convert.ChangeType(value, TypeCode.Boolean), null);
                        }
                        if (prop.PropertyType.Equals(typeof(int)))
                        {
                            var value = Data.GetValue(Data.GetOrdinal(NombrePropiedad)) is System.DBNull ? 0 : Data.GetValue(Data.GetOrdinal(NombrePropiedad));
                            propertyInfo.SetValue(exFormAsObj, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                        }
                        
                    }
                }
                Response.Add((T)exFormAsObj);
            }
            Data.Close();
            
            return Response;
        }

        private bool ActionsObject(DbManagerTypes dbManagerTypes)
        {
            List<ProcedureModel> procedureModels = new List<ProcedureModel>();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.PropertyType.Equals(typeof(int)) || prop.PropertyType.Equals(typeof(string)) || prop.PropertyType.Equals(typeof(double)) || prop.PropertyType.Equals(typeof(TimeSpan)) || prop.PropertyType.Equals(typeof(DateTime)))
                {
                    PropertyInfo propertyInfo = Element.GetType().GetProperty(prop.Name);
                    procedureModels.Add(new ProcedureModel { Namefield = prop.Name, value = propertyInfo.GetValue(Element) });
                }
                if (prop.PropertyType.Equals(typeof(DateTime?)))
                {
                    PropertyInfo propertyInfo = Element.GetType().GetProperty(prop.Name);
                    procedureModels.Add(new ProcedureModel { Namefield = prop.Name, value = propertyInfo.GetValue(Element) });
                }
            }
            procedureModels.Add(new ProcedureModel { Namefield = "ModeProcedure", value = dbManagerTypes });
            dBConnection.StartProcedure(string.Format("Gps_{0}", Nametable), procedureModels);
            if (dBConnection.ErrorCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ActionsObjectCode(DbManagerTypes dbManagerTypes, TableDB tableDefinifiton)
        {
            //TableDB tableDefinifiton = GetClassAttribute();
            bool result = false;
            //mapeo de tabla con los nombres de los campos ya existentes
            string sentencia = "";
            string sentenciaVariables = "";
            foreach (var prop in typeof(T).GetProperties())
            {
                PropertyInfo propertyInfo = Element.GetType().GetProperty(prop.Name);
                ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));

                if (hiddenAttribute == null)
                {
                    throw new Exceptions.GpExceptions(string.Format("The attribute was not found in the attribute '{0}', if you don´t want to use mapTable, please set IsMappedByLabels = false", prop.Name));
                }
                if (tableDefinifiton.IsMappedByLabels)
                {
                    if (string.IsNullOrEmpty(hiddenAttribute.Name))
                    {
                        throw new Exceptions.GpExceptions(string.Format("The attribute {0} was setting like mapping column, the name is missing", prop.Name));
                    }
                }
                else
                {
                    hiddenAttribute.Name = prop.Name;
                }


                if (dbManagerTypes == DbManagerTypes.Add)
                {
                    if (!hiddenAttribute.IsKey && hiddenAttribute.IsMapped || hiddenAttribute.IsKeyNotIdenti == true)
                    {
                        //parametros de insert {table}({param1},{param2},...,{paramN})
                        sentencia += hiddenAttribute.Name + ",";
                        //valores values({val1},{val2},...,{valN})
                        sentenciaVariables += "@" + hiddenAttribute.Name + ",";
                    }
                }
                else if (dbManagerTypes == DbManagerTypes.Update)
                {
                    if (!hiddenAttribute.IsKey && hiddenAttribute.IsMapped)
                    {
                        //parametros de update set {param1} = {val1}, set {param2} = {val2}
                        if(!string.IsNullOrEmpty(tableDefinifiton.Created_at) && hiddenAttribute.Name != tableDefinifiton.Created_at || string.IsNullOrEmpty(tableDefinifiton.Created_at))
                        {
                            sentencia += hiddenAttribute.Name + " = @" + hiddenAttribute.Name + ",";
                        }
                    }
                    else if(hiddenAttribute.IsKey && hiddenAttribute.IsMapped)
                    {
                        // valores where {param1} = {val1}
                        sentenciaVariables = hiddenAttribute.Name + " = @" + hiddenAttribute.Name + "";
                    }
                    else
                    {
                        
                    }
                }
                else if (dbManagerTypes == DbManagerTypes.Delete)
                {
                    if (hiddenAttribute.IsKey)
                    {
                        sentenciaVariables = hiddenAttribute.Name + " = @" + hiddenAttribute.Name + "";
                    }
                }
                else
                {
                    throw new Exceptions.GpExceptions(string.Format("Delete action is not active"));
                }
            }
            //mapeo de valores
            if (dbManagerTypes == DbManagerTypes.Add)
            {
                string Statement = string.Format("INSERT INTO {0}({1}) VALUES({2})", Nametable, sentencia.Substring(0, sentencia.Length - 1), sentenciaVariables.Substring(0, sentenciaVariables.Length - 1));
                List<ProcedureModel> procedureModels = new List<ProcedureModel>();
                foreach (var prop in typeof(T).GetProperties())
                {
                    PropertyInfo propertyInfo = Element.GetType().GetProperty(prop.Name);
                    ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));
                    string variable = tableDefinifiton.IsMappedByLabels ? hiddenAttribute.Name : prop.Name;
                    if (!hiddenAttribute.IsKey && hiddenAttribute.IsMapped || hiddenAttribute.IsKeyNotIdenti)
                    {
                        if (!string.IsNullOrEmpty(tableDefinifiton.Created_at) && variable == tableDefinifiton.Created_at)
                        {
                            procedureModels.Add(new ProcedureModel { Namefield = variable, value = DateTime.Now });
                        }
                        else if (!string.IsNullOrEmpty(tableDefinifiton.Updated_at) && variable == tableDefinifiton.Updated_at)
                        {
                            procedureModels.Add(new ProcedureModel { Namefield = variable, value = DateTime.Now });
                        }
                        else
                        {
                            procedureModels.Add(new ProcedureModel { Namefield = variable, value = propertyInfo.GetValue(Element) });
                        }
                    }
                    else
                    {
                        
                    }
                }

                dBConnection.StartInsert(Statement, procedureModels);
                result = true;
            }
            else if (dbManagerTypes == DbManagerTypes.Update)
            {
                string Statement = string.Format("UPDATE {0} SET {1} WHERE {2} ", Nametable, sentencia.Substring(0, sentencia.Length - 1), sentenciaVariables);
                List<ProcedureModel> procedureModels = new List<ProcedureModel>();
                foreach (var prop in typeof(T).GetProperties())
                {
                    PropertyInfo propertyInfo = Element.GetType().GetProperty(prop.Name);
                    ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));
                    string variable = tableDefinifiton.IsMappedByLabels ? hiddenAttribute.Name : prop.Name;
                    if (hiddenAttribute.IsMapped)
                    {
                        if(!string.IsNullOrEmpty(tableDefinifiton.Updated_at) && variable == tableDefinifiton.Updated_at)
                        {
                            procedureModels.Add(new ProcedureModel { Namefield = variable, value = DateTime.Now });
                        }
                        else
                        {
                            if(!string.IsNullOrEmpty(tableDefinifiton.Created_at) && variable != tableDefinifiton.Created_at || string.IsNullOrEmpty(tableDefinifiton.Created_at))
                            {
                                procedureModels.Add(new ProcedureModel { Namefield = variable, value = propertyInfo.GetValue(Element) });
                            }
                        }
                    }
                }

                dBConnection.StartUpdate(Statement, procedureModels);
                result = true;
            }
            else if (dbManagerTypes == DbManagerTypes.Delete)
            {
                string Statement = string.Format("DELETE FROM  {0} WHERE {1} ", Nametable, sentenciaVariables);
                List<ProcedureModel> procedureModels = new List<ProcedureModel>();
                foreach (var prop in typeof(T).GetProperties())
                {
                    PropertyInfo propertyInfo = Element.GetType().GetProperty(prop.Name);
                    ColumnDB hiddenAttribute = (ColumnDB)propertyInfo.GetCustomAttribute(typeof(ColumnDB));

                    if (hiddenAttribute.IsMapped && hiddenAttribute.IsKey)
                    {
                        procedureModels.Add(new ProcedureModel { Namefield = tableDefinifiton.IsMappedByLabels ? hiddenAttribute.Name : prop.Name, value = propertyInfo.GetValue(Element) });
                    }
                }

                dBConnection.StartDelete(Statement, procedureModels);
                result = true;
            }
            else
            {
                throw new Exceptions.GpExceptions(string.Format("Delete action is not active"));
            }

            return result;
        }

        private TableDB GetClassAttribute()
        {
            TableDB tableDefinifiton = (TableDB)Attribute.GetCustomAttribute(typeof(T), typeof(TableDB));

            if (tableDefinifiton == null)
            {
                throw new Exceptions.GpExceptions(string.Format("The attribute was not found in the class '{0}'.", typeof(T).Name));
            }
            return tableDefinifiton;
        }

    }
    public class ModelPagination<T>
    {
        public IList<T> Data { get; set; }
        public int TotalRows { get; set; }
        public int Maxpage { get; set; }
        public int PageSelected { get; set; }
        public decimal MaxPages { get; internal set; }
        public int RowsPerPage { get; internal set; }

        public List<Pages> Pages { 
            get {
                var lista = new List<Pages>();

                if ((PageSelected - 4) > 0 && (PageSelected + 4) <= Maxpage)
                {
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = PageSelected - 1, Tipe = PagesButons.Before });
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = 1, Tipe = PagesButons.Page });
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Tipe = PagesButons.Space });
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = PageSelected - 1, Tipe = PagesButons.Page });
                    lista.Add(new DBManagers.Pages { Active = true, Show = true, Numero = PageSelected, Tipe = PagesButons.Page });
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = PageSelected + 1, Tipe = PagesButons.Page });
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Tipe = PagesButons.Space });
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = Maxpage, Tipe = PagesButons.Page });
                    lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = PageSelected + 1, Tipe = PagesButons.Next });
                }
                else
                {
                    if ((PageSelected - 4) <= 0 && Maxpage >5)
                    {
                        for (int pagina = 1; pagina <= 5; pagina++)
                        {
                            lista.Add(new DBManagers.Pages { Active = PageSelected == pagina ?  true : false, Show = true, Numero = pagina, Tipe = PagesButons.Page });
                        }
                        lista.Add(new DBManagers.Pages { Active = false, Show = true, Tipe = PagesButons.Space });
                        lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = Maxpage, Tipe = PagesButons.Page });
                        lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = PageSelected + 1, Tipe = PagesButons.Next });
                    }
                    else if ((PageSelected + 4) >= Maxpage && Maxpage > 5)
                    {
                        lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = PageSelected - 1, Tipe = PagesButons.Before });
                        lista.Add(new DBManagers.Pages { Active = false, Show = true, Numero = 1, Tipe = PagesButons.Page });
                        lista.Add(new DBManagers.Pages { Active = false, Show = true, Tipe = PagesButons.Space });
                        for (int pagina = Maxpage - 5; pagina <= Maxpage; pagina++)
                        {
                            lista.Add(new DBManagers.Pages { Active = PageSelected == pagina ? true : false, Show = true, Numero = pagina, Tipe = PagesButons.Page });
                        }
                    }
                    else
                    {
                        for (int pagina = 1; pagina <= Maxpage; pagina++)
                        {
                            lista.Add(new DBManagers.Pages { Active = PageSelected == pagina ? true : false, Show = true, Numero = pagina, Tipe = PagesButons.Page });
                        }
                    }
                }
                return lista;
            } 
        }

    }

    public class Pages
    {
        public int Numero { get; set; }
        public bool Show { get; set; }
        public bool Active { get; set; }
        public PagesButons Tipe { get; set; }

    }

    public enum DbManagerTypes
    {
        Add = 1,
        Update = 2,
        Delete = 3
    }

    public enum PagesButons
    {
        Page = 1,
        Before = 2,
        Next = 3,
        Space = 4
    }
}