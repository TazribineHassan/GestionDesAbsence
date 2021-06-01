using Lucene.Net.Support;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GestionDesAbsence.Models
{
    public class excel
    {
        public static DataTable Import(DataTable dt, XSSFWorkbook workbook, GestionDesAbsenceContext db, int myclass)
        {
            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                dt.Columns.Add(sheet.GetRow(0).Cells[j].ToString());
            }
            while (rows.MoveNext())
            {
                XSSFRow row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            dt.Rows.RemoveAt(0);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Etudiant b = new Etudiant();
                    b.Cne = dt.Rows[i]["Cne"].ToString();
                    b.Nom = dt.Rows[i]["Nom"].ToString();
                    b.Prenom = dt.Rows[i]["Prenom"].ToString();
                    b.Email = dt.Rows[i]["Email"].ToString();
                    b.Password = Common.Encryption.Encrypt(dt.Rows[i]["Cne"].ToString());
                    b.Role_Id = 3;
                    b.Id_classe = myclass;
                    b.Id_groupe = Convert.ToInt32(dt.Rows[i]["groupe"]);

                    var flag = db.Etudiants.Where(x => x.Cne == b.Cne).FirstOrDefault();
                    if (flag != null && flag.Cne != b.Cne)
                    {
                        flag.Cne = b.Cne;
                        db.Etudiants.Add(flag);
                    }
                    if (flag != null)
                    {
                        db.Etudiants.Add(flag);
                    }
                    else
                    {
                        db.Etudiants.Add(b);
                    }
                }
            }
            db.SaveChanges();
            return dt;
        }
        public static DataTable Import(DataTable dt, HSSFWorkbook workbook, GestionDesAbsenceContext db, int myclass)
        {
            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                dt.Columns.Add(sheet.GetRow(0).Cells[j].ToString());
            }
            while (rows.MoveNext())
            {
                HSSFRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            dt.Rows.RemoveAt(0);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Etudiant b = new Etudiant();
                    b.Cne = dt.Rows[i]["Cne"].ToString();
                    b.Nom = dt.Rows[i]["Nom"].ToString();
                    b.Prenom = dt.Rows[i]["Prenom"].ToString();
                    b.Email = dt.Rows[i]["Email"].ToString();
                    b.Password = Common.Encryption.Encrypt(dt.Rows[i]["Cne"].ToString());
                    b.Role_Id = 3;
                    b.Id_classe = myclass;
                    b.Id_groupe = Convert.ToInt32(dt.Rows[i]["groupe"]);


                    var flag = db.Etudiants.Where(x => x.Cne == b.Cne).FirstOrDefault();
                    if (flag != null && flag.Cne != b.Cne)
                    {
                        flag.Cne = b.Cne;
                        db.Etudiants.Add(flag);
                    }
                    if (flag != null)
                    {
                        db.Etudiants.Add(flag);
                    }
                    else
                    {
                        db.Etudiants.Add(b);
                    }
                }
            }
            db.SaveChanges();
            return dt;
        }

        
    }
}