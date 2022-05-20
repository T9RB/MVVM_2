using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Ookii.Dialogs.Wpf;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ClosedXML;
using ClosedXML.Excel;
using WpfApp2;

namespace MVVM_WPF
{
    public class VM_Profile_User : VM_Super
    {
        private RelayCommand _report;
        public VM_Profile_User()
        {
            FName = Service.user.FName;
            SName = Service.user.SName;
            LName = Service.user.LName;
            NumberPhone = Service.user.NumberPhone;
        }
        public string FName { get; set; }
        public string SName { get; set; }
        public string LName { get; set; }
        public string NumberPhone { get; set; }

        public RelayCommand Report => _report ??
                                      (_report = new RelayCommand((x) =>
                                      {
                                          if (MessageBox.Show("Если хотите отчет PDF, нажмите да, если EXCEL, то нет.",
                                                  "Save file",
                                                  MessageBoxButton.YesNo,
                                                  MessageBoxImage.Question) == MessageBoxResult.Yes)
                                          {
                                              int height = 50;
                                              int width = 0;
                                              PdfDocument _pdf = new();
                                              PdfPage Page = _pdf.AddPage();
                                              XGraphics xgrap = XGraphics.FromPdfPage(Page);
                                              XFont FontPdf = new XFont("Calibri", 14);
                                              ObservableCollection<WpfApp2.Task> tasks = new(Service.db.Tasks.Include(x => x.Status).Where(x => x.CreatorId == Service.user.Userid && x.AcceptorId == Service.user.Userid));
                                              xgrap.DrawString("Отчет по проделанной работе: ".ToString(), FontPdf, XBrushes.Black, new XRect(width, height, 0, 0));
                                              width = 0;
                                              height += 15;
                                              foreach (var item in tasks)
                                              {
                                                  xgrap.DrawString("Имя задачи: " + item.NameTask.ToString(), FontPdf, XBrushes.Black, new XRect(width, height, 0, 0));
                                                  width = 0;
                                                  height += 15;
                                                  xgrap.DrawString("Описание задачи: " + item.DescriptionTask.ToString(), FontPdf, XBrushes.Black, new XRect(width, height, 0, 0));
                                                  width = 0;
                                                  height += 15;
                                                  xgrap.DrawString("Дата: " + item.DatePub.ToString(), FontPdf, XBrushes.Black, new XRect(width, height, 0, 0));
                                                  width = 0;
                                                  height += 15;
                                                  xgrap.DrawString("Статус: " + item.Status.NameStatus.ToString(), FontPdf, XBrushes.Black, new XRect(width, height, 0, 0));
                                                  width = 0;
                                                  height += 15;
                                              }
                                              VistaFolderBrowserDialog vfb = new VistaFolderBrowserDialog();
                                              vfb.ShowNewFolderButton = true;
                                              string path = null;
                                              if (vfb.ShowDialog() == true)
                                              {
                                                  path = vfb.SelectedPath;
                                              }
                                              if (path != null)
                                              {
                                                  string filename = path + "" + "Otchet.pdf";
                                                  _pdf.Save(filename);
                                              }
                                          }
                                          else
                                          {
                                              XLWorkbook wb = new();
                                              string filename = "Otchet".ToString();
                                              IXLWorksheet? ws = wb.Worksheets.Add("Otchet");

                                              string path = null;
                                              VistaFolderBrowserDialog vfb = new VistaFolderBrowserDialog();
                                              vfb.ShowNewFolderButton = true;
                                              
                                              if (vfb.ShowDialog() == true)
                                              {
                                                  path = vfb.SelectedPath;
                                              }
                                              if (path != null)
                                              {
                                                  wb.SaveAs($"{path}//{filename}.xlsx");
                                              }
                                              
                                          }
                                          


                                      }));
    }
}
