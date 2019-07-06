using System;
using System.Xml.XPath;
using System.Data;
using DataHolders;
using System.Data.Common;
using System.Reflection;
using System.Data.SqlClient;



namespace DBConfiguration
{
    public class clsDataBase
    {
        protected string xmlConfigPath;

        public clsDataBase()
        {
        }

        public XPathNodeIterator GetArguments(string objectName)
        {
            XPathDocument xPathDocument = new XPathDocument(this.xmlConfigPath);
            XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
            XPathExpression xPathExpression = xPathNavigator.Compile(string.Concat("//object[@name='", objectName, "']/action/args"));
            XPathNodeIterator xPathNodeIterators = xPathNavigator.Select(xPathExpression);
            return xPathNodeIterators;
        }

        //public DataSet GetBatchQuery(dhDBnames DBNames, object DataHolderObject, string XmlName, DataSet DS, string[] TableNames)
        //{
        //    object dataHolderObject = DataHolderObject;
        //    string xmlName = XmlName;
        //    this.xmlConfigPath = DBNames.XmlFilePath;
        //    string str = string.Concat("Data Source=", DBNames.ServerName);
        //    str = string.Concat(str, ";Initial Catalog=", DBNames.Default_DB_Name);
        //    str = string.Concat(str, ";User ID=ammarmd;password=ammar2000;Max Pool Size=10");
        //    Database database = DatabaseFactory.CreateDatabase(str);
        //    DbCommand storedProcCommand = database.GetStoredProcCommand(this.GetSpname(xmlName).ToString());
        //    if (dataHolderObject != null)
        //    {
        //        Type type = dataHolderObject.GetType();
        //        XPathNodeIterator arguments = this.GetArguments(xmlName);
        //        while (arguments.MoveNext())
        //        {
        //            PropertyInfo property = type.GetProperty(arguments.Current.GetAttribute("AttribMaping", "").ToString());
        //            database.AddInParameter(storedProcCommand, arguments.Current.GetAttribute("name", "").ToString(), this.Getdbtype(arguments.Current.GetAttribute("DataType", "").ToString()), property.GetGetMethod().Invoke(dataHolderObject, BindingFlags.GetProperty, null, null, null));
        //        }
        //    }
        //    database.LoadDataSet(storedProcCommand, DS, TableNames);
        //    return DS;
        //}

        public DataSet GetDataSet(dhDBnames DBNames, object DataHolderObject, string XmlName, DataSet DS, string TableName)
        {
            object dataHolderObject = DataHolderObject;
            string xmlName = XmlName;
            this.xmlConfigPath = DBNames.XmlFilePath.ToString();
            string str = string.Concat("Data Source=", DBNames.ServerName);
            str = string.Concat(str, ";Initial Catalog=", DBNames.Default_DB_Name);
            str = string.Concat(str, ";User ID=", DBNames.DBUser);
            str = string.Concat(str, ";password=", DBNames.DBPassword);
            str = string.Concat(str, ";Max Pool Size=10");

            
            SqlConnection objCon = new SqlConnection(str);
            SqlDataAdapter objDataAdoptor = new SqlDataAdapter(this.GetSpname(xmlName).ToString(), objCon);
            objDataAdoptor.SelectCommand.CommandType = CommandType.StoredProcedure;
            // parameters
            //objDataAdoptor.SelectCommand.Parameters.AddWithValue("@iCityID", ObjCity.ICityID);



            //Database database = DatabaseFactory.CreateDatabase(str);
            //DbCommand storedProcCommand = database.GetStoredProcCommand(this.GetSpname(xmlName).ToString());
            if (dataHolderObject != null)
            {
                Type type = dataHolderObject.GetType();
                XPathNodeIterator arguments = this.GetArguments(xmlName);
                while (arguments.MoveNext())
                {
                    PropertyInfo property = type.GetProperty(arguments.Current.GetAttribute("AttribMaping", "").ToString());
                    if (property != null)
                    {
                        objDataAdoptor.SelectCommand.Parameters.AddWithValue(arguments.Current.GetAttribute("name", "").ToString(), property.GetGetMethod().Invoke(dataHolderObject, BindingFlags.GetProperty, null, null, null));
                        //database.AddInParameter(storedProcCommand, arguments.Current.GetAttribute("name", "").ToString(), this.Getdbtype(arguments.Current.GetAttribute("DataType", "").ToString()), property.GetGetMethod().Invoke(dataHolderObject, BindingFlags.GetProperty, null, null, null));
                    }
                }
            }
            //database.LoadDataSet(storedProcCommand, DS, TableName);
            objCon.Open();
            //DataSet dsNewDataSet = new DataSet();
            objDataAdoptor.Fill(DS, TableName);
            objCon.Close();
            return DS;
        }

