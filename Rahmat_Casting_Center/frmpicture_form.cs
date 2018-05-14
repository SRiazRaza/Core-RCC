using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.IO;

using DevExpress.Data.Camera;
using DevExpress.XtraEditors.Camera;
namespace Rahmat_Casting_Center
{
    public partial class frmpicture_form : Form
    {
        string acc;
        string ser;
        string ans;
        CameraDeviceInfo abc;
             CameraDeviceInfo xyz;
        public frmpicture_form(String accountid, String serial, String a)
        {
            InitializeComponent();
            acc = accountid;
            ser = serial;
            ans = a;
            if (accountid == "" && serial == "" && a == "")
            {
                button2.Enabled = false;
            }
            else
            {

            }


        }

        private void picture_form_Load(object sender, EventArgs e)
        {

            // cameraControl1.Stop();
            //cameraControl2.Stop();
            //          MessageBox.Show(abc.ToString());
            //            MessageBox.Show(xyz.ToString());
            //MessageBox.Show(cameraControl1.Device.Name.ToString());


             abc = CameraControl.GetDevices().FirstOrDefault();
             xyz = CameraControl.GetDevices().LastOrDefault();
            if (abc != xyz)
            {
                cameraControl2.Device = new CameraDevice(abc);
                cameraControl2.Start();
               
                cameraControl1.Device = new CameraDevice(xyz);
                cameraControl1.Start();

            }
            else
            {
                cameraControl1.Start();
                cameraControl2.Start();

            }


            #region 
            // Extra for Camera Research & learning
            /* CameraDeviceInfo cdi = CameraControl.GetDevices().Where(c => c.Name == "USB2.0 PC CAMERA").FirstOrDefault();
             if (cdi != null)
             {

                 cameraControl1.Device = new CameraDevice(new DevExpress.Data.Camera.CameraDeviceInfo(cdi.MonikerString, cdi.Name));
                 cameraControl1.Start();
             }*/




            /*   if (!DesignMode)
                {
                    if (!DesignMode)
                    {
                        comboBoxCameras.Items.Clear();
                        foreach (Camera cam in CameraService.AvailableCameras)
                            comboBoxCameras.Items.Add(cam);

                        if (comboBoxCameras.Items.Count > 0)
                            comboBoxCameras.SelectedIndex = 0;
                    }
                }


                //start



                // Early return if we've selected the current camera
                if (_frameSource != null && _frameSource.Camera == comboBoxCameras.SelectedItem)
                    return;

                thrashOldCamera();
                startCapturing();*/



        }
        /*
          public void ind() {
              individual = new WebCam();

               individual.InitializeWebCam(ref pictureBox1);
               individual.Continue();

          }
          public void art() {

              article = new WebCam();
              article.InitializeWebCam(ref pictureBox3);
            article.Continue();
          }
          private void startCapturing()
          {
              try
              {
                  Camera c = (Camera)comboBoxCameras.SelectedItem;
                  setFrameSource(new CameraFrameSource(c));
                  _frameSource.Camera.CaptureWidth = 640;
                  _frameSource.Camera.CaptureHeight = 480;
                  _frameSource.Camera.Fps = 50;
                  _frameSource.NewFrame += OnImageCaptured;

                  pictureBox1.Paint += new PaintEventHandler(drawLatestImage);
                    }
              catch (Exception ex)
              {
                  comboBoxCameras.Text = "Select A Camera";
                  MessageBox.Show(ex.Message);
              }
          }
          private void setFrameSource(CameraFrameSource cameraFrameSource)
          {
              if (_frameSource == cameraFrameSource)
                  return;

              _frameSource = cameraFrameSource;
          }

          private void drawLatestImage(object sender, PaintEventArgs e)
          {
              if (_latestFrame != null)
              {
                  e.Graphics.DrawImage(_latestFrame, 0, 0, _latestFrame.Width, _latestFrame.Height);
              }
          }

          public void OnImageCaptured(Touchless.Vision.Contracts.IFrameSource frameSource,
                                      Touchless.Vision.Contracts.Frame frame, double fps)
          {
              _latestFrame = frame.Image;
              pictureBox1.Invalidate();
          }
          private void thrashOldCamera()
          {
              // Trash the old camera
              if (_frameSource != null)
              {
                  _frameSource.NewFrame -= OnImageCaptured;
                  _frameSource.Camera.Dispose();
                  setFrameSource(null);
                  pictureBox1.Paint -= new PaintEventHandler(drawLatestImage);
              }
          }

       */
        #endregion  // Extra learning Research ref....  // Extra 


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cameraControl1.Device.IsRunning == false)
                {
                    pictureBox2.Image = Rahmat_Casting_Center.Properties.Resources.index;

                    pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;

                }
                else
                {
                    Image igCap = cameraControl1.TakeSnapshot();
                    if (igCap != null)
                    {
                        Bitmap objBitmap = new Bitmap(igCap, new Size(270, 200));
                        pictureBox2.Image = objBitmap;
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex) {
                string abc = ex.ToString();
                MessageBox.Show("Camera Control Error.");
            }
        }
    

