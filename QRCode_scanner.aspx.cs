 protected void Button1_Click(object sender, EventArgs e)
        {
            string code = TextBox1.Text; //enter text 
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData qrCodeData = qr.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);        
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
            {
                using(MemoryStream ms = new MemoryStream())
                {
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage =ms.ToArray();
                    imgBarCode.ImageUrl="data:image/png;base64," + Convert.ToBase64String(byteImage);

                }
                PlaceHolder1.Controls.Add(imgBarCode);  
            }
            Label2.Visible = false; 
        }