        public DataSet GetDataSet(dhDBnames DBNames, object DataHolderObject, string XmlName)
        {
            object dataHolderObject = DataHolderObject;
            string xmlName = XmlName;
            this.xmlConfigPath = DBNames.XmlFilePath;
            string str1 = string.Concat("Data Source=", DBNames.ServerName);
            str1 = string.Concat(str1, ";Initial Catalog=", DBNames.Default_DB_Name);
            str1 = string.Concat(str1, ";User ID=", DBNames.DBUser);
            str1 = string.Concat(str1, ";password=", DBNames.DBPassword);
            str1 = string.Concat(str1, ";Max Pool Size=10");
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = str1;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = this.GetSpname(xmlName).ToString();
            if (dataHolderObject != null)
            {
                Type type = dataHolderObject.GetType();
                XPathNodeIterator arguments = this.GetArguments(xmlName);
                while (arguments.MoveNext())
                {
                    PropertyInfo property = type.GetProperty(arguments.Current.GetAttribute("AttribMaping", "").ToString());
                    if (property != null)
                    {
                        string str2 = arguments.Current.GetAttribute("name", "").ToString();
                        sqlCommand.Parameters.Add(new SqlParameter(str2, property.GetGetMethod().Invoke(dataHolderObject, BindingFlags.GetProperty, null, null, null)));
                    }
                }
            }
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            sqlConnection.Close();
            return dataSet;
        }
        // nor in user realy
        private DbType Getdbtype(string dbtype)
        {
            if (dbtype == "DbType.Int32")
            {
                return DbType.Int32;
            }
            if (dbtype == "DbType.Int")
            {
                return DbType.Int32;
            }
            if (dbtype == "DbType.Int64")
            {
                return DbType.Int64;
            }
            if (dbtype == "DbType.String")
            {
                return DbType.String;
            }
            if (dbtype == "DbType.DateTime")
            {
                return DbType.DateTime;
            }
            if (dbtype == "DbType.Double")
            {
                return DbType.Double;
            }
            if (dbtype == "DbType.Binary")
            {
                return DbType.Binary;
                
            }
            return DbType.String;
        }

        private void GetMethods(Type theType)
        {
            MethodInfo[] methods = theType.GetMethods();
            MethodInfo[] methodInfoArray = methods;
            foreach (MethodInfo methodInfo in methodInfoArray)
            {
                if (methodInfo.IsPrivate)
                {
                }
                if (methodInfo.IsStatic)
                {
                }
                if (methodInfo.IsConstructor)
                {
                }
            }
        }

        private void GetParameters(Type theType)
        {
            MethodInfo[] methods = theType.GetMethods();
            MethodInfo[] methodInfoArray = methods;
            foreach (MethodInfo methodInfo in methodInfoArray)
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
                if (parameters.GetLength(0) == 0)
                {
                }
                ParameterInfo[] parameterInfoArray = parameters;
                foreach (ParameterInfo parameterInfo in parameterInfoArray)
                {
                }
            }
        }

        private void GetProperties(object obj, Type theType)
        {
            PropertyInfo[] properties = theType.GetProperties();
            PropertyInfo[] propertyInfoArray = properties;
            foreach (PropertyInfo propertyInfo in propertyInfoArray)
            {
                if (propertyInfo.CanRead)
                {
                }
                else
                {
                }
                if (propertyInfo.CanWrite)
                {
                    continue;
                }
                PropertyInfo property = theType.GetProperty(propertyInfo.Name.ToString());
            }
        }

        public string GetSpname(string objectName)
        {
            XPathDocument xPathDocument = new XPathDocument(this.xmlConfigPath);
            XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
            XPathExpression xPathExpression = xPathNavigator.Compile(string.Concat("//object[@name='", objectName, "']/action"));
            XPathNodeIterator xPathNodeIterators = xPathNavigator.Select(xPathExpression);
            xPathNodeIterators.MoveNext();
            return xPathNodeIterators.Current.GetAttribute("spname", "");
        }

