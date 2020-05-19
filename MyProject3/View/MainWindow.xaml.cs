using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Input;
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace MyProject3.View
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public RhinoDoc doc;
        public int count = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        //選點功能
        ObjRef[] obj_refs;
        Rhino.Geometry.Point point;
        public Result RunCommand(RhinoDoc doc)
        {
            //選擇多點
            var rc = RhinoGet.GetMultipleObjects("Select point", false, ObjectType.Point, out obj_refs);
            if (rc != Result.Success)
                return rc;
            TxtPickRes.Text = "uid,u1,u2,u3\n";
            foreach (var o_ref in obj_refs)
            {
                point = o_ref.Point();
                RhinoApp.WriteLine("Point: x:{0}, y:{1}, z:{2}",
                  point.Location.X,
                  point.Location.Y,
                  point.Location.Z);
                count++;
                TxtPickRes.Text += count + "," +
                                   point.Location.X + "," +
                                   point.Location.Y + "," +
                                   point.Location.Z + ",\n";
            }
            return Result.Success;
        }
        //--------------------------------------
        //↓Button Clik Event 按鈕觸發事件
        //--------------------------------------
        //觸發開啟
        private void BtnImportFile_Click(object sender, RoutedEventArgs e)
        {
            RhinoApp.RunScript("_Open", true);
        }
        //觸發選點
        private void BtnPickMode_Click(object sender, RoutedEventArgs e)
        {
            RunCommand(doc);
        }
        //觸發儲存
        int i = 0;
        string res;
        private void Btn_SaveClick(object sender, RoutedEventArgs e)
        {
            TxtSaveRes.Text = "";
            foreach (var o_ref in obj_refs)
            {
                point = o_ref.Point();
                //RhinoApp.WriteLine("Point: x:{0}, y:{1}, z:{2}",
                //  point.Location.X,
                //  point.Location.Y,
                //  point.Location.Z);
                i++;
                TxtSaveRes.Text += "bc" + i + "," +
                                   point.Location.X + "," +
                                   point.Location.Y + "," +
                                   point.Location.Z + "," + 
                                   TxtU1.Text + "," + 
                                   TxtU2.Text + "," + 
                                   TxtU3.Text + "," +
                                   TxtUR1.Text + "," +
                                   TxtUR2.Text + "," +
                                   TxtUR3.Text + ",\n";
                //重置
                count = 0;
            }
            //重置
            i = 0;
            res += TxtSaveRes.Text + "\n";
            MessageBox.Show("儲存成功","確認",MessageBoxButton.OK,MessageBoxImage.Exclamation);
        }
        //匯出 CSV
        private void BtnSet_Click(object sender, RoutedEventArgs e)
        {
            TxtAllRes.Text = "BC,x,y,z,u1,u2,u3,ur1,ur2,ur3\n"+res;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv file (*.csv)|*.csv|Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TxtAllRes.Text);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
