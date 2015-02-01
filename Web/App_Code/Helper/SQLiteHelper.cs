using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

/// <summary>
///SQLiteHelper 的摘要说明
/// </summary>
public class SQLiteHelper
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    private SQLiteConnection _conn;
    public SQLiteConnection Connection { get { return _conn; } }
    /// <summary>
    /// 初始化Helper
    /// </summary>
    /// <param name="dbPath">数据库文件的完整路径</param>
    /// <param name="pwd">密码</param>
    public SQLiteHelper(string dbPath, string pwd)
    {
        SQLiteConnectionStringBuilder connStrBuilder = new SQLiteConnectionStringBuilder();
        connStrBuilder.DataSource = dbPath;
        connStrBuilder.Password = pwd;
        _conn = new SQLiteConnection(connStrBuilder.ToString());
    }
    /// <summary>
    /// 执行数据库脚本
    /// </summary>
    /// <param name="sqlText"></param>
    public void ExcuteSQLText(string sqlText)
    {
        Connection.Open();
        SQLiteCommand cmd = new SQLiteCommand();
        cmd.CommandText = sqlText;
        cmd.Connection = Connection;
        cmd.ExecuteNonQuery();
        Connection.Clone();
    }
    /// <summary>
    /// 查询数据
    /// </summary>
    /// <param name="sqlText"></param>
    /// <returns></returns>
    public DataSet GetData(string sqlText)
    {
        DataSet ds = new DataSet();
        SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlText, Connection);
        Connection.Open();
        adapter.Fill(ds);
        Connection.Close();
        return ds;
    }
}