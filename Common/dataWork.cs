using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
/// <summary>
///
/// </summary>
public class dataWork
{
    private string _error = "";
    private string _noSafe = "drop |delete |insert +into |update |create |set |exec";//查询时危险字符；
    /// <summary>
    /// 错误信息
    /// </summary>
    public string Error
    {
        get { return _error; }
        set { _error = value; }
    }
    private SqlDataAdapter sda;
    private SqlCommand cmd;
    private DataSet ds;
    private SqlConnection conn;


    private SqlDataReader sdr;
    public dataWork()//定义构造函数打开数据库连接；
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EnergyContext"].ToString());
        conn.Open();
    }

    /// <summary>
    /// 执行查询返回行数
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public int SelectCount(string sql)
    {
        int k = 0;
        Regex reg = new Regex(_noSafe, RegexOptions.IgnoreCase);
        if (reg.IsMatch(sql))
        {
            throw new System.Exception("警告！！不安全SELECT! ");
        }
        cmd = new SqlCommand(sql, conn);
        try
        {
            k = Convert.ToInt32(cmd.ExecuteScalar());
            ///return k;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return k;
    }
    /// <summary>
    /// 执行查询并返回第一行，第一列的值
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public string SelectNo1(string sql)
    {
        Regex reg = new Regex(_noSafe, RegexOptions.IgnoreCase);
        if (reg.IsMatch(sql))
        {
            throw new System.Exception("警告！！不安全SELECT! ");
        }
        cmd = new SqlCommand(sql, conn);
        string reV = "";
        try
        {
            reV = cmd.ExecuteScalar().ToString();
            ///return reV;
        }
        catch
        {
            ///return reV;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return reV;
    }


    /// <summary>
    /// 执行SQL 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns>成功:true;失败:false;</returns>
    public bool ExecSQL(string sql)
    {
        bool bl = true;
        cmd = new SqlCommand(sql, conn);
        try
        {
            cmd.ExecuteNonQuery();
            ///return true;
        }
        catch (Exception e)
        {
            Error = e.Message;
            bl = false;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return bl;
    }
    /// 定义事务
    /// <summary>
    /// 定义事务
    /// </summary>
    /// <param name="sql_insert">SQL组</param>
    /// <returns></returns>
    public bool CTransaction(string sql_insert)//定义加数据和新建表的函数；
    {
        bool bl = true;
        using (conn)
        {
            SqlTransaction trans;//定义事务
            trans = conn.BeginTransaction();
            string sql = sql_insert;
            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
                ///return true;
            }
            catch
            {
                trans.Rollback();//注册失败，回滚事务
                bl = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return bl;
        }
    }
    /// <summary>
    /// 返回SqlDataReader
    /// </summary>
    /// <param name="sql">SQL</param>
    /// <returns></returns>
    public SqlDataReader GetReader(string sql)
    {
        try
        {
            cmd = new SqlCommand(sql, conn);
            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (SqlException e)
        {
            Error = e.Message;
            ///return sdr;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return sdr;
    }
    /// <summary>
    /// 返回Dataset
    /// </summary>
    /// <param name="sql">SQL</param>
    /// <returns></returns>
    public DataSet GetDS(string sql)
    {
        Regex reg = new Regex(_noSafe, RegexOptions.IgnoreCase);
        //if (reg.IsMatch(sql))
        //{
        //    throw new System.Exception("警告！！不安全SELECT! ");
        //}
        try
        {
            cmd = new SqlCommand(sql, conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch (Exception e)
        {
            Error = e.Message;
            ///return ds;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

        return ds;
    }

    #region 新加以传参数得到ds
    /// <summary>
    /// 传参数形式执行sql
    /// </summary>
    /// <param name="FieldsParameter">Hashtable key：列名,value：值 ht.add("title","%abc%")</param>
    /// <param name="sql">查询sql 如：select * from T where id=@id and title like @title;</param>
    /// <returns>DataSet</returns>
    public bool ExecSQL(Hashtable FieldsParameter, string sql)
    {
        bool bl = true;
        int C = FieldsParameter.Count;
        SqlParameter[] Parm = new SqlParameter[C];

        int i = 0;
        foreach (DictionaryEntry de in FieldsParameter)
        {
            Parm[i] = new SqlParameter(de.Key.ToString(), de.Value.ToString());
            i++;
        }

        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter pm in Parm)
            {
                if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) && (pm.Value == null))
                {
                    pm.Value = DBNull.Value;
                }
                cmd.Parameters.Add(pm);
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Error = e.Message;//捕获错误info
            bl = false;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

        return bl;
    }


    /// <summary>
    /// 传参数形式得到 ds
    /// </summary>
    /// <param name="FieldsParameter">Hashtable key：列名,value：值 ht.add("title","%abc%")</param>
    /// <param name="sql">查询sql 如：select * from T where id=@id and title like @title;</param>
    /// <returns>DataSet</returns>
    public DataSet GetDS(Hashtable FieldsParameter, string sql)
    {
        int C = FieldsParameter.Count;
        SqlParameter[] Parm = new SqlParameter[C];

        int i = 0;
        foreach (DictionaryEntry de in FieldsParameter)
        {
            Parm[i] = new SqlParameter(de.Key.ToString(), de.Value.ToString());
            i++;
        }

        DataSet ds = new DataSet();
        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter pm in Parm)
            {
                if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) && (pm.Value == null))
                {
                    pm.Value = DBNull.Value;
                }
                cmd.Parameters.Add(pm);
            }
            SqlDataAdapter sqda = new SqlDataAdapter(cmd);
            sqda.Fill(ds);
        }
        catch (Exception e)
        {
            Error = e.Message;//捕获错误info
            ds = null;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

        return ds;
    }

    /// <summary>
    /// 执行查询并返回第一行，第一列的值
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public string SelectNo1(Hashtable FieldsParameter, string sql)
    {
        string result = "";
        int C = FieldsParameter.Count;
        SqlParameter[] Parm = new SqlParameter[C];

        int i = 0;
        foreach (DictionaryEntry de in FieldsParameter)
        {
            Parm[i] = new SqlParameter(de.Key.ToString(), de.Value.ToString());
            i++;
        }

        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter pm in Parm)
            {
                if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) && (pm.Value == null))
                {
                    pm.Value = DBNull.Value;
                }
                cmd.Parameters.Add(pm);
            }
            result = cmd.ExecuteScalar().ToString();
        }
        catch (Exception e)
        {
            Error = e.Message;//捕获错误info
            ///return "";
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return result;
    }

    /// <summary>
    /// 传参数执行查询返回行数
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public int SelectCount(Hashtable FieldsParameter, string sql)
    {

        int C = FieldsParameter.Count;
        SqlParameter[] Parm = new SqlParameter[C];

        int i = 0;
        foreach (DictionaryEntry de in FieldsParameter)
        {
            Parm[i] = new SqlParameter(de.Key.ToString(), de.Value.ToString());
            i++;
        }
        int k = 0;
        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter pm in Parm)
            {
                if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) && (pm.Value == null))
                {
                    pm.Value = DBNull.Value;
                }
                cmd.Parameters.Add(pm);
            }
            k = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception e)
        {
            Error = e.Message;//捕获错误info
            k = -1;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return k;
    }


    #endregion


    /// 返回Dataset
    /// <summary>
    /// 返回Dataset
    /// </summary>
    /// <param name="sql">SQL</param>
    /// <param name="tab">表名</param>
    /// <returns></returns>
    public DataSet GetDS(string sql, string tab)
    {
        Regex reg = new Regex(_noSafe, RegexOptions.IgnoreCase);
        if (reg.IsMatch(sql))
        {
            throw new System.Exception("警告！！不安全SELECT! ");
        }
        DataSet ds = new DataSet();
        try
        {
            cmd = new SqlCommand(sql, conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(ds, tab);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return ds;
    }
    /// <summary>
    /// 返回Datatable
    /// </summary>
    /// <param name="sql">SQL语句 select</param>
    /// <param name="tab">表名</param>
    /// <returns></returns>
    public DataTable GetTab(string sql, string tab)
    {
        Regex reg = new Regex(_noSafe, RegexOptions.IgnoreCase);
        if (reg.IsMatch(sql))
        {
            throw new System.Exception("警告！！不安全SELECT! ");
        }
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, tab);
            dt = ds.Tables[tab];
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return dt;
    }
    /// <summary>
    /// 返回Datatable
    /// </summary>
    /// <param name="sql">SQL语句 select</param>
    /// <returns></returns>
    public DataTable GetTab(string sql)
    {
        Regex reg = new Regex(_noSafe, RegexOptions.IgnoreCase);
        if (reg.IsMatch(sql))
        {
            throw new System.Exception("警告！！不安全SELECT! ");
        }
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dt = ds.Tables[0];
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return dt;
    }


    /// 邦定DataList数据
    /// <summary>
    /// 邦定DataList数据
    /// </summary>
    /// <param name="Dl">DataList</param>
    /// <param name="sql">SQL语句</param>
    /// <param name="KeyField">关联DataList里DataKeyField的键字段</param>
    /// <returns></returns>
    public int BindDataList(DataList Dl, string sql, string KeyField)
    {
        Regex reg = new Regex(_noSafe, RegexOptions.IgnoreCase);
        if (reg.IsMatch(sql))
        {
            throw new System.Exception("警告！！不安全SELECT! ");
        }
        try
        {
            DataSet ds = GetDS(sql);
            Dl.DataSource = ds;
            Dl.DataKeyField = KeyField;
            Dl.DataBind();
            return ds.Tables[0].Rows.Count;
        }
        catch
        {
            return 0;
        }
    }
    private StringBuilder IDlist = new StringBuilder();
    public string GetSubIDToEnd(string startid, bool includethis)
    {
        IDlist = new StringBuilder();
        startid = startid == "" ? "-1" : startid;
        Recursion(startid);
        if (conn.State == ConnectionState.Open) conn.Close();//如果数据库连接打开状态则关闭
        IDlist.Append("-1");
        if (includethis)
        {
            IDlist.Append("," + startid);
        }
        return IDlist.ToString();
    }

    #region 传参数执行sql 源来自Array和Hashtable
    /// 执行带有参数SQL
    /// <summary>
    /// 执行带有参数SQL，
    /// </summary>
    /// <param name="SQL">SQL</param>
    /// <param name="parameters">参数</param>
    /// <returns></returns>
    private bool ExecParameters(string SQL, SqlParameter[] parameters)
    {
        bool bl = true;
        try
        {
            SqlCommand cmd = new SqlCommand(SQL, conn);
            foreach (SqlParameter pm in parameters)
            {
                if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) &&
    (pm.Value == null))
                {
                    pm.Value = DBNull.Value;
                }
                cmd.Parameters.Add(pm);
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Error = e.Message;//捕获错误info
            bl = false;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return bl;
    }
    ///整理SQL参数并执行
    /// <summary>
    ///整理SQL参数并执行
    /// </summary>
    /// <param name="Mode">SQL类型:insert or update</param>
    /// <param name="Fields">参数字段</param>
    /// <param name="Parameter">参数数组</param>
    /// <param name="TableName">表名</param>
    /// <param name="Condition">条件 如：id=2</param>
    /// <returns></returns>       
    public bool ExecByParameter(string Mode, string[] Fields, string[] Parameter, string TableName, string Condition)
    {
        int C = Fields.Length;
        SqlParameter[] Parm = new SqlParameter[C];
        string sql = "";
        sql = GetSqlParameters(Mode, Fields, TableName, Condition);

        for (int s = 0; s < C; s++)
        {
            Parm[s] = new SqlParameter(Fields[s], Parameter[s]);
        }
        return ExecParameters(sql, Parm);
        //SELECT @@identity AS 'id' 
    }

    /// <summary>
    ///整理SQL参数并执行 from Hashtable
    /// </summary>
    /// <param name="Mode">SQL类型:insert or update</param>
    /// <param name="FieldsParameter">字段和参数 Hashtable key=Fidlds; value=Parameter</param>
    /// <param name="TableName">表名</param>
    /// <param name="Condition">条件 如：id=2</param>
    /// <returns></returns>       
    public bool ExecByParameter(string Mode, Hashtable FieldsParameter, string TableName, string Condition)
    {
        int C = FieldsParameter.Count;
        SqlParameter[] Parm = new SqlParameter[C];
        int i = 0;
        string sql = "";
        sql = GetSqlParameters(Mode, FieldsParameter, TableName, Condition);
        foreach (DictionaryEntry de in FieldsParameter)
        {
            Parm[i] = new SqlParameter(de.Key.ToString(), de.Value.ToString());
            i++;
        }
        return ExecParameters(sql, Parm);
        //SELECT @@identity AS 'id' 
    }
    ///整理SQL参数并执行事务,如有失败回滚
    /// <summary>
    ///整理SQL参数并执行事务,如有失败回滚
    /// </summary>
    /// <param name="Mode">SQL类型:insert or update</param>
    /// <param name="Parameter">参数数组</param>
    /// <param name="Fields">参数字段</param>
    /// <param name="TableName">表名</param>
    /// <param name="Condition">条件 如：id=2</param>
    /// <param name="ElseSQL">另外的SQL可为空</param>
    /// <returns></returns>       
    public bool ExecTransaction(string Mode, string[] Fields, string[] Parameter, string TableName, string Condition, string ElseSQL)
    {
        bool bl = true;
        int C = Fields.Length;
        SqlParameter[] Parm = new SqlParameter[C];
        string sql = "";
        sql = GetSqlParameters(Mode, Fields, TableName, Condition);
        sql = ElseSQL + ";" + sql;
        for (int s = 0; s < C; s++)
        {
            Parm[s] = new SqlParameter(Fields[s], Parameter[s]);
        }
        using (conn)
        {
            SqlTransaction trans;//定义事务
            trans = conn.BeginTransaction();
            try
            {
                cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter pm in Parm)
                {
                    if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) &&
        (pm.Value == null))
                    {
                        pm.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(pm);
                }

                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
                ///return true;
            }
            catch
            {
                trans.Rollback();//注册失败，回滚事务

                conn.Close();
                conn.Dispose();
                bl = false;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return bl;
        }
    }

    ///整理SQL参数执行插入并返回ID
    /// <summary>
    ///整理SQL参数执行插入并返回ID
    /// </summary>
    /// <param name="Fields">字段数组</param>
    /// <param name="Parameter">值数组</param>
    /// <param name="TableName">表名</param>
    /// <returns></returns>       
    public string ExecInsert(string[] Fields, string[] Parameter, string TableName)
    {
        int C = Fields.Length;
        SqlParameter[] Parm = new SqlParameter[C];
        string FieStr = "";
        string ParStr = "";
        string sql = "";
        for (int i = 0; i < C; i++)
        {
            if (i < (C - 1))
            {
                FieStr += Fields[i] + ",";
                ParStr += "@" + Fields[i] + ",";
            }
            else
            {
                FieStr += Fields[i];
                ParStr += "@" + Fields[i];
            }
        }
        sql = string.Format("insert into {0} ({1}) values ({2});SELECT @@identity AS 'id';", TableName, FieStr, ParStr);
        for (int s = 0; s < C; s++)
        {
            Parm[s] = new SqlParameter(Fields[s], Parameter[s]);
        }
        string reV = "";
        //  try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter pm in Parm)
            {
                if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) &&
    (pm.Value == null))
                {
                    pm.Value = DBNull.Value;
                }
                cmd.Parameters.Add(pm);
            }
            reV = cmd.ExecuteScalar().ToString();
        }
        //catch (Exception e)
        //{
        //    string err = e.Message;//捕获错误info
        //    return "";
        //}
        //finally
        //{
        //    conn.Close();
        //    conn.Dispose();
        //}
        conn.Close();
        conn.Dispose();
        return reV;
    }

    ///整理SQL参数执行插入并返回ID  from Hashtable
    /// <summary>
    ///整理SQL参数执行插入并返回ID from Hashtable
    /// </summary>
    /// <param name="Fields">字段数组</param>
    /// <param name="Parameter">值数组</param>
    /// <param name="TableName">表名</param>
    /// <returns></returns>       
    public string ExecInsert(Hashtable FieldsParameter, string TableName)
    {
        int C = FieldsParameter.Count;
        SqlParameter[] Parm = new SqlParameter[C];
        int i = 0;
        string sql = "";
        sql = GetSqlParameters("insert", FieldsParameter, TableName, "") + ";SELECT @@identity AS 'id';";
        foreach (DictionaryEntry de in FieldsParameter)
        {
            Parm[i] = new SqlParameter(de.Key.ToString(), de.Value.ToString());
            i++;
        }
        string reV = "";
        try
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter pm in Parm)
            {
                if ((pm.Direction == ParameterDirection.InputOutput || pm.Direction == ParameterDirection.Input) &&
    (pm.Value == null))
                {
                    pm.Value = DBNull.Value;
                }
                cmd.Parameters.Add(pm);
            }
            reV = cmd.ExecuteScalar().ToString();
        }
        catch (Exception e)
        {
            Error = e.Message;//捕获错误info
            ///return "";
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }

        return reV;
    }
    /// <summary>
    /// 整理SQL参数执行更新
    /// </summary>
    /// <param name="FieldsParameter">参数字段</param>
    /// <param name="TableName">表名</param>
    /// <param name="Condition">条件 如：id=2</param>
    /// <returns></returns>
    public bool ExecUpdate(Hashtable FieldsParameter, string TableName, string Condition)
    {
        return ExecByParameter("update", FieldsParameter, TableName, Condition);
    }

    /// 自动整理Sql参数
    /// <summary>
    /// 自动整理Sql参数 from array
    /// </summary>
    /// <param name="Mode"></param>
    /// <param name="Fields"></param>
    /// <param name="TableName"></param>
    /// <param name="Condition"></param>
    /// <returns></returns>
    public string GetSqlParameters(string Mode, string[] Fields, string TableName, string Condition)
    {
        int C = Fields.Length;
        string FieStr = "";
        string ParStr = "";
        string sql = "";
        switch (Mode)
        {
            case "insert":
                for (int i = 0; i < C; i++)
                {
                    if (i < (C - 1))
                    {
                        FieStr += Fields[i] + ",";
                        ParStr += "@" + Fields[i] + ",";
                    }
                    else
                    {
                        FieStr += Fields[i];
                        ParStr += "@" + Fields[i];
                    }
                }
                sql = string.Format("insert into {0} ({1}) values ({2})", TableName, FieStr, ParStr);
                break;
            case "update":
                for (int i = 0; i < C; i++)
                {
                    if (i < (C - 1))
                    {
                        FieStr += Fields[i] + "=@" + Fields[i] + ",";
                    }
                    else
                    {
                        FieStr += Fields[i] + "=@" + Fields[i];
                    }
                }
                sql = string.Format("update {0} set {1} where {2}", TableName, FieStr, Condition);
                break;
            default:
                break;
        }
        return sql;
    }
    /// 自动整理sql form Hashtamle
    /// <summary>
    /// 自动整理sql form Hashtamle
    /// </summary>
    /// <param name="Mode"></param>
    /// <param name="Fields"></param>
    /// <param name="TableName"></param>
    /// <param name="Condition"></param>
    /// <returns></returns>
    private string GetSqlParameters(string Mode, Hashtable Fields, string TableName, string Condition)
    {
        int C = Fields.Count;
        string FieStr = "";
        string ParStr = "";
        string sql = "";
        int i = 0;
        switch (Mode)
        {
            case "insert":
                foreach (DictionaryEntry De in Fields)
                {
                    if (i < (C - 1))
                    {
                        FieStr += De.Key + ",";
                        ParStr += "@" + De.Key + ",";
                    }
                    else
                    {
                        FieStr += De.Key;
                        ParStr += "@" + De.Key;
                    }
                    i++;
                }
                sql = string.Format("insert into {0} ({1}) values ({2})", TableName, FieStr, ParStr);
                break;
            case "update":
                foreach (DictionaryEntry De in Fields)
                {
                    if (i < (C - 1))
                    {
                        FieStr += De.Key + "=@" + De.Key + ",";
                    }
                    else
                    {
                        FieStr += De.Key + "=@" + De.Key;
                    }
                    i++;
                }
                sql = string.Format("update {0} set {1} where {2}", TableName, FieStr, Condition);
                break;
            default:
                sql = "";
                break;
        }
        return sql;
    }
    #endregion

    #region 语句式分页 组织sql

    #endregion

    #region 其它共用方法 针对项目可更改
    //private StringBuilder IDlist = new StringBuilder();
    /////按fatherid递归得到所有子系id
    ///// <summary>
    ///// 按fatherid递归得到所有子系id 返回如:  1,2,4,-1
    ///// </summary>
    ///// <param name="startid">Father Id</param>
    ///// <param name="includethis">是否包含</param>
    ///// <returns>返回如: 1,2,4,-1 </returns>
    //public string GetSubIDToEnd(string startid, bool includethis)
    //{
    //   IDlist = new StringBuilder();
    //   startid= startid==""?"-1":startid;
    //    Recursion(startid);
    //    if(conn.State==ConnectionState.Open)conn.Close();//如果数据库连接打开状态则关闭
    //    IDlist.Append("-1");
    //    if (includethis)
    //    {
    //        IDlist.Append("," + startid);
    //    }
    //    return IDlist.ToString();
    //}
    /// <summary>
    /// 递归
    /// </summary>
    /// <param name="IDlist"></param>
    /// <param name="startid"></param>
    private void Recursion(string startid)
    {
        try
        {
            string sql = "select id from maintype where fid=" + startid;
            SqlCommand cmd00 = new SqlCommand(sql, conn);
            SqlDataAdapter sda00 = new SqlDataAdapter();
            sda00.SelectCommand = cmd00;
            DataSet ds00 = new DataSet();
            sda00.Fill(ds00);
            foreach (DataRow dr in ds00.Tables[0].Rows)
            {
                IDlist.Append(dr["id"].ToString() + ",");
                Recursion(dr["id"].ToString());
            }
        }
        finally
        { }
    }
    #endregion
    //最后   
}