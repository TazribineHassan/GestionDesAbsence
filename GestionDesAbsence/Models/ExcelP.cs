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
    public class ExcelP
    {
        public static DataTable Importing(DataTable dt, XSSFWorkbook workbook, GestionDesAbsenceContext db)
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
                    Professeur p = new Professeur();
                    p.Nom = dt.Rows[i]["Nom"].ToString();
                    p.Prenom = dt.Rows[i]["Prenom"].ToString();
                    p.Email = dt.Rows[i]["Email"].ToString();
                    p.Password = Common.Encryption.Encrypt(dt.Rows[i]["Nom"].ToString());
                    p.Role_Id = 2;

                    var flag = db.Professeurs.Where(x => x.Nom == p.Nom).FirstOrDefault();
                    if (flag != null && flag.Nom != p.Nom)
                    {
                        flag.Nom = p.Nom;
                        db.Professeurs.Add(flag);
                    }
                    if (flag != null)
                    {
                        db.Professeurs.Add(flag);
                    }
                    else
                    {
                        db.Professeurs.Add(p);
                    }
                }
            }
            db.SaveChanges();
            return dt;
        }

        public static DataTable Importing(DataTable dt, HSSFWorkbook workbook, GestionDesAbsenceContext db)
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
                    Professeur p = new Professeur();
                    p.Nom = dt.Rows[i]["Nom"].ToString();
                    p.Prenom = dt.Rows[i]["Prenom"].ToString();
                    p.Email = dt.Rows[i]["Email"].ToString();
                    p.Password = Common.Encryption.Encrypt(dt.Rows[i]["Nom"].ToString());
                    p.Role_Id = 2;


                    var flag = db.Professeurs.Where(x => x.Nom == p.Nom).FirstOrDefault();
                    if (flag != null && flag.Nom != p.Nom)
                    {
                        flag.Nom = p.Nom;
                        db.Professeurs.Add(flag);
                    }
                    if (flag != null)
                    {
                        db.Professeurs.Add(flag);
                    }
                    else
                    {
                        db.Professeurs.Add(p);
                    }
                }
            }
            db.SaveChanges();
            return dt;
        }
    }
}