        public string GetType(string objectName)
        {
            XPathDocument xPathDocument = new XPathDocument(this.xmlConfigPath);
            XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
            XPathExpression xPathExpression = xPathNavigator.Compile(string.Concat("//object[@name='", objectName, "']/action"));
            XPathNodeIterator xPathNodeIterators = xPathNavigator.Select(xPathExpression);
            xPathNodeIterators.MoveNext();
            return xPathNodeIterators.Current.GetAttribute("type", "");
        }

        private void GetTypes(Type theType)
        {
            Assembly assembly = theType.Assembly;
            string @namespace = theType.Namespace;
            Type[] types = assembly.GetTypes();
            Type[] typeArray = types;
            foreach (Type type in typeArray)
            {
                if (type.Namespace == @namespace)
                {
                    if (type.IsPublic)
                    {
                    }
                    else
                    {
                    }
                    if (type.IsClass)
                    {
                    }
                    if (type.IsInterface)
                    {
                    }
                    if (type.IsEnum)
                    {
                    }
                }
            }
        }

        //private int InsertUpdateDelete_Trans(object obj, string objName)
        //{
        //    int num1;
        //    Database database = DatabaseFactory.CreateDatabase();
        //    DbConnection dbConnection = database.CreateConnection();
        //    using (dbConnection)
        //    {
        //        dbConnection.Open();
        //        DbTransaction dbTransaction = dbConnection.BeginTransaction();
        //        try
        //        {
        //            DbCommand storedProcCommand = database.GetStoredProcCommand(this.GetSpname(objName).ToString());
        //            if (obj != null)
        //            {
        //                Type type = obj.GetType();
        //                XPathNodeIterator arguments = this.GetArguments(objName);
        //                while (arguments.MoveNext())
        //                {
        //                    PropertyInfo property = type.GetProperty(arguments.Current.GetAttribute("AttribMaping", "").ToString());
        //                    database.AddInParameter(storedProcCommand, arguments.Current.GetAttribute("name", "").ToString(), this.Getdbtype(arguments.Current.GetAttribute("DataType", "").ToString()), property.GetGetMethod().Invoke(obj, BindingFlags.GetProperty, null, null, null));
        //                }
        //            }
        //            int num2 = database.ExecuteNonQuery(storedProcCommand);
        //            dbTransaction.Commit();
        //            num1 = num2;
        //        }
        //        catch (Exception exception)
        //        {
        //            Console.Write(exception.ToString());
        //            dbTransaction.Rollback();
        //            num1 = 0;
        //        }
        //        finally
        //        {
        //            dbConnection.Close();
        //        }
        //    }
        //    return num1;
        //}

        //public int InsertUpdateDeleteCommand(dhDBnames DBNames, object DataHolderObject, string XmlName)
        //{
        //    object dataHolderObject = DataHolderObject;
        //    string xmlName = XmlName;
        //    this.xmlConfigPath = DBNames.XmlFilePath;
        //    string str1 = string.Concat("Data Source=", DBNames.ServerName);
        //    str1 = string.Concat(str1, ";Initial Catalog=", DBNames.Default_DB_Name);
        //    str1 = string.Concat(str1, ";User ID=ammarmd;password=ammar2000;Max Pool Size=10");
        //    SqlConnection sqlConnection = new SqlConnection();
        //    sqlConnection.ConnectionString = str1;
        //    SqlCommand sqlCommand = new SqlCommand();
        //    sqlCommand.Connection = sqlConnection;
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.CommandText = this.GetSpname(xmlName).ToString();
        //    if (dataHolderObject != null)
        //    {
        //        Type type = dataHolderObject.GetType();
        //        XPathNodeIterator arguments = this.GetArguments(xmlName);
        //        while (arguments.MoveNext())
        //        {
        //            PropertyInfo property = type.GetProperty(arguments.Current.GetAttribute("AttribMaping", "").ToString());
        //            if (property != null)
        //            {
        //                string str2 = string.Concat("@", arguments.Current.GetAttribute("name", "").ToString());
        //                sqlCommand.Parameters.Add(new SqlParameter(str2, property.GetGetMethod().Invoke(dataHolderObject, BindingFlags.GetProperty, null, null, null)));
        //            }
        //        }
        //    }
        //    sqlConnection.Open();
        //    int num = sqlCommand.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    return num;
        //}




       
    }
}
