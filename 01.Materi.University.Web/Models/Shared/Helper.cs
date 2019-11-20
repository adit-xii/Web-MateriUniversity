using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;

namespace _01.Materi.University.Web.Models.Shared
{
    public class Helper
    {
        public static string Message = string.Empty;
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

        public static List<Files> FnFileUploadMultiple(HttpFileCollectionBase paramFile, string paramBrowser, string paramDirectory)
        {
            List<Files> dataFile = new List<Files>();

            #region '   File Upload   '
            try
            {
                for (int i = 0; i < paramFile.Count; i++)
                {
                    HttpPostedFileBase vFile = paramFile[i];
                    string vFileServerPath;
                    Files addFile = new Files();

                    // Checking for Internet Explorer
                    if (paramBrowser == "IE" || paramBrowser == "INTERNETEXPLORER")
                    {
                        string[] testfiles = vFile.FileName.Split(new char[] { '\\' });
                        //fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        addFile = new Files
                        {
                            FileName = vFile.FileName,
                            FilePath = paramDirectory + vFile.FileName,
                            FileType = vFile.ContentType,
                            FileExtention = Path.GetExtension(vFile.FileName),
                            FileSize = vFile.ContentLength,
                            FileContent = vFile.InputStream
                        };
                    }
                    // Get the complete folder path and store the file inside it.
                    vFileServerPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"), vFile.FileName);
                    vFile.SaveAs(vFileServerPath);
                    dataFile.Add(addFile);
                }
            }
            catch (Exception ex)
            {
                Message = "Error occurred. Error details: " + ex.Message;
            }

            #endregion

            return dataFile;
        }
        public static bool FnFileUploadDelete(List<Files> paramFiles)
        {
            bool result = true;

            if (paramFiles.Count > 0)
            {
                for (int i = 0; i < paramFiles.Count; i++)
                {
                    string vServerPathPyhsical = System.Web.HttpContext.Current.Server.MapPath(paramFiles[i].FilePath);
                    if (!FnFileDelete(vServerPathPyhsical))
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public static bool FnFileDelete(string paramFilePath)
        {
            try
            {
                string vServerPathPyhsical = System.Web.HttpContext.Current.Server.MapPath(paramFilePath);
                if (File.Exists(vServerPathPyhsical))
                {
                    File.Delete(vServerPathPyhsical);
                }
                return true;
            }
            catch (Exception hasError)
            {
                Message = hasError.Message;
                return false;
            }
        }
    }

    public class Files
    {
        public string FileName { get; set; }
        public string FileNameOld { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileExtention { get; set; }
        public int FileSize { get; set; }
        public Stream FileContent { get; set; }
    }
}