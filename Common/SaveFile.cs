using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;




namespace Common
{
  public  class SaveFile
    {
        private SaveFile() { }
        private static SaveFile Instance;

        public static SaveFile GetInstance()
        {
            if (Instance == null)
                Instance = new SaveFile();

            return Instance;
        }
        private SeoUrl _com;
        private SeoUrl com
        {
            get
            {
                if (_com == null)
                    _com = SeoUrl.GetInstance();

                return _com;
            }
        }


     string pathPhoto = @"e:\istanbulKampus_Portal\Content\SoruImage\";

        public void SaveFileToPath(/*HttpPostedFileBase file,*/ string filePath, string path, string adi ,string extension)
        {
              
            filePath = filePath +com.ConvertPath(path);
            adi = com.ConvertTurkishToEng(adi);

            //if (extension.ToLower().Contains("jp") || extension.ToLower().Contains("png"))
            //    SavePhoto(file, filePath, adi);
            //else
            //{



            //    try
            //    {
            //        if (!System.IO.Directory.Exists(filePath))
            //        {
            //            System.IO.Directory.CreateDirectory(filePath);
            //        }

            //    }
            //    catch (Exception ex)
            //    {


            //    }
            //    filePath = filePath + com.ConvertTurkishToEng(adi);

            //    file.SaveAs(filePath);
            //}

        }
     

        public string SavePhoto(/*HttpPostedFileBase file, */string imgpathPhoto, string adi)
        {
 


         
            ////#endif

           



            //foreach (var prop in Image.FromStream(file.InputStream).PropertyItems) //image ın propertilerinden rotate durumuna bakılıp düzeltilip kayıt ediliyor
            //{
            //    if (Image.FromStream(file.InputStream).PropertyItems.Any(q => q.Id == 0x112))//Yön bilgisi yoksa fotoğrafta else ile direk kayıt işlemi yapılır.
            //    {
            //        if (prop.Id == 0x112)//sadece yön için işlem yapılıyor
            //        {
            //            if (prop.Value[0] == 6)
            //            {
            //                //  rotate = 90;
            //                RotateImage(imgpathPhoto, adi, file, EncoderValue.TransformRotate90);

            //            }
            //            else if (prop.Value[0] == 8)
            //            {
            //                //  rotate = -90; 
            //                RotateImage(imgpathPhoto, adi, file, EncoderValue.TransformRotate270);
            //            }
            //            else if (prop.Value[0] == 3)
            //            {
            //                //rotate = 180;
            //                RotateImage(imgpathPhoto, adi, file, EncoderValue.TransformRotate180);
            //            }
            //            else
            //                RotateImage(imgpathPhoto, adi, file, EncoderValue.Flush);
            //        }
            //    }
            //    else
            //        RotateImage(imgpathPhoto, adi, file, EncoderValue.Flush);
            //}
             
            return com.ConvertUrl(adi);

        }






        //private void RotateImage(string pathPhoto, string fileName,/* HttpPostedFileBase fileUp,*/ EncoderValue encoderValue)
        //{

        //    System.Drawing  image;
        //    image = System.Drawing.Image.FromStream(fileUp.InputStream);
        //    pathPhoto = com.ConvertTurkishToEng(pathPhoto);
        //    try
        //    {
        //        if (!System.IO.Directory.Exists(pathPhoto))
        //        {
        //            System.IO.Directory.CreateDirectory(pathPhoto);
        //        }



        //    }
        //    catch (Exception ex)
        //    {

                
        //    }


        //    if (encoderValue != EncoderValue.Flush)
        //    {
        //        PropertyItem[] PropertyItems;

        //        var Enc = System.Drawing.Imaging.Encoder.Transformation;
        //        EncoderParameters EncParms = new EncoderParameters(1);
        //        EncoderParameter EncParm;
        //        ImageCodecInfo CodecInfo = GetEncoderInfo("image/jpeg");

        //        // Load the image to rotate.


        //        PropertyItems = image.PropertyItems;
        //        PropertyItems[0].Id = 0x0112; // 0x0112 as specified in EXIF standard
        //        PropertyItems[0].Type = 3;
        //        PropertyItems[0].Len = 2;
        //        byte[] orientation = new Byte[2];
        //        orientation[0] = 1; // little Endian
        //        orientation[1] = 0;
        //        PropertyItems[0].Value = orientation;
        //        image.SetPropertyItem(PropertyItems[0]);

        //        EncParm = new EncoderParameter(Enc, (long)encoderValue);
        //        EncParms.Param[0] = EncParm;
        //        //image = ResizeImage(image, 1000, 800);
        //        image.Save(pathPhoto + fileName, CodecInfo, EncParms);




        //    }
        //    else
        //    {

        //        byte[] arr2;
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            arr2 = ms.ToArray();
        //        }
        //        WebImage imgWeb = new WebImage(arr2).Resize(1000, 1000, true);
        //        imgWeb.Save(pathPhoto + fileName);//thumbnail


        //    }



        //}
        //private   ImageCodecInfo GetEncoderInfo(String mimeType)
        //{
        //    int j;
        //    ImageCodecInfo[] encoders;
        //    encoders = ImageCodecInfo.GetImageEncoders();
        //    for (j = 0; j < encoders.Length; ++j)
        //    {
        //        if (encoders[j].MimeType == mimeType)
        //            return encoders[j];
        //    }
        //    return null;
        //}
     
       
    }
}
