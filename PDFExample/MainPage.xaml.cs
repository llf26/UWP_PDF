using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PDFExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Object customerData = new {
            name = "Larry Fritz",
            balance = 2.50,
            address = "123 East Exchange"
        };

        private string testPath = @"C:\Users\lfrit\Documents";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            writePDF(customerData);
        }

        private async void writePDF(Object custData)
        {
            var jsonString = JsonConvert.SerializeObject(custData);

            string pdfresult = await MainWebView.InvokeScriptAsync("print", new string[] { jsonString });
            var savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add("PDF", new List<string> { ".pdf" });
            savePicker.SuggestedFileName = "New Document";
            StorageFile file = await savePicker.PickSaveFileAsync();

            try
            {
                await FileIO.WriteTextAsync(file, pdfresult);
            }
            catch(NullReferenceException e)
            {
                //If they cancel the file operation... we don't care!
            }
        }
    }
}
