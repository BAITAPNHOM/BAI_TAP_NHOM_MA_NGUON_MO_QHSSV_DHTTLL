﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class Dal_Lop:connect
    {
        SqlDataAdapter adap;
        DataTable dt;

        public DataTable LOP()
        {
            adap = new SqlDataAdapter("SELECT * FROM LOP", dbConn);
            dt = new DataTable();
            adap.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable Khoa_DS()
        {
            string cmd = "SELECT * FROM KHOA";
            adap = new SqlDataAdapter(cmd, dbConn);
            dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
 
        public bool  themLop(DTO_Lop pLop)
        {
            dbConn.Open();
            string cmd = "INSERT INTO LOP VALUES(N'" + pLop.MaLop + "',N'" + pLop.TenLop + "',N'" + pLop.MaKhoa + "')";
            SqlCommand sqlCmd = new SqlCommand(cmd, dbConn);
            sqlCmd.ExecuteNonQuery();
            dbConn.Close();
            return true;
        }
        public bool suaLop(DTO_Lop pLop)
        {
            dbConn.Open();
            string cmd = "UPDATE LOP SET TENLOP=N'" + pLop.TenLop + "',MAKHOA='" + pLop.MaKhoa + "' WHERE MALOP='" + pLop.MaLop + "'";
            SqlCommand sqlCmd = new SqlCommand(cmd, dbConn);
            sqlCmd.ExecuteNonQuery();
            dbConn.Close();
            return true;
        }
        public bool xoaLop(String maLop)
        {
            dbConn.Open();
            string cmd = "DELETE FROM LOP WHERE MALOP='" + maLop + "'";
            SqlCommand sqlCmd = new SqlCommand(cmd, dbConn);
            sqlCmd.ExecuteNonQuery();
            dbConn.Close();
            return true;
        }

    }
}
