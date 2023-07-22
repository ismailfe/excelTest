using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ExcelDataReader;
using System.Diagnostics;
using System.Data.OleDb;
using System.Net;
using System.Net.NetworkInformation;

namespace Excel_Deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void B_Oku_Click(object sender, EventArgs e)
        {
            EXCEL_READ(DGV_Excel1, TB_Kaynak_Path.Text);
        }
        
        void ExcelOku()
        {
         //   Excel.Application xlOrn = new Microsoft.Office.Interop.Excel.Application();

         //   if (xlOrn == null)
         //   {
         //       MessageBox.Show("Excel yüklü değil!!");
         //       return;
         //   }

         //   Excel.Application xlApp;
         //   Excel.Workbook xlWorkBook;
         //   Excel.Worksheet xlWorkSheet;
         //   object misValue = System.Reflection.Missing.Value;

         //   xlApp = new Excel.Application();
         //   xlWorkBook = xlApp.Workbooks.Open("c:\\ab.csv", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
         //   xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);// .get_Item(1);

         //textBox1.Text = xlWorkSheet.get_Range("A2", "A2").Value2.ToString();

         //   xlWorkBook.Close(true, misValue, misValue);
         //   xlApp.Quit();

         ////   MessageBox.Show("Excel dosyası c:\\yazilimbilisim.xls komununda oluşturuldu!");

        }

        ///// <summary>
        ///// Required designer variable.
        ///// </summary>
        //private System.ComponentModel.IContainer components = null;
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}



        private static IList<string> GetTablenames(DataTableCollection tables)
        {
            var tableList = new List<string>();
            foreach (var table in tables)
            {
                tableList.Add(table.ToString());
            }

            return tableList;
        }

        DataSet ds = new DataSet();

        void EXCEL_READ(DataGridView DGV, string FilePath)
        {
            string FileExtensionSelect = "";
            string FilePath_OK = "";
            var file = new FileInfo(FilePath);

                   if (file.Extension == ".xls")
                    {
                    FileExtensionSelect = ".xls";
                    FilePath_OK = FilePath;
                    }
                    else if (file.Extension == ".xlsx")
                    {
                    FileExtensionSelect = ".xls";
                    FilePath_OK = FilePath;
                    }
                    else if (file.Extension == ".CSV" || file.Extension == ".csv")
                    {
                    FileExtensionSelect = ".xls";
                    FilePath_OK = "c:\\a.xls";

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(FilePath, 0, true, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlApp.DisplayAlerts = false;
                    xlWorkBook.SaveAs("C:\\a", Excel.XlFileFormat.xlWorkbookNormal);

                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    }

                using (var stream = new FileStream(FilePath_OK, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    IExcelDataReader reader = null;
                if (FileExtensionSelect == ".xls")
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (FileExtensionSelect == ".xlsx")
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }


                if (reader == null)
                        return;

   
                    var sw = new Stopwatch();
                    sw.Start();
                    ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = checkBox1.Checked
                        }
                    });

                    label4.Text = "Elapsed: " + sw.ElapsedMilliseconds.ToString() + " ms";

                    var tablenames = GetTablenames(ds.Tables);
                    comboBox1.DataSource = tablenames;

                    if (tablenames.Count > 0)
                    comboBox1.SelectedIndex = 0;
                }

            SelectTable();

        }
        void ExcelFilesOku(string ExcelFile_Path)
        {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(ExcelFile_Path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //   MessageBox.Show(xlWorkSheet.get_Range("A1", "A1").Value2.ToString());

            xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

        }
          private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        void ExcelFileOku2(DataGridView DGV, string ExcelFile_Path)
        {

            String name = "Items";
            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            ExcelFile_Path +
                            ";Extended Properties='Excel 8.0;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);
            DGV.DataSource = data;
        }

        void csvOku(DataGridView DGV, string file_Path)
        {
            //  get all lines of csv file
            string[] str = File.ReadAllLines(file_Path, Encoding.ASCII);

            // create new datatable
            DataTable dt = new DataTable();
            // get the column header means first line
            string[] temp = str[0].Split(';');
            // creates columns of gridview as per the header name
            foreach (string t in temp)
            {
                dt.Columns.Add(t, typeof(string));
            }
            // now retrive the record from second line and add it to datatable
            for (int i = 1; i < str.Length; i++)
            {
                string[] t = str[i].Trim().Split(';');
                dt.Rows.Add(t);

            }
            // assign gridview datasource property by datatable
            DGV.DataSource = dt;
            // bind the gridview
         //   DGV.DataBind();
        }
        private void SelectTable()
        {
            var tablename = comboBox1.SelectedItem.ToString();

            DGV_Excel1.AutoGenerateColumns = true;
            DGV_Excel1.DataSource = ds; // dataset
            DGV_Excel1.DataMember = tablename;
            //  DGV_Excel1.Columns[2].ValueType = typeof(DateTime);
            DGV_Excel1.Columns[0].DefaultCellStyle.Format = string.Format("");
            DGV_Excel1.Columns[1].DefaultCellStyle.Format = string.Format("");
            DGV_Excel1.Columns[2].DefaultCellStyle.Format = string.Format("");
            DGV_Excel1.Columns[3].DefaultCellStyle.Format = string.Format("");
            DGV_Excel1.Columns[4].DefaultCellStyle.Format = string.Format("");
            DGV_Excel1.Columns[5].DefaultCellStyle.Format = string.Format("");  //"dd.MM.yyyy"; //string.Format("");
            DGV_Excel1.Columns[5].DefaultCellStyle.Format = "dd.MM.yyyy"; // HH:mm:ss";  //string.Format("");
            DGV_Excel1.Columns[6].DefaultCellStyle.Format = "MM.dd.yyyy HH:mm:ss";
            DGV_Excel1.Columns[7].DefaultCellStyle.Format = string.Format("");
            DGV_Excel1.Columns[8].DefaultCellStyle.Format = string.Format("");
            // GetValues(ds, tablename);
        }
        void CSVOkuWithExcel(DataGridView DGV, string ExcelFile_Path)
        {

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(ExcelFile_Path, 0, true, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            
            xlWorkBook.SaveAs("C:\\a", Excel.XlFileFormat.xlWorkbookNormal);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);




        }


        private void B_KaynakYolu_Click(object sender, EventArgs e)
        {
            // FolderBrowserDialog MyFolder = new FolderBrowserDialog();
            OpenFileDialog MyFile = new OpenFileDialog();
            
            if (MyFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TB_Kaynak_Path.Text = MyFile.FileName;
            }
        }

        DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = DGV_Excel1.Columns[5].DefaultCellStyle.Format.ToString();
            //    DGV_Filter_WtihStr(DGV_Excel1, DGV_SearchResult, DGV_Excel1.Columns[4].HeaderText.ToString().Trim(), textBox1.Text);

   
            DGV_Filter_WithDate(DGV_Excel1, DGV_SearchResult, DGV_Excel1.Columns[5].HeaderText.ToString().Trim(), dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            //string[] ColumnHeader = new string[2];
            //string[] SearchValue1 = new string[2];
            //string[] SearchValue2 = new string[2];

            //ColumnHeader[0] = DGV_Excel1.Columns[5].HeaderText.ToString(); // Kolon Tarih
            //ColumnHeader[1] = DGV_Excel1.Columns[6].HeaderText.ToString(); // Kolon Zaman

            //SearchValue1[0] = dateTimePicker1.Value.ToString(); // İlk Tarih
            //SearchValue2[0] = dateTimePicker2.Value.ToString(); // İkinci Tarih

            //SearchValue1[1] = textBox4.Text; // İlk Zaman
            //SearchValue2[1] = textBox5.Text; // İkinci Zaman DGV_SearchResult

            //EXCEL_READ(DGV_Excel1, TB_Kaynak_Path.Text);
            //DGV_Filter_WithTime(DGV_Excel1, DGV_Excel1, ColumnHeader, SearchValue1, SearchValue2, "12.31.1899", true);

            Filtrele();
        }

        void Filtrele()
        {
            string Status;
            string[] ColumnHeader   = new string[5];
            string[] SearchValue    = new string[5];
            bool[] SearchLikeMod = new bool[5];


            ColumnHeader[0] = DGV_Excel1.Columns[5].HeaderText.ToString(); // Kolon Tarih
            ColumnHeader[1] = DGV_Excel1.Columns[6].HeaderText.ToString(); // Kolon Zaman
            ColumnHeader[2] = DGV_Excel1.Columns[5].HeaderText.ToString(); // Kolon Tarih
            ColumnHeader[3] = DGV_Excel1.Columns[6].HeaderText.ToString(); // Kolon Zaman
            ColumnHeader[4] = DGV_Excel1.Columns[2].HeaderText.ToString(); // Kolon Ürün Adı

            SearchValue[0] = dateTimePicker1.Value.ToString(); // İlk Tarih
            SearchValue[1] = dateTimePicker2.Value.ToString(); // İkinci Tarih
            SearchValue[2] = textBox4.Text; // İlk Zaman
            SearchValue[3] = textBox5.Text; // İkinci Zaman DGV_SearchResult
            SearchValue[4] = textBox8.Text; // Ürün Adı

            SearchLikeMod[0] = true;
            SearchLikeMod[1] = true;
            SearchLikeMod[2] = true;
            SearchLikeMod[3] = true;
            SearchLikeMod[4] = true;

            DGV_Filter(DGV_Excel1, DGV_SearchResult, ColumnHeader, SearchValue, SearchLikeMod, "12.31.1899", true, out Status);
            TB_Status.Text = Status;
        }




        void DGV_Filter_WtihStr(DataGridView DGV_Main, DataGridView DGV_Result, string SearchColumnName, string SearchText)
        {
            try
            {
                //DGV_Excel1.Columns[4].HeaderText.ToString().Trim()

                DataView dv = (DGV_Main.DataSource as DataSet).Tables[0].DefaultView;  // ds.Tables[0].DefaultView;
                dv.RowFilter = "Convert([" + SearchColumnName + "], 'System.String')" + " Like '" + SearchText + "%'";
                DGV_Result.DataSource = dv;

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.ToString());
            }

        }

        void DGV_Filter_WithDate(DataGridView DGV_Main, DataGridView DGV_Result, string DateColumnName,  string Date1, string Date2)
        {
            try
            {
                DataView dv;
                DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);

                DateTime myDate1 = DateTime.ParseExact(Date1 , "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 1.Tarih:  21.12.2017
                DateTime myDate2 = DateTime.ParseExact(Date2 , "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 2.Tarih:  24.12.2017

                dv = (DGV_Main.DataSource as DataSet).Tables[0].DefaultView;  // ds.Tables[0].DefaultView;
              
                dv.RowFilter ="([" + DateColumnName + "] " + ">= #" + myDate1.Date + "# And " +
                               "[" + DateColumnName + "] " + "<= #" + myDate2.Date + "# ) ";

                DGV_Result.DataSource = dv;
                (DGV_Result.DataSource as DataSet).Tables[0].AcceptChanges();
            
                DGV_SearchResult.Columns[6].DefaultCellStyle.Format = "HH:mm:ss";
               
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.ToString());
            }

        }

        void DGV_Filter_WithTime(DataGridView DGV_Main, DataGridView DGV_Result, string[] SearchColumnName, string[] SearchValue1, string[] SearchValue2 , string TimeicinBosTarih, bool fistSecondValue_DateTime)
        {
            try
            {

                // Date Value
                string D1 = SearchValue1[0];
                string D2 = SearchValue2[0];
                // Time Value
                string T1 = TimeicinBosTarih + " " + SearchValue1[1];
                string T2 = TimeicinBosTarih + " " + SearchValue2[1];

                int ColumnLength = SearchColumnName.Length;
                string[] ColumnName = new string[ColumnLength];


                for (int i = 0; i < ColumnLength; i++)
                {

                    for (int j = 0; j < SearchColumnName[i].Length; j++)
                    {
                        if (SearchColumnName[i].Substring(j, 1) == " ")
                        {
                            ColumnName[i] = "[" + SearchColumnName[i] + "]";
                            j = SearchColumnName[i].Length;
                        }
                        else
                        {
                            ColumnName[i] = SearchColumnName[i];
                        }
                    }
                    
                }

                DataView dv = (DGV_Main.DataSource as DataSet).Tables[0].DefaultView;
                string FilterDate = "";
                string FilterTime = "";


                if (fistSecondValue_DateTime)
                {
                    DateTime myDate1 = DateTime.ParseExact(D1, "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 1.Tarih:  21.12.2017
                    DateTime myDate2 = DateTime.ParseExact(D2, "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 2.Tarih:  24.12.2017

                    // DateTime myTime1 = DateTime.Parse(T1);
                    // DateTime myTime2 = DateTime.Parse(T2);

                    //   DateTime myTime1 = DateTime.ParseExact(T1, "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 1.Tarih:  21.12.2017
                    //   DateTime myTime2 = DateTime.ParseExact(T2, "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 2.Tarih:  24.12.2017

                    FilterDate = "(" + ColumnName[0] + " >= #" + myDate1.Date + "# And " +
                                       ColumnName[0] + " <= #" + myDate2.Date + "# ) ";

                    FilterTime = "(" + "CONVERT(" + ColumnName[1] + ",System.DateTime)" + " >= #" + T1 + "#  And " +
                                       "CONVERT(" + ColumnName[1] + ",System.DateTime)" + " <= #" + T2 + "# ) ";

                    textBox7.Text = T1;
                    textBox6.Text = DGV_Excel1.Rows[2].Cells[6].Value.ToString();
                }
             
             
                dv.RowFilter = FilterDate + " and " + FilterTime;
                DGV_Result.DataSource = dv;
                DGV_Result.Columns[6].DefaultCellStyle.Format = "HH:mm:ss";
           
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.ToString());
            }

        }




        void DGV_Filter(DataGridView DGV_Main, DataGridView DGV_Result, string[] SearchColumnName, string[] SearchValue, bool[] SearchLikeMod, string TimeicinOffSetTarih, bool DateTimeSearchENB, out string Status)
        {
            Status = "";

            try
            {
                //  SearchValue[0] = min Date
                //  SearchValue[1] = Max Date
                //  SearchValue[2] = min Time
                //  SearchValue[3] = Max Time

                // Date Value
                string D1 = SearchValue[0];
                string D2 = SearchValue[1];
                // Time Value
                string T1 = TimeicinOffSetTarih + " " + SearchValue[2]; // Time bölümünden önce standart olarak "01.01.1999" gibi bir tarih çıktığı için offset tarih gereklidir.
                string T2 = TimeicinOffSetTarih + " " + SearchValue[3]; // Time bölümünden önce standart olarak "01.01.1999" gibi bir tarih çıktığı için offset tarih gereklidir.
                DataView dv = (DGV_Main.DataSource as DataSet).Tables[0].DefaultView;
                string FilterDate = "";
                string FilterTime = "";
                string FilterDateTime = "";

                string Temp_FilterText = "";
                string FilterText = "";

                int ColumnLength = SearchColumnName.Length;
                string[] ColumnName = new string[ColumnLength];
                for (int i = 0; i < ColumnLength; i++)
                {

                    for (int j = 0; j < SearchColumnName[i].Length; j++)
                    {
                        if (SearchColumnName[i].Substring(j, 1) == " ")
                        {
                            ColumnName[i] = "[" + SearchColumnName[i] + "]";
                            j = SearchColumnName[i].Length;
                        }
                        else
                        {
                            ColumnName[i] = SearchColumnName[i];
                        }
                    }

                }

                if (DateTimeSearchENB)
                {
                    DateTime myDate1 = DateTime.ParseExact(D1, "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 1.Tarih:  21.12.2017
                    DateTime myDate2 = DateTime.ParseExact(D2, "MM.dd.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); // 2.Tarih:  24.12.2017


                    FilterDate = "(" + ColumnName[0] + " >= #" + myDate1.ToShortDateString() + "# And " + ColumnName[0] + " <= #" + myDate2.ToShortDateString() + "# ) ";

                    FilterTime = "(" + "CONVERT(" + ColumnName[1] + ",System.DateTime)" + " >= #" + T1 + "#  And " +
                                       "CONVERT(" + ColumnName[1] + ",System.DateTime)" + " <= #" + T2 + "# ) ";

                    FilterDateTime = FilterDate + " and " + FilterTime;

                    if (SearchValue.Length > 4)
                    {
                        for (int i = 4; i < SearchValue.Length; i++)
                        {
                            if (SearchLikeMod[i])
                            { 
                                if (Temp_FilterText == "")
                                {
                                    Temp_FilterText = Temp_FilterText + "( " + ColumnName[i] + " LIKE '%" + SearchValue[i] + "%'" + " )";
                                }else
                                {
                                    Temp_FilterText = Temp_FilterText + " and " + "( " + ColumnName[i] + " LIKE '%" + SearchValue[i] + "%'" + " )";
                                }
                            }else
                            {
                                if (Temp_FilterText == "")
                                {
                                    Temp_FilterText = Temp_FilterText + "( " + ColumnName[i] + " = " + SearchValue[i]  + " )";
                                }
                                else
                                {
                                    Temp_FilterText = Temp_FilterText + " and " + "( " + ColumnName[i] + " = " + SearchValue[i] + " )";
                                }
                                
                            }
                        }

                        FilterText = FilterDateTime + " and " + Temp_FilterText;
                    }
                    else
                    {

                        FilterText = FilterDateTime;
                    }


                    dv.RowFilter = FilterText;
                    DGV_Result.DataSource = dv;
                    Status = "Data filtreleme işlemi tamamlandı[0].";

                }
                else
                {
                    for (int i = 0; i < SearchValue.Length; i++)
                    {
                        if (SearchLikeMod[i])
                        {
                            if (Temp_FilterText == "")
                            {
                                Temp_FilterText = Temp_FilterText + "( " + ColumnName[i] + " LIKE '%" + SearchValue[i] + "%'" + " )";
                            }
                            else
                            {
                                Temp_FilterText = Temp_FilterText + " and " + "( " + ColumnName[i] + " LIKE '%" + SearchValue[i] + "%'" + " )";
                            }
                        }
                        else
                        {
                            if (Temp_FilterText == "")
                            {
                                Temp_FilterText = Temp_FilterText + "( " + ColumnName[i] + " = " + SearchValue[i] + " )";
                            }
                            else
                            {
                                Temp_FilterText = Temp_FilterText + " and " + "( " + ColumnName[i] + " = " + SearchValue[i] + " )";
                            }

                        }
                    }

                    FilterText = Temp_FilterText;

                    dv.RowFilter = FilterText;
                    DGV_Result.DataSource = dv;
                    Status = "Data filtreleme işlemi tamamlandı[1].";


                }


            }



            catch (Exception Hata)
            {

                Status = "Data Filtreleme Hata :" + Hata.ToString();
            }


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy hh:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy hh:mm:ss";

            EXCEL_READ(DGV_Excel1, TB_Kaynak_Path.Text);
        }

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
          
            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }

        void IPGet()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in interfaces)
            {
                Console.WriteLine("Name: {0}", adapter.Name);
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Operational status ...................... : {0}",
                    adapter.OperationalStatus);
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                Console.WriteLine("  IP version .............................. : {0}", versions);
                Console.WriteLine();
            }
            Console.WriteLine();


        }

  
    }
}
