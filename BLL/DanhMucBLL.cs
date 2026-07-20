using System;
using System.Collections.Generic;
using QuanlyKhodemo.DAL;
using QuanlyKhodemo.Models;

namespace QuanlyKhodemo.BLL
{
    public class DanhMucBLL
    {
        public static List<DanhMuc> GetAllDanhMuc()
        {
            return DanhMucDAL.GetAllDanhMuc();
        }

        public static DanhMuc GetDanhMucById(string maDanhMuc)
        {
            if (string.IsNullOrEmpty(maDanhMuc))
                return null;
            return DanhMucDAL.GetDanhMucById(maDanhMuc);
        }

        public static bool AddDanhMuc(DanhMuc dm)
        {
            if (dm == null || string.IsNullOrEmpty(dm.MaDanhMuc) || string.IsNullOrEmpty(dm.TenDanhMuc))
                return false;
            return DanhMucDAL.AddDanhMuc(dm);
        }

        public static bool UpdateDanhMuc(DanhMuc dm)
        {
            if (dm == null || string.IsNullOrEmpty(dm.MaDanhMuc))
                return false;
            return DanhMucDAL.UpdateDanhMuc(dm);
        }

        public static bool DeleteDanhMuc(string maDanhMuc)
        {
            if (string.IsNullOrEmpty(maDanhMuc))
                return false;
            return DanhMucDAL.DeleteDanhMuc(maDanhMuc);
        }
    }
}
