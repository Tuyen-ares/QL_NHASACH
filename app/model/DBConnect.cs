using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.model
{
    public class DBConnect
    {
        public string strConnect = @"Data Source=DESKTOP-C4ALSJO\SQLEXPRESS; Initial Catalog=QL_NHASACH;Integrated Security=True";
        public SqlConnection conn;

        public DBConnect()
        {
            conn = new SqlConnection(strConnect);
        }

        public DBConnect(string strConnection)
        {
            this.strConnect = strConnection;
            conn = new SqlConnection(this.strConnect);
        }


        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        //Dùng getNonQuery cho các câu lệnh không trả về dữ liệu(INSERT, UPDATE, DELETE).
        public int getNonQuery(string chuoiKN)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoiKN, conn);
            int kq = cmd.ExecuteNonQuery();
            Close();
            return kq;
        }

        //Dùng getScalar để lấy một giá trị duy nhất.
        public object getScalar(string chuoiKN)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoiKN, conn);
            object kq = cmd.ExecuteScalar();
            Close();
            return kq;

        }



        //Dùng getDataTable để lấy dữ liệu dưới dạng bảng.
        public DataTable getDataTable(string chuoiKN)
        {
            SqlDataAdapter da = new SqlDataAdapter(chuoiKN, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        //Dùng getReader để đọc dữ liệu tuần tự (hiệu quả về bộ nhớ).
        public SqlDataReader getReader(string chuoiKN)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoiKN, conn);
            SqlDataReader reder = cmd.ExecuteReader();
            return reder;
        }


        //Dùng updateDataTable để lưu lại các thay đổi từ DataTable vào cơ sở dữ liệu.
        public int updateDataTable(DataTable dtnew, string chuoiKN)
        {
            SqlDataAdapter da = new SqlDataAdapter(chuoiKN, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dtnew); // lưu csdl
            return kq;
        }

        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(strConnect);
            connection.Open(); // Mở kết nối
            return connection;
        }
    }
}
