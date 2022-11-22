using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Loggr
{

    public partial class Home : Form
    {
        public string extension = "*";
        public bool overwitebool;
        public bool includesub = false;

        DriveInfo[] allDrives = DriveInfo.GetDrives();


        public Home()
        {
            InitializeComponent();

            newpb.Minimum = 0;

            newpb.Value = 0;



            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].IsReady == true)
                {
                    drive_dt.Text = " " + allDrives[0];
                    long totalspace = allDrives[0].TotalSize / 1073741824;
                    long availspace = allDrives[0].AvailableFreeSpace / 1073741824;
                    long usedspace = totalspace - availspace;

                    pbdrive.Maximum = Convert.ToInt32(totalspace);
                    pbdrive.Value = Convert.ToInt32(usedspace);
                    space_info.Text = availspace + " GB free of " + totalspace + "GB";

                }
            }







        }



        private void selectFolder_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                org_txt.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void selectDestination_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                dest_txt.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }






        ///TRANSFER///////////////

        private void Transfer_btn_Click(object sender, EventArgs e)
        {


        }
        private void Copy_Click(object sender, EventArgs e)
        {



        }

        public void transferAction()
        {
            var originpathin = @"" + org_txt.Text + @"\";
            var destinationpathin = @"" + dest_txt.Text + @"\";

            try
            {
                string[] files = Directory.GetFiles(originpathin, "*." + extension, SearchOption.TopDirectoryOnly);
                newpb.Maximum = files.Length - 1;
                for (int i = 0; i <= files.Length; i++)
                {



                    try
                    {





                        File.Move(files[i], destinationpathin + "" + Path.GetFileName(files[i]));

                    }
                    catch (Exception)
                    {


                    }
                    if (i == files.Length)
                    {
                        prog.Refresh();
                        prog.Text = "Finished";
                        prog.Refresh();
                        newpb.Refresh();
                        newpb.Value = 0;
                        newpb.Refresh();
                    }
                    else
                    {
                        prog.Refresh();
                        prog.Text = "Moving...";
                        prog.Refresh();

                    }


                }
            }
            catch (Exception)
            {


            }





        }
        public void transferActionall()
        {
            var originpathin = @"" + org_txt.Text + @"\";
            var destinationpathin = @"" + dest_txt.Text + @"\";

            try
            {
                string[] files = Directory.GetFiles(originpathin, "*." + extension, SearchOption.AllDirectories);
                newpb.Maximum = files.Length - 1;
                for (int i = 0; i <= files.Length; i++)
                {
                    try
                    {




                        File.Move(files[i], destinationpathin + "" + Path.GetFileName(files[i]));

                    }
                    catch (Exception)
                    {


                    }

                    if (i == files.Length)
                    {
                        prog.Refresh();
                        prog.Text = "Finished";
                        prog.Refresh();
                        newpb.Refresh();
                        newpb.Value = 0;
                        newpb.Refresh();
                    }
                    else
                    {
                        prog.Refresh();
                        prog.Text = "Moving...";
                        prog.Refresh();

                    }


                }
            }
            catch (Exception)
            {


            }



        }
        public void copyAction()
        {

            if (overwrite.Checked)
            {
                overwitebool = true;
            }
            else
            {
                overwitebool = false;
            }

            var originpathin = @"" + org_txt.Text + @"\";
            var destinationpathin = @"" + dest_txt.Text + @"\";

            try
            {
                string[] files = Directory.GetFiles(originpathin, "*." + extension, SearchOption.TopDirectoryOnly);
                newpb.Maximum = files.Length - 1;
                for (int i = 0; i <= files.Length; i++)
                {
                    try
                    {







                        File.Copy(files[i], destinationpathin + "" + Path.GetFileName(files[i]), overwitebool);

                        newpb.Value++;

                    }
                    catch (Exception)
                    {


                    }

                    if (i == files.Length)
                    {
                        prog.Refresh();
                        prog.Text = "Finished";
                        prog.Refresh();
                        newpb.Refresh();
                        newpb.Value = 0;
                        newpb.Refresh();
                    }
                    else
                    {
                        prog.Refresh();
                        prog.Text = "Copying...";
                        prog.Refresh();

                    }
                }




            }
            catch (Exception)
            {

            }



        }
        public void copyActionall()
        {
            if (overwrite.Checked)
            {
                overwitebool = true;
            }
            else
            {
                overwitebool = false;
            }

            var originpathin = @"" + org_txt.Text + @"\";
            var destinationpathin = @"" + dest_txt.Text + @"\";

            try
            {
                string[] files = Directory.GetFiles(originpathin, "*." + extension, SearchOption.AllDirectories);
                newpb.Maximum = files.Length - 1;
                for (int i = 0; i <= files.Length; i++)
                {
                    try
                    {





                        File.Copy(files[i], destinationpathin + "" + Path.GetFileName(files[i]), overwitebool);
                        newpb.Value++;
                    }
                    catch (Exception)
                    {


                    }
                    if (i == files.Length)
                    {
                        prog.Refresh();
                        prog.Text = "Finished";
                        prog.Refresh();
                        newpb.Refresh();
                        newpb.Value = 0;
                        newpb.Refresh();
                    }
                    else
                    {
                        prog.Refresh();
                        prog.Text = "Copying...";
                        prog.Refresh();

                    }
                }
            }
            catch (Exception)
            {

            }




        }




        ///EXTENSIONS////////////////////////////////////////////////////////////////////
        private void radioButton5_CheckedChanged(object sender, EventArgs e) //for exe
        {
            extension = "exe";
        }

        private void pdf_CheckedChanged(object sender, EventArgs e)
        {
            extension = "pdf";
        }

        private void docx_CheckedChanged(object sender, EventArgs e)
        {
            extension = "docx";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            extension = "txt";
        }

        private void overwrite_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void includesubfolders_CheckedChanged(object sender, EventArgs e)
        {
            includesub = true;
        }

        private void pBar_Click(object sender, EventArgs e)
        {

        }

        private void png_CheckedChanged(object sender, EventArgs e)
        {
            extension = "png";
        }

        private void jpeg_CheckedChanged(object sender, EventArgs e)
        {
            extension = "jpeg";
        }

        private void zip_CheckedChanged(object sender, EventArgs e)
        {
            extension = "zip";
        }

        private void mp3_CheckedChanged(object sender, EventArgs e)
        {
            extension = "mp3";
        }

        private void ppt_CheckedChanged(object sender, EventArgs e)
        {
            extension = "ppt";
        }

        private void Doc_CheckedChanged(object sender, EventArgs e)
        {
            extension = "doc";
        }

        private void Jpg_CheckedChanged(object sender, EventArgs e)
        {
            extension = "jpg";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e) //for webp
        {
            extension = "webp";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            extension = "rar";
        }

        private void mp4_CheckedChanged(object sender, EventArgs e)
        {
            extension = "mp4";
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            prog.Refresh();

            space_info.AutoSize = true;

            string userName = Environment.UserName;

            usr_name.Text = "Hello, " + userName;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            extension = others_txt.Text;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void usr_name_Click(object sender, EventArgs e)
        {

        }

        private void submat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (includesubfolders.Checked)
            {
                transferActionall();
            }
            else
            {
                transferAction();
            }
        }

        private void copybtn_Click(object sender, EventArgs e)
        {

            if (includesubfolders.Checked)
            {
                copyActionall();
            }
            else
            {
                copyAction();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                dest_txt.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                org_txt.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void destinationPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void howtouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.loggr.orjiude.com/docs");
        }

        private void feedback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:sullivanorjiude@gmail.com");
        }

        private void morefromdev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.orjiude.com");
        }

        private void clearRadios(object sender, EventArgs e)
        {



        }

        private void others_txt_TextChanged(object sender, EventArgs e)
        {
            radioButton10.Checked = false;

            radioButton11.Checked = false;

            radioButton5.Checked = false;

            pdf.Checked = false;

            docx.Checked = false;

            radioButton10.Checked = false;

            png.Checked = false;

            jpeg.Checked = false;

            zip.Checked = false;

            mp3.Checked = false;

            ppt.Checked = false;

            Doc.Checked = false;

            Jpg.Checked = false;

            radioButton11.Checked = false;

            mp4.Checked = false;

            extension = others_txt.Text;
        }
    }
}
