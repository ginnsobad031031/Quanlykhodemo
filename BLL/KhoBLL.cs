using System;
using System.Collections.Generic;
using QuanlyKhodemo.DAL;
using QuanlyKhodemo.Models;

namespace QuanlyKhodemo.BLL
{
    public class KhoBLL
    {
        public static List<Kho> GetAllKho()
        {
            return KhoDAL.GetAllKho();
        }

        public static Kho GetKhoById(string maKho)
        {
            if (string.IsNullOrEmpty(maKho))
                return null;
            return KhoDAL.GetKhoById(maKho);
        }

        public static bool AddKho(Kho k)
        {
            if (k == null || string.IsNullOrEmpty(k.MaKho) || string.IsNullOrEmpty(k.TenKho))
                return false;
            return KhoDAL.AddKho(k);
        }

        public static bool UpdateKho(Kho k)
        {
            if (k == null || string.IsNullOrEmpty(k.MaKho))
                return false;
            return KhoDAL.UpdateKho(k);
        }

        public static bool DeleteKho(string maKho)
        {
            if (string.IsNullOrEmpty(maKho))
                return false;
            return KhoDAL.DeleteKho(maKho);
        }
    }
}
