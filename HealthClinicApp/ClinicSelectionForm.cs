using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthClinicApp
{
    public partial class ClinicSelectionForm : Form
    {
        DataTable dtClinics = new DataTable();
        DataTable dtDocs = new DataTable();
        DataTable dtSpecificClinicDoctors = new DataTable();
        public ClinicSelectionForm()
        {
            InitializeComponent();
        }

        private void ClinicSelectionForm_Load(object sender, EventArgs e)
        {
            FillClinicTable();
            FillDoctorTable();  

            clinicSelectionComboBox.DataSource = dtClinics;
            clinicSelectionComboBox.DisplayMember = "CName";

                    

        }

        private void FillClinicTable()
        {
            dtClinics.Columns.Add("CID", typeof(int));
            dtClinics.Columns.Add("CName");
            dtClinics.Columns.Add("CAddress");
            dtClinics.Columns.Add("CContact");
            dtClinics.Columns.Add("CRating");

            dtClinics.Rows.Add(1, "Dr. Parsnani Private Clinic", "Aga Khan Baug", "7858758756","8/10");
            dtClinics.Rows.Add(2, "Dentomania", "Yari Road", "7857657476", "9/10");
            dtClinics.Rows.Add(3, "Dr. Dhumaskar Hospital", "Goa", "080775454","7.5/10");
            dtClinics.Rows.Add(4, "Auckland City Hospital", "Auckland", "4321447890","5/10");

        }

        private void clinicSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clinicNameLabel.Text = dtClinics.Rows[clinicSelectionComboBox.SelectedIndex]["CName"].ToString();
            clinicAddressLabel.Text = dtClinics.Rows[clinicSelectionComboBox.SelectedIndex]["CAddress"].ToString();
            clinicRatingLabel.Text = dtClinics.Rows[clinicSelectionComboBox.SelectedIndex]["CRating"].ToString();
            clinicContactNoLabel.Text = dtClinics.Rows[clinicSelectionComboBox.SelectedIndex]["CContact"].ToString();

            dtSpecificClinicDoctors = dtDocs.Select("CID = " + dtClinics.Rows[clinicSelectionComboBox.SelectedIndex]["CID"]).CopyToDataTable();
            docSelectionComboBox.DataSource = dtSpecificClinicDoctors;
            docSelectionComboBox.DisplayMember = "DName";

        }

        private void docSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            docNameLabel.Text = dtSpecificClinicDoctors.Rows[docSelectionComboBox.SelectedIndex]["DName"].ToString();
            docSpecialityLabel.Text = dtSpecificClinicDoctors.Rows[docSelectionComboBox.SelectedIndex]["DSpeciality"].ToString();
            docContactLabel.Text = dtSpecificClinicDoctors.Rows[docSelectionComboBox.SelectedIndex]["DContact"].ToString();

        }

        private void FillDoctorTable()
        {
            dtDocs.Columns.Add("CID", typeof(int));
            dtDocs.Columns.Add("DName");
            dtDocs.Columns.Add("DSpeciality");
            dtDocs.Columns.Add("DContact");

            dtDocs.Rows.Add(1, "Dr. Parsnani", "GP", "7858758756");
            dtDocs.Rows.Add(2, "Dr. Rehmatula", "Pediatrician", "7857657476");
            dtDocs.Rows.Add(2, "Dr. Ai Hoshino", "Obstetrics and gynaecology", "7855647476");
            dtDocs.Rows.Add(2, "Dr. Gorou Amemiya", "Surgeon", "7857641512");
            dtDocs.Rows.Add(3, "Dr. Apay Balachandran", "Dermatologist", "080775454");
            dtDocs.Rows.Add(3, "Dr. Grisha Yeager", "Oncologist", "0845674");
            dtDocs.Rows.Add(3, "Dr. Dhumaskar", "GP", "080780867");
            dtDocs.Rows.Add(4, "Dr. Velita Menezes", "Anesthesiologist", "4321423454");
            dtDocs.Rows.Add(4, "Dr. Sakura Yamauchi", "Cardiologist", "4321454657");
            dtDocs.Rows.Add(4, "Dr. Gojo Saturou", "Psychiatrist", "43214457468");
            dtDocs.Rows.Add(4, "Dr. Ainz Oul Gowl", "Pathologist", "4321445748");

        }
    }
}
