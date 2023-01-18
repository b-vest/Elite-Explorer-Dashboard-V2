using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    public class Screenshot
    {
        public void process(string line)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
            ScreenshotObject edObject = JsonSerializer.Deserialize<ScreenshotObject>(line);
            //Split filename out of path
            string[] fileNameString = edObject.Filename.Split('\\');
            //Build full path from settings
            var fullSourcePath = Properties.Settings.Default.ScreenShotSourcePath + "\\" + fileNameString[fileNameString.Length - 1];
            var sourceFileParts = fileNameString[2].Split('.');
            if (edObject.Body == null)
            {
                edObject.Body = "None";
            }
            string fixedBody = edObject.Body.Replace(' ', '_');
            string fixedSourceFile = sourceFileParts[0].Replace("Screenshot", "");
            var convertedPath = Properties.Settings.Default.ScreenshotDestinationPath + "\\" + fixedBody + "_" + fixedSourceFile + ".jpg";
            if (!File.Exists(convertedPath))
            {

                MagickImage MyImage = new MagickImage(fullSourcePath);
                string[] imageDimensions = Properties.Settings.Default.ConvertResolution.Split('x');
                MyImage.Resize(Int32.Parse(imageDimensions[0]), Int32.Parse(imageDimensions[1]));

                MyImage.Settings.FontPointsize = 48;
                MyImage.Settings.FontFamily = "Consolas";
                MyImage.Settings.FillColor = (MagickColor.FromRgb((byte)255, (byte)255, (byte)255));
                //MyImage.Annotate(edObject.Body + "  ", Gravity.Center);
                //MyImage.Annotate(edObject.timestamp + " ", Gravity.Southeast);

                MyImage.Write(convertedPath);
                mainform.labelScreenshotSystem.Text = edObject.Body;
                mainform.labelScreenshotTimestamp.Text = edObject.timestamp;
                mainform.pictureBoxConverted.Image = Image.FromFile(convertedPath);

            }
        } 
    }
}