        private void Single_Pic()
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Please Capture an Image first!");
            }
            else
            {
                try
                {
                    SQLConn.sqL = "UPDATE accountdetails SET image= @pic1 ,image1= @pic2 where AccountID='" + acc + "' AND SerialNo='" + ser + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);

                    MemoryStream stream = new MemoryStream();
                    pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic1 = stream.ToArray();

                    MemoryStream stream2 = new MemoryStream();
                    pictureBox4.Image.Save(stream2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic2 = stream2.ToArray();

                    SQLConn.cmd.Parameters.AddWithValue("@pic1", pic1);
                    SQLConn.cmd.Parameters.AddWithValue("@pic2", pic2);

                    SQLConn.cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.ToString());
                }
                finally
                {
                    SQLConn.cmd.Dispose();
                    SQLConn.conn.Close();
                }

                callStop();
            }
        }
        private void Cash_Pic()
        {
            if (pictureBox2.Image == null )
            {
                MessageBox.Show("Please Capture an Image first!");
            }
            else
            {
                try
                {
                    SQLConn.sqL = "UPDATE caccountdetails SET image= @pic1 ,image1= @pic2 where AccountID='" + acc + "' AND SerialNo='" + ser + "'";
                    SQLConn.ConnDB();
                    SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);

                    MemoryStream stream = new MemoryStream();
                    pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic1 = stream.ToArray();

                    MemoryStream stream2 = new MemoryStream();
                    pictureBox4.Image.Save(stream2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic2 = stream2.ToArray();

                    SQLConn.cmd.Parameters.AddWithValue("@pic1", pic1);
                    SQLConn.cmd.Parameters.AddWithValue("@pic2", pic2);

                    SQLConn.cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.ToString());
                }
                finally
                {
                    SQLConn.cmd.Dispose();
                    SQLConn.conn.Close();
                }
                callStop();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            callStop();
        }
        void callStop() {

            cameraControl1.Stop();
            cameraControl2.Stop();
            this.Close();
        }

        private void picture_form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
            {
                button1.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad2)
            {

                button4.PerformClick();
            }

            else if (e.KeyCode == Keys.NumPad3)
            {
                button2.PerformClick();
            }

            else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.Escape)
            {
                button3.PerformClick();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (cameraControl2.Device.IsRunning == false)
                {
                    pictureBox4.Image = Rahmat_Casting_Center.Properties.Resources.index;
                    pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;

                }
                else
                {
                    Image capI = cameraControl2.TakeSnapshot();
                    if (capI != null)
                    {
                        Bitmap omap = new Bitmap(capI, new Size(270, 200));
                        pictureBox4.Image = omap;
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                string abc = ex.ToString();
                MessageBox.Show("Camera Control Error.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ans == "Single")
            {
                Single_Pic();

            }
            else if (ans == "Cash")
            {

                Cash_Pic();
            }
            else {
                MessageBox.Show("Exception: Please Contact your Developer");
            }
        }


    }
}
