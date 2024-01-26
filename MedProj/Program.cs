// Replace 'your_image_path.jpg' with the actual path to your image
using MedProj;
using OpenCvSharp;
using System;

string imagePath = "C:\\medproj\\test_record_00001_lr.png";

// Read the image
Mat img = Cv2.ImRead(imagePath, ImreadModes.Grayscale);
if (img == null || img.Empty())
{
    Console.WriteLine($"Error: Unable to load the image from {imagePath}");
    return;
}

// Apply threshold to convert the image to binary (black and white)
Mat thresholded = new Mat();
Cv2.Threshold(img, thresholded, 127, 255, ThresholdTypes.Binary);

// Find contours in the binary image
HierarchyIndex[] hierarchy;
Cv2.FindContours(thresholded, out var contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

// Draw contours on the original image
Mat resultImg = img.Clone();
Cv2.DrawContours(resultImg, contours, -1, Scalar.Red, 2);

// Print the coordinates of each point in the contours
FileOut.SaveVetor(contours);
FileOut.SaveImage(resultImg);