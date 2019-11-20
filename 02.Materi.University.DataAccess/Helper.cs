using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Materi.University.DataAccess
{
    public class Helper
    {
        public static string GetMessageErrorEF(DbEntityValidationException dbEx)
        {
            List<string> listError = new List<string>();
            if (dbEx.EntityValidationErrors.Count() > 0)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        listError.Add(validationError.ErrorMessage);
                    }
                }
            }

            return string.Join(" ", listError);
        }
    }
}
