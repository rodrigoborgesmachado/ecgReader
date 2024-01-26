using OpenCvSharp;
using System.Text;

namespace MedProj
{
    internal static class FileOut
    {
        public static bool SaveVetor(Point[][] points)
        {
            bool result = false;

            try
            {
                string fileDir = CriaDir() + "//out.txt";
                if(File.Exists(fileDir))
                {
                    File.Delete(fileDir);
                }

                StringBuilder stringBuilder = new StringBuilder();
                foreach (Point[] point in points) 
                {
                    var orderedPoints = point.ToArray().OrderBy(p => p.X).ToList();
                    foreach (Point p in orderedPoints)
                    {
                        if (p.X == 0 || p.Y == 0) continue;

                        stringBuilder.Append(p.X.ToString() + ",");
                        stringBuilder.AppendLine(p.Y.ToString());
                    }
                }

                File.WriteAllText(fileDir, stringBuilder.ToString());
                result = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                result = false;
            }
            

            return result;
        }

        public static bool SaveImage(Mat image)
        {
            if(image.Empty())
                return false;

            bool resultado = false;
            try
            {
                string fileDir = CriaDir() + "//output.png";
                
                if(File.Exists(fileDir))
                    File.Delete(fileDir);

                Cv2.ImWrite(fileDir, image);

                resultado = true;
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                resultado = false;
            }

            return resultado;
        }

        private static string CriaDir()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "//Output"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "//Output");

            return Directory.GetCurrentDirectory() + "//Output";
        }
    }
}
