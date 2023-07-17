using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinWithPDF
{
    public partial class MainPage : ContentPage
    {
        string filePath;
        public MainPage()
        {
            InitializeComponent();
        }

       async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
      
            try
            {
                string fileName = "mauidotnet.pdf";

                filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fileName);

                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph header = new Paragraph("MAUI PDF Sample")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(20);

                document.Add(header);
                Paragraph subheader = new Paragraph("Welcome to .NET Multi-platform App UI")
                   .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                   .SetFontSize(15);
                document.Add(subheader);
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);


                Paragraph footer = new Paragraph("Created By \nUmesh")
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                  .SetFontColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                  .SetFontSize(14);

                document.Add(footer);
                document.Close();

                await OnExternarlBrowser();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        async Task OnExternarlBrowser()
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    await DisplayAlert("Alert", "File is exist!!, Please Genarate PDF", "OK");
                    return;
                }
                await Launcher.OpenAsync(new OpenFileRequest
                {
                    File = new ReadOnlyFile(filePath)
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}

