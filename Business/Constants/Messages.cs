using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        private static string departmentAdded = "Departman başarılı bir şekilde eklendi.";
        private static string departmentIdInvalid = "Departman ID geçersiz.";
        private static string departmentIdNotFound = "Departman ID bulunamadı.";
        private static string departmentDeleted = "Departman başarılı bir şekilde silindi.";
        private static string departmentUpdated = "Departman başarılı bir şekilde güncellendi.";
        private static string departmentsListed = "Departmanlar başarılı bir şekilde listelendi";
        private static string departmentListed = "Departman başarılı bir şekilde listelendi";
        private static string departmentPersonnelListedSuccessfully = "Departmanda çalışan personeller başarılı bir şekilde listelendi.";

        public static string DepartmentAdded
        {
            get { return departmentAdded; }
        }

        public static string DepartmentIdInvalid
        {
            get { return departmentIdInvalid; }
        }

        public static string DepartmentIdNotFound
        {
            get { return departmentIdNotFound; }
        }

        public static string DepartmentDeleted
        {
            get { return departmentDeleted; }
        }

        public static string DepartmentUpdated
        {
            get { return departmentUpdated; }
        }

        public static string DepartmentsListed
        {
            get { return departmentsListed; }
        }

        public static string DepartmentListed
        {
            get { return departmentListed; }
        }

        public static string DepartmentPersonnelListedSuccessfully
        {
            get { return departmentPersonnelListedSuccessfully; }
        }
    }

}
