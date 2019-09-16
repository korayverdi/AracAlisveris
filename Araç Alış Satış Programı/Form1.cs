using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections;

namespace Araç_Alış_Satış_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server = localhost; Uid = root; Password = 416516; Database = aracalissatis; Port = 3306");
        string kod;
        string[] satirVerileri = new string[7];

        private void CB_Doldur()
        {
            baglanti.Open();
            MySqlCommand yolAraba = new MySqlCommand("SELECT * FROM tbl_araba, tbl_vitesturu, tbl_yakitturu, tbl_renk" +
                " where Araba_VitesTuruID = VitesTuruID and Araba_YakitTuruID = YakitTuruID and " +
                "Araba_RenkID = RenkID;", baglanti);
            MySqlDataReader ArabaOku = yolAraba.ExecuteReader();

            while (ArabaOku.Read())
            {
                comboBoxIlanAraba.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                    + ArabaOku["Araba_Model"].ToString() + "->"
                    + ArabaOku["Vites_Turu"].ToString() + "->"
                    + ArabaOku["Yakit_Turu"].ToString() + "->"
                    + ArabaOku["Renk"].ToString());

                comboBoxIlanAraba_G.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                    + ArabaOku["Araba_Model"].ToString() + "->"
                    + ArabaOku["Vites_Turu"].ToString() + "->"
                    + ArabaOku["Yakit_Turu"].ToString() + "->"
                    + ArabaOku["Renk"].ToString());
            }
            baglanti.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////
            baglanti.Open();
            MySqlCommand yolRenk = new MySqlCommand("SELECT * FROM tbl_renk;", baglanti);
            MySqlDataReader renkOku = yolRenk.ExecuteReader();
            comboBoxRenk_F.Items.Add("Tümü");

            while (renkOku.Read())
            {
                comboBoxRenk.Items.Add(renkOku["Renk"].ToString());

                comboBoxRenk_G.Items.Add(renkOku["Renk"].ToString());

                comboBoxRenk_F.Items.Add(renkOku["Renk"].ToString());
            }
            baglanti.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////
            baglanti.Open();
            MySqlCommand yolSehir = new MySqlCommand("SELECT * FROM tbl_sehir", baglanti);
            MySqlDataReader sehirOku = yolSehir.ExecuteReader();
            comboBoxSehir_F.Items.Add("Tümü");

            while (sehirOku.Read())
            {
                comboBoxIlanSehir.Items.Add(sehirOku["Sehir"].ToString());

                comboBoxIlanSehir_G.Items.Add(sehirOku["Sehir"].ToString());

                comboBoxSehir_F.Items.Add(sehirOku["Sehir"].ToString());
            }
            baglanti.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////
            baglanti.Open();
            MySqlCommand yolVitesTuru = new MySqlCommand("SELECT * FROM tbl_vitesturu", baglanti);
            MySqlDataReader vitesturuOku = yolVitesTuru.ExecuteReader();
            comboBoxVT_F.Items.Add("Tümü");

            while (vitesturuOku.Read())
            {
                comboBoxVT.Items.Add(vitesturuOku["Vites_Turu"].ToString());

                comboBoxVT_G.Items.Add(vitesturuOku["Vites_Turu"].ToString());

                comboBoxVT_F.Items.Add(vitesturuOku["Vites_Turu"].ToString());
            }
            baglanti.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////
            baglanti.Open();
            MySqlCommand yolYakitTuru = new MySqlCommand("SELECT * FROM tbl_yakitturu", baglanti);
            MySqlDataReader yakitTuruOku = yolYakitTuru.ExecuteReader();
            comboBoxYT_F.Items.Add("Tümü");

            while (yakitTuruOku.Read())
            {
                comboBoxYT.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());

                comboBoxYT_G.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());

                comboBoxYT_F.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
            }
            baglanti.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////
            baglanti.Open();
            MySqlCommand yolMarkalar = new MySqlCommand("SELECT DISTINCT Araba_Marka FROM tbl_araba", baglanti);
            MySqlDataReader MarkalarOku = yolMarkalar.ExecuteReader();

            while (MarkalarOku.Read())
            {
                comboBoxMarka_F.Items.Add(MarkalarOku["Araba_Marka"].ToString());
            }
            baglanti.Close();
        }

        private void sehirleriGoster()
        {
            listViewSehirList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_sehir", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["SehirID"].ToString();
                ekle.SubItems.Add(oku["Sehir"].ToString());
                listViewSehirList.Items.Add(ekle);
            }

            baglanti.Close();
        }

        private void silinecekSehirleriGoster()
        {
            listViewSehirSilList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_sehir", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["SehirID"].ToString();
                ekle.SubItems.Add(oku["Sehir"].ToString());
                listViewSehirSilList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void G_sehirleriGoster()
        {
            listViewSehir_G.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_sehir", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["SehirID"].ToString();
                ekle.SubItems.Add(oku["Sehir"].ToString());
                listViewSehir_G.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void ilanlariGoster()
        {
            listViewIlanList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_ilan", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["IlanID"].ToString();
                ekle.SubItems.Add(oku["Ilan_Adi"].ToString());
                ekle.SubItems.Add(oku["Ilan_Fiyat"].ToString());
                ekle.SubItems.Add(oku["Ilan_Km"].ToString());
                ekle.SubItems.Add(oku["Ilan_Tarih"].ToString());
                ekle.SubItems.Add(oku["Ilan_ArabaID"].ToString());
                ekle.SubItems.Add(oku["Ilan_SehirId"].ToString());
                listViewIlanList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void silinecekIlanlariGoster()
        {
            listViewIlanSilList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_ilan", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["IlanID"].ToString();
                ekle.SubItems.Add(oku["Ilan_Adi"].ToString());
                ekle.SubItems.Add(oku["Ilan_Fiyat"].ToString());
                ekle.SubItems.Add(oku["Ilan_Km"].ToString());
                ekle.SubItems.Add(oku["Ilan_Tarih"].ToString());
                ekle.SubItems.Add(oku["Ilan_ArabaID"].ToString());
                ekle.SubItems.Add(oku["Ilan_SehirId"].ToString());
                listViewIlanSilList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void G_ilanlariGoster()
        {
            listViewIlan_G.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_ilan", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["IlanID"].ToString();
                ekle.SubItems.Add(oku["Ilan_Adi"].ToString());
                ekle.SubItems.Add(oku["Ilan_Fiyat"].ToString());
                ekle.SubItems.Add(oku["Ilan_Km"].ToString());
                ekle.SubItems.Add(oku["Ilan_Tarih"].ToString());
                ekle.SubItems.Add(oku["Ilan_ArabaID"].ToString());
                ekle.SubItems.Add(oku["Ilan_SehirId"].ToString());
                listViewIlan_G.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void arabalariGoster()
        {
            listViewArabaList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_araba", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ArabaID"].ToString();
                ekle.SubItems.Add(oku["Araba_Marka"].ToString());
                ekle.SubItems.Add(oku["Araba_Model"].ToString());
                ekle.SubItems.Add(oku["Araba_VitesTuruID"].ToString());
                ekle.SubItems.Add(oku["Araba_YakitTuruID"].ToString());
                ekle.SubItems.Add(oku["Araba_RenkID"].ToString());
                listViewArabaList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void silinecekArabalariGoster()
        {
            listViewArabaSilList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_araba", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ArabaID"].ToString();
                ekle.SubItems.Add(oku["Araba_Marka"].ToString());
                ekle.SubItems.Add(oku["Araba_Model"].ToString());
                ekle.SubItems.Add(oku["Araba_VitesTuruID"].ToString());
                ekle.SubItems.Add(oku["Araba_YakitTuruID"].ToString());
                ekle.SubItems.Add(oku["Araba_RenkID"].ToString());
                listViewArabaSilList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void G_arabalariGoster()
        {
            listViewAraba_G.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_araba", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ArabaID"].ToString();
                ekle.SubItems.Add(oku["Araba_Marka"].ToString());
                ekle.SubItems.Add(oku["Araba_Model"].ToString());
                ekle.SubItems.Add(oku["Araba_VitesTuruID"].ToString());
                ekle.SubItems.Add(oku["Araba_YakitTuruID"].ToString());
                ekle.SubItems.Add(oku["Araba_RenkID"].ToString());
                listViewAraba_G.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void yakitTurleriniGoster()
        {
            listViewYakitTuruList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_yakitturu", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["YakitTuruID"].ToString();
                ekle.SubItems.Add(oku["Yakit_Turu"].ToString());
                listViewYakitTuruList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void silYakitTurleriniGoster()
        {
            listViewYakitTuruSilList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_yakitturu", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["YakitTuruID"].ToString();
                ekle.SubItems.Add(oku["Yakit_Turu"].ToString());
                listViewYakitTuruSilList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void G_YT_Goster()
        {
            listViewYT_G.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_yakitturu", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["YakitTuruID"].ToString();
                ekle.SubItems.Add(oku["Yakit_Turu"].ToString());
                listViewYT_G.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void vitesTurleriniGoster()
        {
            listViewVitesTuruList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_vitesturu", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["VitesTuruID"].ToString();
                ekle.SubItems.Add(oku["Vites_Turu"].ToString());
                listViewVitesTuruList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void silVitesTurleriniGoster()
        {
            listViewVitesTuruSilList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_vitesturu", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["VitesTuruID"].ToString();
                ekle.SubItems.Add(oku["Vites_Turu"].ToString());
                listViewVitesTuruSilList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void G_VT_Goster()
        {
            listViewVT_G.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_vitesturu", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["VitesTuruID"].ToString();
                ekle.SubItems.Add(oku["Vites_Turu"].ToString());
                listViewVT_G.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void renkleriGoster()
        {
            listViewRenkList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_renk", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["RenkID"].ToString();
                ekle.SubItems.Add(oku["Renk"].ToString());
                listViewRenkList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void silRenkleriGoster()
        {
            listViewRenkSilList.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_renk", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["RenkID"].ToString();
                ekle.SubItems.Add(oku["Renk"].ToString());
                listViewRenkSilList.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void G_renkleriGoster()
        {
            listViewRenk_G.Items.Clear();
            baglanti.Open();
            MySqlCommand yol = new MySqlCommand("Select * From tbl_renk", baglanti);
            MySqlDataReader oku = yol.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["RenkID"].ToString();
                ekle.SubItems.Add(oku["Renk"].ToString());
                listViewRenk_G.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void FiltreleriGoster()
        {
            listViewFiltrelenmisIlanlar.Items.Clear();
            baglanti.Open();
            MySqlCommand yolFiltreler = new MySqlCommand("select IlanID, Ilan_Adi, Ilan_Fiyat, Ilan_Km," +
                " Ilan_Tarih, Araba_Marka, Araba_Model, Vites_Turu, Yakit_Turu, Renk, Sehir " +
                "from tbl_ilan, tbl_araba, tbl_vitesturu, tbl_yakitturu, tbl_renk, tbl_sehir" +
                " where Ilan_ArabaID = ArabaID and Araba_VitesTuruID = VitesTuruID and " +
                "Araba_YakitTuruID = YakitTuruID and Araba_RenkID = RenkID and Ilan_SehirID = SehirID", baglanti);
            MySqlDataReader okuFiltreler = yolFiltreler.ExecuteReader();

            while (okuFiltreler.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = okuFiltreler["IlanID"].ToString();
                ekle.SubItems.Add(okuFiltreler["Ilan_Adi"].ToString());
                ekle.SubItems.Add(okuFiltreler["Ilan_Fiyat"].ToString());
                ekle.SubItems.Add(okuFiltreler["Ilan_Km"].ToString());
                ekle.SubItems.Add(okuFiltreler["Ilan_Tarih"].ToString());
                ekle.SubItems.Add(okuFiltreler["Araba_Marka"].ToString());
                ekle.SubItems.Add(okuFiltreler["Araba_Model"].ToString());
                ekle.SubItems.Add(okuFiltreler["Vites_Turu"].ToString());
                ekle.SubItems.Add(okuFiltreler["Yakit_Turu"].ToString());
                ekle.SubItems.Add(okuFiltreler["Renk"].ToString());
                ekle.SubItems.Add(okuFiltreler["Sehir"].ToString());
                listViewFiltrelenmisIlanlar.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void textBoxIlanKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxIlanFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnIlanEkle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                string selectedAraba = comboBoxIlanAraba.Text.ToString();
                string selectedSehir = comboBoxIlanSehir.Text.ToString();

                int arabaID = 0;
                int sehirID = 0;
                int vtID = 0;
                int ytID = 0;
                int renkID = 0;
                string ayrac = "->";
                string[] parcalar = selectedAraba.Split(new[] { ayrac }, StringSplitOptions.None);
                string ayrac2 = " ";
                string[] parcalar2 = dateTimePickerIlan.Value.ToString().Split(new[] { ayrac2 }, StringSplitOptions.None);
                string ayrac3 = ".";
                string[] parcalar3 = parcalar2[0].Split(new[] { ayrac3 }, StringSplitOptions.None);
                string ilanTarihi = parcalar3[2] + "-" + parcalar3[1] + "-" + parcalar3[0] + " " + parcalar2[1];

                baglanti.Open();

                MySqlCommand selectedArabaVTIDYol = new MySqlCommand("SELECT VitesTuruID FROM tbl_vitesturu where Vites_Turu = '" + parcalar[2] + "'", baglanti);
                vtID = Convert.ToInt32(selectedArabaVTIDYol.ExecuteScalar());

                MySqlCommand selectedArabaYTIDYol = new MySqlCommand("SELECT YakitTuruID FROM tbl_yakitturu where Yakit_Turu = '" + parcalar[3] + "'", baglanti);
                ytID = Convert.ToInt32(selectedArabaYTIDYol.ExecuteScalar());

                MySqlCommand selectedArabaRenkIDYol = new MySqlCommand("SELECT RenkID FROM tbl_renk where Renk = '" + parcalar[4] + "'", baglanti);
                renkID = Convert.ToInt32(selectedArabaRenkIDYol.ExecuteScalar());

                MySqlCommand selectedArabaYol = new MySqlCommand("SELECT ArabaID FROM tbl_araba where" +
                    " Araba_Marka = '" + parcalar[0] + "' and Araba_Model = '" + parcalar[1] + "' and " +
                    "Araba_VitesTuruID = '" + vtID + "' and Araba_YakitTuruID = '" + ytID + "' and " +
                    "Araba_RenkID = '" + renkID + "'", baglanti);
                arabaID = Convert.ToInt32(selectedArabaYol.ExecuteScalar());

                MySqlCommand selectedSehirYol = new MySqlCommand("SELECT SehirID FROM tbl_sehir where Sehir = '" + selectedSehir + "'", baglanti);
                sehirID = Convert.ToInt32(selectedSehirYol.ExecuteScalar());              

                MySqlCommand yol = new MySqlCommand("insert into tbl_ilan (Ilan_Adi,Ilan_Fiyat,Ilan_Km,Ilan_Tarih," +
                    "Ilan_ArabaID,Ilan_SehirID)values('" + textBoxIlanAdi.Text.ToString() + "','" + textBoxIlanFiyati.Text.ToString() + "'," +
                    "'" + textBoxIlanKm.Text + "','" + ilanTarihi + "','" + arabaID + "'," +
                    "'" + sehirID + "')", baglanti);

                yol.ExecuteNonQuery();
                baglanti.Close();

                textBoxArabaMarka.Clear();
                textBoxArabaModel.Clear();
                comboBoxVT.SelectedItem = null;
                comboBoxYT.SelectedItem = null;
                comboBoxRenk.SelectedItem = null;

                textBoxIlanAdi.Clear();
                textBoxIlanFiyati.Clear();
                textBoxIlanKm.Clear();
                comboBoxIlanAraba.SelectedItem = null;
                comboBoxIlanSehir.SelectedItem = null;

                textBoxRenk.Clear();
                textBoxSehir.Clear();
                textBoxVitesTuru.Clear();
                textBoxYakitTuru.Clear();

                ilanlariGoster();
                silinecekIlanlariGoster();
                G_ilanlariGoster();
                FiltreleriGoster();
            }
        }

        private void btnArabaEkle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                string selectedRenk = comboBoxRenk.Text.ToString();
                string selectedYT = comboBoxYT.Text.ToString();
                string selectedVT = comboBoxVT.Text.ToString();

                int renkID = 0;
                int ytID = 0;
                int vtID = 0;


                baglanti.Open();
                MySqlCommand selectedRenkYol = new MySqlCommand("SELECT RenkID FROM tbl_renk where Renk = '" + selectedRenk + "'", baglanti);
                renkID = Convert.ToInt32(selectedRenkYol.ExecuteScalar());

                MySqlCommand selectedYTYol = new MySqlCommand("SELECT YakitTuruID FROM tbl_yakitturu where Yakit_Turu = '" + selectedYT + "'", baglanti);
                ytID = Convert.ToInt32(selectedYTYol.ExecuteScalar());

                MySqlCommand selectedVTYol = new MySqlCommand("SELECT VitesTuruID FROM tbl_vitesturu where Vites_Turu = '" + selectedVT + "'", baglanti);
                vtID = Convert.ToInt32(selectedVTYol.ExecuteScalar());

                MySqlCommand yol = new MySqlCommand("insert into tbl_araba (Araba_Marka,Araba_Model," +
                    "Araba_VitesTuruID,Araba_YakitTuruID,Araba_RenkID)values(" +
                    "'" + textBoxArabaMarka.Text.ToString() + "','" + textBoxArabaModel.Text.ToString() + "'," +
                    "'" + vtID + "','" + ytID + "','" + renkID + "')", baglanti);

                yol.ExecuteNonQuery();
                baglanti.Close();

                textBoxArabaMarka.Clear();
                textBoxArabaModel.Clear();
                comboBoxVT.SelectedItem = null;
                comboBoxYT.SelectedItem = null;
                comboBoxRenk.SelectedItem = null;

                textBoxIlanAdi.Clear();
                textBoxIlanFiyati.Clear();
                textBoxIlanKm.Clear();
                comboBoxIlanAraba.SelectedItem = null;
                comboBoxIlanSehir.SelectedItem = null;
                comboBoxIlanAraba.Items.Clear();
                comboBoxIlanAraba_G.Items.Clear();

                textBoxRenk.Clear();
                textBoxSehir.Clear();
                textBoxVitesTuru.Clear();
                textBoxYakitTuru.Clear();

                baglanti.Open();
                MySqlCommand yolAraba = new MySqlCommand("SELECT * FROM tbl_araba, tbl_vitesturu, tbl_yakitturu, tbl_renk" +
                    " where Araba_VitesTuruID = VitesTuruID and Araba_YakitTuruID = YakitTuruID and " +
                    "Araba_RenkID = RenkID;", baglanti);
                MySqlDataReader ArabaOku = yolAraba.ExecuteReader();

                while (ArabaOku.Read())
                {
                    comboBoxIlanAraba.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                        + ArabaOku["Araba_Model"].ToString() + "->"
                        + ArabaOku["Vites_Turu"].ToString() + "->"
                        + ArabaOku["Yakit_Turu"].ToString() + "->"
                        + ArabaOku["Renk"].ToString());

                    comboBoxIlanAraba_G.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                        + ArabaOku["Araba_Model"].ToString() + "->"
                        + ArabaOku["Vites_Turu"].ToString() + "->"
                        + ArabaOku["Yakit_Turu"].ToString() + "->"
                        + ArabaOku["Renk"].ToString());
                }

                baglanti.Close();

                arabalariGoster();
                silinecekArabalariGoster();
                G_arabalariGoster();
                FiltreleriGoster();
            }
        }

        private void btnRenkEkle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("insert into tbl_renk (Renk)values(" +
                    "'" + textBoxRenk.Text.ToString() + "')", baglanti);

                yol.ExecuteNonQuery();
                baglanti.Close();

                textBoxArabaMarka.Clear();
                textBoxArabaModel.Clear();
                comboBoxVT.SelectedItem = null;
                comboBoxYT.SelectedItem = null;
                comboBoxRenk.SelectedItem = null;

                textBoxIlanAdi.Clear();
                textBoxIlanFiyati.Clear();
                textBoxIlanKm.Clear();
                comboBoxIlanAraba.SelectedItem = null;
                comboBoxIlanSehir.SelectedItem = null;
                comboBoxRenk.Items.Clear();
                comboBoxRenk_G.Items.Clear();
                comboBoxRenk_F.Items.Clear();

                textBoxRenk.Clear();
                textBoxSehir.Clear();
                textBoxVitesTuru.Clear();
                textBoxYakitTuru.Clear();

                baglanti.Open();
                MySqlCommand yolRenk = new MySqlCommand("SELECT * FROM tbl_renk;", baglanti);
                MySqlDataReader renkOku = yolRenk.ExecuteReader();

                while (renkOku.Read())
                {
                    comboBoxRenk.Items.Add(renkOku["Renk"].ToString());
                    comboBoxRenk_G.Items.Add(renkOku["Renk"].ToString());
                    comboBoxRenk_F.Items.Add(renkOku["Renk"].ToString());
                }
                baglanti.Close();

                renkleriGoster();
                silRenkleriGoster();
                G_renkleriGoster();
                FiltreleriGoster();
            }
        }

        private void btnSehirEkle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("insert into tbl_sehir (Sehir)values('" + textBoxSehir.Text.ToString() + "')", baglanti);

                yol.ExecuteNonQuery();
                baglanti.Close();

                textBoxArabaMarka.Clear();
                textBoxArabaModel.Clear();
                comboBoxVT.SelectedItem = null;
                comboBoxYT.SelectedItem = null;
                comboBoxRenk.SelectedItem = null;

                textBoxIlanAdi.Clear();
                textBoxIlanFiyati.Clear();
                textBoxIlanKm.Clear();
                comboBoxIlanAraba.SelectedItem = null;
                comboBoxIlanSehir.SelectedItem = null;
                comboBoxIlanSehir.Items.Clear();
                comboBoxIlanSehir_G.Items.Clear();
                comboBoxSehir_F.Items.Clear();

                textBoxRenk.Clear();
                textBoxSehir.Clear();
                textBoxVitesTuru.Clear();
                textBoxYakitTuru.Clear();

                baglanti.Open();
                MySqlCommand yolSehir = new MySqlCommand("SELECT * FROM tbl_sehir;", baglanti);
                MySqlDataReader sehirOku = yolSehir.ExecuteReader();

                while (sehirOku.Read())
                {
                    comboBoxIlanSehir.Items.Add(sehirOku["Sehir"].ToString());
                    comboBoxIlanSehir_G.Items.Add(sehirOku["Sehir"].ToString());
                    comboBoxSehir_F.Items.Add(sehirOku["Sehir"].ToString());
                }
                baglanti.Close();

                sehirleriGoster();
                silinecekSehirleriGoster();
                G_sehirleriGoster();
                FiltreleriGoster();
            }
        }

        private void btnVitesTuruEkle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("insert into tbl_vitesturu (Vites_Turu)values(" +
                    "'" + textBoxVitesTuru.Text.ToString() + "')", baglanti);

                yol.ExecuteNonQuery();
                baglanti.Close();

                textBoxArabaMarka.Clear();
                textBoxArabaModel.Clear();
                comboBoxVT.SelectedItem = null;
                comboBoxYT.SelectedItem = null;
                comboBoxRenk.SelectedItem = null;

                textBoxIlanAdi.Clear();
                textBoxIlanFiyati.Clear();
                textBoxIlanKm.Clear();
                comboBoxIlanAraba.SelectedItem = null;
                comboBoxIlanSehir.SelectedItem = null;
                comboBoxVT.Items.Clear();
                comboBoxVT_G.Items.Clear();
                comboBoxVT_F.Items.Clear();

                textBoxRenk.Clear();
                textBoxSehir.Clear();
                textBoxVitesTuru.Clear();
                textBoxYakitTuru.Clear();

                baglanti.Open();
                MySqlCommand yolVitesTuru = new MySqlCommand("SELECT * FROM tbl_vitesturu;", baglanti);
                MySqlDataReader vitesTuruOku = yolVitesTuru.ExecuteReader();

                while (vitesTuruOku.Read())
                {
                    comboBoxVT.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                    comboBoxVT_G.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                    comboBoxVT_F.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                }
                baglanti.Close();

                vitesTurleriniGoster();
                silVitesTurleriniGoster();
                G_VT_Goster();
                FiltreleriGoster();
            }
        }

        private void btnYakitTuruEkle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("insert into tbl_yakitturu (Yakit_Turu)values(" +
                    "'" + textBoxYakitTuru.Text.ToString() + "')", baglanti);

                yol.ExecuteNonQuery();
                baglanti.Close();

                textBoxArabaMarka.Clear();
                textBoxArabaModel.Clear();
                comboBoxVT.SelectedItem = null;
                comboBoxYT.SelectedItem = null;
                comboBoxRenk.SelectedItem = null;

                textBoxIlanAdi.Clear();
                textBoxIlanFiyati.Clear();
                textBoxIlanKm.Clear();
                comboBoxIlanAraba.SelectedItem = null;
                comboBoxIlanSehir.SelectedItem = null;
                comboBoxYT.Items.Clear();
                comboBoxYT_G.Items.Clear();
                comboBoxYT_F.Items.Clear();

                textBoxRenk.Clear();
                textBoxSehir.Clear();
                textBoxVitesTuru.Clear();
                textBoxYakitTuru.Clear();

                baglanti.Open();
                MySqlCommand yolYakitTuru = new MySqlCommand("SELECT * FROM tbl_yakitturu;", baglanti);
                MySqlDataReader yakitTuruOku = yolYakitTuru.ExecuteReader();

                while (yakitTuruOku.Read())
                {
                    comboBoxYT.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                    comboBoxYT_G.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                    comboBoxYT_F.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                }
                baglanti.Close();

                yakitTurleriniGoster();
                silYakitTurleriniGoster();
                G_YT_Goster();
                FiltreleriGoster();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CB_Doldur();
            sehirleriGoster();
            ilanlariGoster();
            arabalariGoster();
            yakitTurleriniGoster();
            vitesTurleriniGoster();
            renkleriGoster();
            silinecekIlanlariGoster();
            silinecekSehirleriGoster();
            silinecekArabalariGoster();
            silYakitTurleriniGoster();
            silVitesTurleriniGoster();
            silRenkleriGoster();
            G_sehirleriGoster();
            G_ilanlariGoster();
            G_arabalariGoster();
            G_renkleriGoster();
            G_VT_Goster();
            G_YT_Goster();
            FiltreleriGoster();
            comboBoxMarka_F.SelectedIndex = 0;
            comboBoxSehir_F.SelectedIndex = 0;
            comboBoxRenk_F.SelectedIndex = 0;
            comboBoxVT_F.SelectedIndex = 0;
            comboBoxYT_F.SelectedIndex = 0;
            comboBoxIlanTarihi_F.SelectedIndex = 0;
        }

        private void listViewIlanSilList_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewIlanSilList.SelectedItems[0].SubItems[0].Text);
        }

        private void btnIlanSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("Delete from tbl_ilan where IlanID = '" + kod + "' ", baglanti);
                yol.ExecuteNonQuery();
                baglanti.Close();

                silinecekIlanlariGoster();
                ilanlariGoster();
                G_ilanlariGoster();
                FiltreleriGoster();
            }
        }

        private void listViewYakitTuruSilList_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewYakitTuruSilList.SelectedItems[0].SubItems[0].Text);
        }

        private void btnYakitTuruSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("Delete from tbl_yakitturu where YakitTuruID = '" + kod + "' ", baglanti);
                yol.ExecuteNonQuery();
                baglanti.Close();

                comboBoxYT.Items.Clear();
                comboBoxYT_G.Items.Clear();
                comboBoxYT_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolYakitTuru = new MySqlCommand("SELECT * FROM tbl_yakitturu;", baglanti);
                MySqlDataReader yakitTuruOku = yolYakitTuru.ExecuteReader();

                while (yakitTuruOku.Read())
                {
                    comboBoxYT.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                    comboBoxYT_G.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                    comboBoxYT_F.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                }
                baglanti.Close();

                yakitTurleriniGoster();
                silYakitTurleriniGoster();
                G_YT_Goster();
                FiltreleriGoster();
            }
        }

        private void btnVitesTuruSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("Delete from tbl_vitesturu where VitesTuruID = '" + kod + "' ", baglanti);
                yol.ExecuteNonQuery();
                baglanti.Close();

                comboBoxVT.Items.Clear();
                comboBoxVT_G.Items.Clear();
                comboBoxVT_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolVitesTuru = new MySqlCommand("SELECT * FROM tbl_vitesturu;", baglanti);
                MySqlDataReader vitesTuruOku = yolVitesTuru.ExecuteReader();

                while (vitesTuruOku.Read())
                {
                    comboBoxVT.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                    comboBoxVT_G.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                    comboBoxVT_F.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                }
                baglanti.Close();

                silVitesTurleriniGoster();
                vitesTurleriniGoster();
                G_VT_Goster();
            }
        }

        private void listViewVitesTuruSilList_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewVitesTuruSilList.SelectedItems[0].SubItems[0].Text);
        }

        private void btnRenkSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("Delete from tbl_renk where RenkID = '" + kod + "' ", baglanti);
                yol.ExecuteNonQuery();
                baglanti.Close();

                comboBoxRenk.Items.Clear();
                comboBoxRenk_G.Items.Clear();
                comboBoxRenk_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolRenk = new MySqlCommand("SELECT * FROM tbl_renk;", baglanti);
                MySqlDataReader renkOku = yolRenk.ExecuteReader();

                while (renkOku.Read())
                {
                    comboBoxRenk.Items.Add(renkOku["Renk"].ToString());
                    comboBoxRenk_G.Items.Add(renkOku["Renk"].ToString());
                    comboBoxRenk_F.Items.Add(renkOku["Renk"].ToString());
                }
                baglanti.Close();

                silRenkleriGoster();
                renkleriGoster();
                G_renkleriGoster();
                FiltreleriGoster();
            }
        }

        private void listViewRenkSilList_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewRenkSilList.SelectedItems[0].SubItems[0].Text);
        }

        private void listViewSehirSilList_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewSehirSilList.SelectedItems[0].SubItems[0].Text);
        }

        private void btnSehirSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("Delete from tbl_sehir where SehirID = '" + kod + "' ", baglanti);
                yol.ExecuteNonQuery();
                baglanti.Close();

                comboBoxIlanSehir.Items.Clear();
                comboBoxIlanSehir_G.Items.Clear();
                comboBoxSehir_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolSehir = new MySqlCommand("SELECT * FROM tbl_sehir;", baglanti);
                MySqlDataReader sehirOku = yolSehir.ExecuteReader();

                while (sehirOku.Read())
                {
                    comboBoxIlanSehir.Items.Add(sehirOku["Sehir"].ToString());
                    comboBoxIlanSehir_G.Items.Add(sehirOku["Sehir"].ToString());
                    comboBoxSehir_F.Items.Add(sehirOku["Sehir"].ToString());
                }
                baglanti.Close();

                silinecekSehirleriGoster();
                sehirleriGoster();
                G_sehirleriGoster();
                FiltreleriGoster();
            }
        }

        private void btnArabaSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi silmek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                MySqlCommand yol = new MySqlCommand("Delete from tbl_araba where ArabaID = '" + kod + "' ", baglanti);
                yol.ExecuteNonQuery();
                baglanti.Close();

                comboBoxIlanAraba.Items.Clear();
                comboBoxIlanAraba_G.Items.Clear();

                baglanti.Open();
                MySqlCommand yolAraba = new MySqlCommand("SELECT * FROM tbl_araba, tbl_vitesturu, tbl_yakitturu, tbl_renk" +
                    " where Araba_VitesTuruID = VitesTuruID and Araba_YakitTuruID = YakitTuruID and " +
                    "Araba_RenkID = RenkID;", baglanti);
                MySqlDataReader ArabaOku = yolAraba.ExecuteReader();

                while (ArabaOku.Read())
                {
                    comboBoxIlanAraba.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                        + ArabaOku["Araba_Model"].ToString() + "->"
                        + ArabaOku["Vites_Turu"].ToString() + "->"
                        + ArabaOku["Yakit_Turu"].ToString() + "->"
                        + ArabaOku["Renk"].ToString());

                    comboBoxIlanAraba_G.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                        + ArabaOku["Araba_Model"].ToString() + "->"
                        + ArabaOku["Vites_Turu"].ToString() + "->"
                        + ArabaOku["Yakit_Turu"].ToString() + "->"
                        + ArabaOku["Renk"].ToString());
                }

                baglanti.Close();

                silinecekArabalariGoster();
                arabalariGoster();
                G_arabalariGoster();
                FiltreleriGoster();
            }
        }

        private void listViewArabaSilList_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewArabaSilList.SelectedItems[0].SubItems[0].Text);
        }

        private void textBoxIlanKmSil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxIlanFiyatSil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_Ilan_G_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                string selectedAraba = comboBoxIlanAraba_G.Text.ToString();
                string selectedSehir = comboBoxIlanSehir_G.Text.ToString();

                int G_arabaID = 0;
                int vtID = 0;
                int ytID = 0;
                int renkID = 0;
                int G_sehirID = 0;
                string ayrac = "->";
                string[] parcalar = selectedAraba.Split(new[] { ayrac }, StringSplitOptions.None);
                string ayrac2 = " ";
                string[] parcalar2 = dateTimePickerIlanTarihi_G.Value.ToString().Split(new[] { ayrac2 }, StringSplitOptions.None);
                string ayrac3 = ".";
                string[] parcalar3 = parcalar2[0].Split(new[] { ayrac3 }, StringSplitOptions.None);
                string ilanTarihi_G = parcalar3[2] + "-" + parcalar3[1] + "-" + parcalar3[0] + " " + parcalar2[1];

                baglanti.Open();

                MySqlCommand selectedArabaVTIDYol = new MySqlCommand("SELECT VitesTuruID FROM tbl_vitesturu where Vites_Turu = '" + parcalar[2] + "'", baglanti);
                vtID = Convert.ToInt32(selectedArabaVTIDYol.ExecuteScalar());

                MySqlCommand selectedArabaYTIDYol = new MySqlCommand("SELECT YakitTuruID FROM tbl_yakitturu where Yakit_Turu = '" + parcalar[3] + "'", baglanti);
                ytID = Convert.ToInt32(selectedArabaYTIDYol.ExecuteScalar());

                MySqlCommand selectedArabaRenkIDYol = new MySqlCommand("SELECT RenkID FROM tbl_renk where Renk = '" + parcalar[4] + "'", baglanti);
                renkID = Convert.ToInt32(selectedArabaRenkIDYol.ExecuteScalar());

                MySqlCommand selectedArabaYol = new MySqlCommand("SELECT ArabaID FROM tbl_araba where" +
                        " Araba_Marka = '" + parcalar[0] + "' and Araba_Model = '" + parcalar[1] + "' and " +
                        "Araba_VitesTuruID = '" + vtID + "' and Araba_YakitTuruID = '" + ytID + "' and " +
                        "Araba_RenkID = '" + renkID + "'", baglanti);
                G_arabaID = Convert.ToInt32(selectedArabaYol.ExecuteScalar());

                MySqlCommand selectedSehirYol = new MySqlCommand("SELECT SehirID FROM tbl_sehir where Sehir = '" + selectedSehir + "'", baglanti);
                G_sehirID = Convert.ToInt32(selectedSehirYol.ExecuteScalar());

                string yol = "update tbl_ilan set Ilan_Adi = @Ilan_Adi ,Ilan_Fiyat = @Ilan_Fiyat," +
                    " Ilan_Km = @Ilan_Km, Ilan_Tarih = @Ilan_Tarih, Ilan_ArabaID = @Ilan_ArabaID," +
                    " Ilan_SehirID = @Ilan_SehirID where IlanID = @IlanID";

                MySqlCommand komut = new MySqlCommand(yol, baglanti);
                komut.Parameters.AddWithValue("IlanID", satirVerileri[0]);
                komut.Parameters.AddWithValue("Ilan_Adi", textBoxIlanAdi_G.Text);
                komut.Parameters.AddWithValue("Ilan_Fiyat", Convert.ToInt32(textBoxIlanFiyati_G.Text));
                komut.Parameters.AddWithValue("Ilan_Km", textBoxIlanKm_G.Text);
                komut.Parameters.AddWithValue("Ilan_Tarih", ilanTarihi_G);
                komut.Parameters.AddWithValue("Ilan_ArabaID", G_arabaID);
                komut.Parameters.AddWithValue("Ilan_SehirID", G_sehirID);

                komut.ExecuteNonQuery();
                baglanti.Close();

                textBoxIlanAdi_G.Clear();
                textBoxIlanFiyati_G.Clear();
                textBoxIlanKm_G.Clear();
                dateTimePickerIlanTarihi_G.Value = System.DateTime.Today;
                comboBoxIlanSehir_G.SelectedItem = null;
                comboBoxIlanAraba_G.SelectedItem = null;

                ilanlariGoster();
                silinecekIlanlariGoster();
                G_ilanlariGoster();
                FiltreleriGoster();
            }
        }

        private void listViewIlan_G_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listViewIlan_G.Columns.Count; i++)
            {
                satirVerileri[i] = (listViewIlan_G.SelectedItems[0].SubItems[i].Text);
            }

            textBoxIlanAdi_G.Text = satirVerileri[1];
            textBoxIlanFiyati_G.Text = satirVerileri[2];
            textBoxIlanKm_G.Text = satirVerileri[3];
            dateTimePickerIlanTarihi_G.Text = satirVerileri[4];

            baglanti.Open();
            MySqlCommand SecYolAraba = new MySqlCommand("SELECT * FROM tbl_araba, tbl_vitesturu, tbl_yakitturu, tbl_renk" +
                " where Araba_VitesTuruID = VitesTuruID and Araba_YakitTuruID = YakitTuruID and " +
                "Araba_RenkID = RenkID and ArabaID = " + Convert.ToInt32(satirVerileri[5]) + ";", baglanti);
            MySqlDataReader SecArabaOku = SecYolAraba.ExecuteReader();

            while (SecArabaOku.Read())
            {
                comboBoxIlanAraba_G.SelectedItem = (SecArabaOku["Araba_Marka"].ToString() + "->"
                    + SecArabaOku["Araba_Model"].ToString() + "->"
                    + SecArabaOku["Vites_Turu"].ToString() + "->"
                    + SecArabaOku["Yakit_Turu"].ToString() + "->"
                    + SecArabaOku["Renk"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            MySqlCommand yolSecilenSehir = new MySqlCommand("SELECT Sehir FROM tbl_sehir where SehirID = '" + satirVerileri[6] + "'", baglanti);
            MySqlDataReader SecSehirOku = yolSecilenSehir.ExecuteReader();

            while (SecSehirOku.Read())
            {
                comboBoxIlanSehir_G.SelectedItem = (SecSehirOku["Sehir"].ToString());
            }

            baglanti.Close();
        }

        private void listViewAraba_G_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listViewAraba_G.Columns.Count; i++)
            {
                satirVerileri[i] = (listViewAraba_G.SelectedItems[0].SubItems[i].Text);
            }

            textBoxMarka_G.Text = satirVerileri[1];
            textBoxModel_G.Text = satirVerileri[2];

            baglanti.Open();
            MySqlCommand yolSecilenArabaVT = new MySqlCommand("SELECT Vites_Turu FROM tbl_vitesturu where VitesTuruID = '" + satirVerileri[3] + "'", baglanti);
            MySqlDataReader SecArabaVTOku = yolSecilenArabaVT.ExecuteReader();

            while (SecArabaVTOku.Read())
            {
                comboBoxVT_G.SelectedItem = (SecArabaVTOku["Vites_Turu"].ToString());
            }

            baglanti.Close();
            //////////////
            baglanti.Open();
            MySqlCommand yolSecilenArabaYT = new MySqlCommand("SELECT Yakit_Turu FROM tbl_yakitturu where YakitTuruID = '" + satirVerileri[4] + "'", baglanti);
            MySqlDataReader SecArabaYTOku = yolSecilenArabaYT.ExecuteReader();

            while (SecArabaYTOku.Read())
            {
                comboBoxYT_G.SelectedItem = (SecArabaYTOku["Yakit_Turu"].ToString());
            }

            baglanti.Close();
            /////////////////////
            baglanti.Open();
            MySqlCommand yolSecilenArabaRenk = new MySqlCommand("SELECT Renk FROM tbl_renk where RenkID = '" + satirVerileri[5] + "'", baglanti);
            MySqlDataReader SecArabaRenkOku = yolSecilenArabaRenk.ExecuteReader();

            while (SecArabaRenkOku.Read())
            {
                comboBoxRenk_G.SelectedItem = (SecArabaRenkOku["Renk"].ToString());
            }

            baglanti.Close();
        }

        private void listViewSehir_G_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewSehir_G.SelectedItems[0].SubItems[0].Text);

            baglanti.Open();
            MySqlCommand yolSecilenSehir = new MySqlCommand("SELECT Sehir FROM tbl_sehir where SehirID = '" + kod + "'", baglanti);
            MySqlDataReader SecSehirOku = yolSecilenSehir.ExecuteReader();

            while (SecSehirOku.Read())
            {
                textBoxSehir_G.Text = (SecSehirOku["Sehir"].ToString());
            }

            baglanti.Close();
        }

        private void listViewYT_G_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewYT_G.SelectedItems[0].SubItems[0].Text);

            baglanti.Open();
            MySqlCommand yolSecilenYT = new MySqlCommand("SELECT Yakit_Turu FROM tbl_yakitturu where YakitTuruID = '" + kod + "'", baglanti);
            MySqlDataReader SecYTOku = yolSecilenYT.ExecuteReader();

            while (SecYTOku.Read())
            {
                textBoxYT_G.Text = (SecYTOku["Yakit_Turu"].ToString());
            }

            baglanti.Close();
        }

        private void listViewVT_G_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewVT_G.SelectedItems[0].SubItems[0].Text);

            baglanti.Open();
            MySqlCommand yolSecilenVT = new MySqlCommand("SELECT Vites_Turu FROM tbl_vitesturu where VitesTuruID = '" + kod + "'", baglanti);
            MySqlDataReader SecVTOku = yolSecilenVT.ExecuteReader();

            while (SecVTOku.Read())
            {
                textBoxVT_G.Text = (SecVTOku["Vites_Turu"].ToString());
            }

            baglanti.Close();
        }

        private void listViewRenk_G_MouseClick(object sender, MouseEventArgs e)
        {
            kod = (listViewRenk_G.SelectedItems[0].SubItems[0].Text);

            baglanti.Open();
            MySqlCommand yolSecilenRenk = new MySqlCommand("SELECT Renk FROM tbl_renk where RenkID = '" + kod + "'", baglanti);
            MySqlDataReader SecRenkOku = yolSecilenRenk.ExecuteReader();

            while (SecRenkOku.Read())
            {
                textBoxRenk_G.Text = (SecRenkOku["Renk"].ToString());
            }

            baglanti.Close();
        }

        private void btn_YT_G_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi güncellemek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                string yol = "update tbl_yakitturu set Yakit_Turu = @Yakit_Turu where YakitTuruID = @YakitTuruID";
                MySqlCommand komut = new MySqlCommand(yol, baglanti);
                komut.Parameters.AddWithValue("Yakit_Turu", textBoxYT_G.Text);
                komut.Parameters.AddWithValue("YakitTuruID", kod);
                komut.ExecuteNonQuery();

                baglanti.Close();

                comboBoxYT.Items.Clear();
                comboBoxYT_G.Items.Clear();
                comboBoxYT_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolYakitTuru = new MySqlCommand("SELECT * FROM tbl_yakitturu;", baglanti);
                MySqlDataReader yakitTuruOku = yolYakitTuru.ExecuteReader();

                while (yakitTuruOku.Read())
                {
                    comboBoxYT.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                    comboBoxYT_G.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                    comboBoxYT_F.Items.Add(yakitTuruOku["Yakit_Turu"].ToString());
                }
                baglanti.Close();

                textBoxYT_G.Clear();

                silYakitTurleriniGoster();
                yakitTurleriniGoster();
                G_YT_Goster();
                FiltreleriGoster();
            }
        }

        private void btn_Araba_G_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                string selectedRenk = comboBoxRenk_G.Text.ToString();
                string selectedYT = comboBoxYT_G.Text.ToString();
                string selectedVT = comboBoxVT_G.Text.ToString();

                int renkID = 0;
                int ytID = 0;
                int vtID = 0;

                baglanti.Open();
                MySqlCommand selectedRenkYol = new MySqlCommand("SELECT RenkID FROM tbl_renk where Renk = '" + selectedRenk + "'", baglanti);
                renkID = Convert.ToInt32(selectedRenkYol.ExecuteScalar());

                MySqlCommand selectedYTYol = new MySqlCommand("SELECT YakitTuruID FROM tbl_yakitturu where Yakit_Turu = '" + selectedYT + "'", baglanti);
                ytID = Convert.ToInt32(selectedYTYol.ExecuteScalar());

                MySqlCommand selectedVTYol = new MySqlCommand("SELECT VitesTuruID FROM tbl_vitesturu where Vites_Turu = '" + selectedVT + "'", baglanti);
                vtID = Convert.ToInt32(selectedVTYol.ExecuteScalar());

                string yol = "update tbl_araba set Araba_Marka = @Araba_Marka ,Araba_Model = @Araba_Model," +
                    " Araba_VitesTuruID = @Araba_VitesTuruID, Araba_YakitTuruID = @Araba_YakitTuruID," +
                    " Araba_RenkID = @Araba_RenkID where ArabaID = @ArabaID";

                MySqlCommand komut = new MySqlCommand(yol, baglanti);
                komut.Parameters.AddWithValue("ArabaID", satirVerileri[0]);
                komut.Parameters.AddWithValue("Araba_Marka", textBoxMarka_G.Text);
                komut.Parameters.AddWithValue("Araba_Model", textBoxModel_G.Text);
                komut.Parameters.AddWithValue("Araba_VitesTuruID", vtID);
                komut.Parameters.AddWithValue("Araba_YakitTuruID", ytID);
                komut.Parameters.AddWithValue("Araba_RenkID", renkID);

                komut.ExecuteNonQuery();
                baglanti.Close();

                textBoxMarka_G.Clear();
                textBoxModel_G.Clear();
                comboBoxVT_G.SelectedItem = null;
                comboBoxYT_G.SelectedItem = null;
                comboBoxRenk_G.SelectedItem = null;

                comboBoxIlanAraba.Items.Clear();
                comboBoxIlanAraba_G.Items.Clear();

                baglanti.Open();
                MySqlCommand yolAraba = new MySqlCommand("SELECT * FROM tbl_araba, tbl_vitesturu, tbl_yakitturu, tbl_renk" +
                    " where Araba_VitesTuruID = VitesTuruID and Araba_YakitTuruID = YakitTuruID and " +
                    "Araba_RenkID = RenkID;", baglanti);
                MySqlDataReader ArabaOku = yolAraba.ExecuteReader();

                while (ArabaOku.Read())
                {
                    comboBoxIlanAraba.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                        + ArabaOku["Araba_Model"].ToString() + "->"
                        + ArabaOku["Vites_Turu"].ToString() + "->"
                        + ArabaOku["Yakit_Turu"].ToString() + "->"
                        + ArabaOku["Renk"].ToString());

                    comboBoxIlanAraba_G.Items.Add(ArabaOku["Araba_Marka"].ToString() + "->"
                        + ArabaOku["Araba_Model"].ToString() + "->"
                        + ArabaOku["Vites_Turu"].ToString() + "->"
                        + ArabaOku["Yakit_Turu"].ToString() + "->"
                        + ArabaOku["Renk"].ToString());
                }

                baglanti.Close();

                arabalariGoster();
                silinecekArabalariGoster();
                G_arabalariGoster();
                FiltreleriGoster();
            }
        }

        private void btn_Sehir_G_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi güncellemek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                string yol = "update tbl_sehir set Sehir = @Sehir where SehirID = @SehirID";
                MySqlCommand komut = new MySqlCommand(yol, baglanti);
                komut.Parameters.AddWithValue("Sehir", textBoxSehir_G.Text);
                komut.Parameters.AddWithValue("SehirID", kod);
                komut.ExecuteNonQuery();

                baglanti.Close();

                comboBoxIlanSehir.Items.Clear();
                comboBoxIlanSehir_G.Items.Clear();
                comboBoxSehir_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolSehir = new MySqlCommand("SELECT * FROM tbl_sehir;", baglanti);
                MySqlDataReader sehirOku = yolSehir.ExecuteReader();

                while (sehirOku.Read())
                {
                    comboBoxIlanSehir.Items.Add(sehirOku["Sehir"].ToString());
                    comboBoxIlanSehir_G.Items.Add(sehirOku["Sehir"].ToString());
                    comboBoxSehir_F.Items.Add(sehirOku["Sehir"].ToString());
                }
                baglanti.Close();

                textBoxSehir_G.Clear();

                sehirleriGoster();
                silinecekSehirleriGoster();
                G_sehirleriGoster();
            }
        }

        private void btn_Renk_G_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi güncellemek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                string yol = "update tbl_renk set Renk = @Renk where RenkID = @RenkID";
                MySqlCommand komut = new MySqlCommand(yol, baglanti);
                komut.Parameters.AddWithValue("Renk", textBoxRenk_G.Text);
                komut.Parameters.AddWithValue("RenkID", kod);
                komut.ExecuteNonQuery();

                baglanti.Close();

                comboBoxRenk.Items.Clear();
                comboBoxRenk_G.Items.Clear();
                comboBoxRenk_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolRenk = new MySqlCommand("SELECT * FROM tbl_renk;", baglanti);
                MySqlDataReader renkOku = yolRenk.ExecuteReader();

                while (renkOku.Read())
                {
                    comboBoxRenk.Items.Add(renkOku["Renk"].ToString());
                    comboBoxRenk_G.Items.Add(renkOku["Renk"].ToString());
                    comboBoxRenk_F.Items.Add(renkOku["Renk"].ToString());
                }
                baglanti.Close();

                textBoxRenk_G.Clear();

                renkleriGoster();
                silRenkleriGoster();
                G_renkleriGoster();
                FiltreleriGoster();
            }
        }

        private void btn_VT_G_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Seçilen veriyi güncellemek istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                baglanti.Open();
                string yol = "update tbl_vitesturu set Vites_Turu = @Vites_Turu where VitesTuruID = @VitesTuruID";
                MySqlCommand komut = new MySqlCommand(yol, baglanti);
                komut.Parameters.AddWithValue("Vites_Turu", textBoxVT_G.Text);
                komut.Parameters.AddWithValue("VitesTuruID", kod);
                komut.ExecuteNonQuery();

                baglanti.Close();

                comboBoxVT.Items.Clear();
                comboBoxVT_G.Items.Clear();
                comboBoxVT_F.Items.Clear();

                baglanti.Open();
                MySqlCommand yolVitesTuru = new MySqlCommand("SELECT * FROM tbl_vitesturu;", baglanti);
                MySqlDataReader vitesTuruOku = yolVitesTuru.ExecuteReader();

                while (vitesTuruOku.Read())
                {
                    comboBoxVT.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                    comboBoxVT_G.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                    comboBoxVT_F.Items.Add(vitesTuruOku["Vites_Turu"].ToString());
                }
                baglanti.Close();

                textBoxVT_G.Clear();

                silVitesTurleriniGoster();
                vitesTurleriniGoster();
                G_VT_Goster();
                FiltreleriGoster();
            }
        }

        private void comboBoxMarka_F_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxModel_F.Items.Clear();
            comboBoxModel_F.Items.Add("Tümü");
            if(comboBoxMarka_F.SelectedIndex == 0)
            {
                label27.Visible = false;
                comboBoxModel_F.Visible = false;
            }
            else
            {
                label27.Visible = true;
                comboBoxModel_F.Visible = true;

                baglanti.Open();
                MySqlCommand yolModeller = new MySqlCommand("SELECT DISTINCT Araba_Model FROM tbl_araba where Araba_Marka = '" + comboBoxMarka_F.Text + "'", baglanti);
                MySqlDataReader ModellerOku = yolModeller.ExecuteReader();

                while (ModellerOku.Read())
                {
                    comboBoxModel_F.Items.Add(ModellerOku["Araba_Model"].ToString());
                }
                baglanti.Close();                
            }
            comboBoxModel_F.SelectedIndex = 0;
        }

        private void btnAramaYap_Click(object sender, EventArgs e)
        {
            listViewFiltrelenmisIlanlar.Items.Clear();
            string ilanAdi_F = "";
            int minFiyat = 0;
            int maxFiyat = int.MaxValue; 
            int minKM = 0;
            int maxKM = int.MaxValue;
            string ilanFiyati_F = "";
            string ilanKM_F = "";
            string ilanTarihi_F = "";
            string marka_F = "";
            string model_F = "";
            string VT_F = "";
            string YT_F = "";
            string renk_F = "";
            string sehir_F = "";
            string anlikTarih = DateTime.Now.ToString();
            string dun = DateTime.Now.AddDays(-1).ToString();
            string gecenHafta = DateTime.Now.AddDays(-7).ToString();
            string gecenAy = DateTime.Now.AddMonths(-1).ToString();
            string ayrac2 = " ";
            string[] parcalar2 = anlikTarih.Split(new[] { ayrac2 }, StringSplitOptions.None);
            string ayrac3 = ".";
            string[] parcalar3 = parcalar2[0].Split(new[] { ayrac3 }, StringSplitOptions.None);
            string[] parcalar4 = dun.Split(new[] { ayrac2 }, StringSplitOptions.None);
            string[] parcalar5 = parcalar4[0].Split(new[] { ayrac3 }, StringSplitOptions.None);
            string[] parcalar6 = gecenHafta.Split(new[] { ayrac2 }, StringSplitOptions.None);
            string[] parcalar7 = parcalar6[0].Split(new[] { ayrac3 }, StringSplitOptions.None);
            string[] parcalar8 = gecenAy.Split(new[] { ayrac2 }, StringSplitOptions.None);
            string[] parcalar9 = parcalar8[0].Split(new[] { ayrac3 }, StringSplitOptions.None);
            string bugunVT = "'" + parcalar3[2] + "-" + parcalar3[1] + "-" + parcalar3[0] + " " + parcalar2[1] + "'";
            string dunVT = "'" + parcalar5[2] + "-" + parcalar5[1] + "-" + parcalar5[0] + " " + parcalar4[1] + "'";
            string gecenHaftaVT = "'" + parcalar7[2] + "-" + parcalar7[1] + "-" + parcalar7[0] + " " + parcalar6[1] + "'";
            string gecenAyVT = "'" + parcalar9[2] + "-" + parcalar9[1] + "-" + parcalar9[0] + " " + parcalar8[1] + "'";
            if (textBoxIlanAdi_F.Text != "")
            {
                ilanAdi_F = "and Ilan_Adi = '" + textBoxIlanAdi_F.Text + "'";
            }
            if (comboBoxMarka_F.Text != "Tümü")
            {
                marka_F = "and Araba_Marka = '" + comboBoxMarka_F.Text + "'";
            }
            if (comboBoxModel_F.Text != "Tümü")
            {
                model_F = "and Araba_Model = '" + comboBoxModel_F.Text + "'";
            }
            if (comboBoxSehir_F.Text != "Tümü")
            {
                sehir_F = "and Sehir = '" + comboBoxSehir_F.Text + "'";
            }
            if (comboBoxVT_F.Text != "Tümü")
            {
                VT_F = "and Vites_Turu = '" + comboBoxVT_F.Text + "'";
            }
            if (comboBoxYT_F.Text != "Tümü")
            {
                YT_F = "and Yakit_Turu = '" + comboBoxYT_F.Text + "'";
            }
            if (comboBoxRenk_F.Text != "Tümü")
            {
                renk_F = "and Renk = '" + comboBoxRenk_F.Text + "'";
            }
            if (textBoxMinFiyat.Text != "Min" )
            {
                minFiyat = Convert.ToInt32(textBoxMinFiyat.Text);
            }
            if (textBoxMaxFiyat.Text != "Max")
            {
                maxFiyat = Convert.ToInt32(textBoxMaxFiyat.Text);
            }
            if (textBoxMinKM.Text != "Min")
            {
                minKM = Convert.ToInt32(textBoxMinKM.Text);
            }
            if (textBoxMaxKM.Text != "Max")
            {
                maxKM = Convert.ToInt32(textBoxMaxKM.Text);
            }
            ilanFiyati_F = "and Ilan_Fiyat between " + minFiyat + " and " + maxFiyat + "";
            ilanKM_F = "and Ilan_Km between " + minKM + " and " + maxKM + "";
            if(comboBoxIlanTarihi_F.Text == "Son 24 saat")
            {
                ilanTarihi_F = "and Ilan_Tarih between " + dunVT + " and " + bugunVT + "";
            }
            if (comboBoxIlanTarihi_F.Text == "Son 1 hafta")
            {
                ilanTarihi_F = "and Ilan_Tarih between " + gecenHaftaVT + " and " + bugunVT + "";
            }
            if (comboBoxIlanTarihi_F.Text == "Son 1 ay")
            {
                ilanTarihi_F = "and Ilan_Tarih between " + gecenAyVT + " and " + bugunVT + "";
            }

            baglanti.Open();
            MySqlCommand yolFiltreler = new MySqlCommand("select IlanID, Ilan_Adi, Ilan_Fiyat, Ilan_Km," +
                " Ilan_Tarih, Araba_Marka, Araba_Model, Vites_Turu, Yakit_Turu, Renk, Sehir " +
                "from tbl_ilan, tbl_araba, tbl_vitesturu, tbl_yakitturu, tbl_renk, tbl_sehir" +
                " where Ilan_ArabaID = ArabaID and Araba_VitesTuruID = VitesTuruID and " +
                "Araba_YakitTuruID = YakitTuruID and Araba_RenkID = RenkID and Ilan_SehirID = SehirID" +
                " " + ilanAdi_F + " " + marka_F + " " + model_F + " " + VT_F + " " + YT_F + " " + renk_F + " " + sehir_F + " " + ilanFiyati_F + " " + ilanKM_F + " " + ilanTarihi_F + " order by IlanID", baglanti);
            MySqlDataReader okuFiltreler = yolFiltreler.ExecuteReader();

            while (okuFiltreler.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = okuFiltreler["IlanID"].ToString();
                ekle.SubItems.Add(okuFiltreler["Ilan_Adi"].ToString());
                ekle.SubItems.Add(okuFiltreler["Ilan_Fiyat"].ToString());
                ekle.SubItems.Add(okuFiltreler["Ilan_Km"].ToString());
                ekle.SubItems.Add(okuFiltreler["Ilan_Tarih"].ToString());
                ekle.SubItems.Add(okuFiltreler["Araba_Marka"].ToString());
                ekle.SubItems.Add(okuFiltreler["Araba_Model"].ToString());
                ekle.SubItems.Add(okuFiltreler["Vites_Turu"].ToString());
                ekle.SubItems.Add(okuFiltreler["Yakit_Turu"].ToString());
                ekle.SubItems.Add(okuFiltreler["Renk"].ToString());
                ekle.SubItems.Add(okuFiltreler["Sehir"].ToString());
                listViewFiltrelenmisIlanlar.Items.Add(ekle);
            }
            baglanti.Close();

            listViewFiltrelenmisIlanlar.Sort();
        }

        private void textBoxIlanFiyati_G_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxIlanKm_G_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxMinFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxMaxFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxMinKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxMaxKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxMinFiyat_Enter(object sender, EventArgs e)
        {
            if (textBoxMinFiyat.Text == "Min")
            {
                textBoxMinFiyat.Text = "";
                textBoxMinFiyat.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxMinFiyat_Leave(object sender, EventArgs e)
        {
            if (textBoxMinFiyat.Text == "")
            {
                textBoxMinFiyat.Text = "Min";
                textBoxMinFiyat.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void textBoxMaxFiyat_Enter(object sender, EventArgs e)
        {
            if (textBoxMaxFiyat.Text == "Max")
            {
                textBoxMaxFiyat.Text = "";
                textBoxMaxFiyat.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxMaxFiyat_Leave(object sender, EventArgs e)
        {
            if (textBoxMaxFiyat.Text == "")
            {
                textBoxMaxFiyat.Text = "Max";
                textBoxMaxFiyat.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void textBoxMinKM_Enter(object sender, EventArgs e)
        {
            if (textBoxMinKM.Text == "Min")
            {
                textBoxMinKM.Text = "";
                textBoxMinKM.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxMinKM_Leave(object sender, EventArgs e)
        {
            if (textBoxMinKM.Text == "")
            {
                textBoxMinKM.Text = "Min";
                textBoxMinKM.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void textBoxMaxKM_Enter(object sender, EventArgs e)
        {
            if (textBoxMaxKM.Text == "Max")
            {
                textBoxMaxKM.Text = "";
                textBoxMaxKM.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBoxMaxKM_Leave(object sender, EventArgs e)
        {
            if (textBoxMaxKM.Text == "")
            {
                textBoxMaxKM.Text = "Max";
                textBoxMaxKM.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void listViewFiltrelenmisIlanlar_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Siralama sira = listViewFiltrelenmisIlanlar.ListViewItemSorter as Siralama;

            if (sira == null)
            {
                sira = new Siralama(e.Column);
                sira.Order = SortOrder.Ascending;
                listViewFiltrelenmisIlanlar.ListViewItemSorter = sira;
            }

            if (e.Column == sira.Column)
            {
                if (sira.Order == SortOrder.Ascending)
                    sira.Order = SortOrder.Descending;
                else
                    sira.Order = SortOrder.Ascending;
            }
            else
            {
                sira.Column = e.Column;
                sira.Order = SortOrder.Ascending;
            }
            listViewFiltrelenmisIlanlar.Sort();
        }

        private void btnSıfırla_Click(object sender, EventArgs e)
        {
            textBoxIlanAdi_F.Clear();
            comboBoxMarka_F.SelectedItem = 1;
            comboBoxModel_F.SelectedItem = 1;
            comboBoxSehir_F.SelectedItem = 1;
            comboBoxVT_F.SelectedItem = 1;
            comboBoxYT_F.SelectedItem = 1;
            comboBoxRenk_F.SelectedItem = 1;
            comboBoxIlanTarihi_F.SelectedItem = 1;

            textBoxMinFiyat.Text = "Min";
            textBoxMaxFiyat.Text = "Max";
            textBoxMinKM.Text = "Min";
            textBoxMaxKM.Text = "Max";

            FiltreleriGoster();
        }

        private void comboBoxKayitSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxKayitSecim.SelectedIndex == 0)
            {
                groupBoxIlan.Enabled = true;
            }
            else
                groupBoxIlan.Enabled = false;
            if (comboBoxKayitSecim.SelectedIndex == 1)
            {
                groupBoxAraba.Enabled = true;
            }
            else
                groupBoxAraba.Enabled = false;
            if (comboBoxKayitSecim.SelectedIndex == 2)
            {
                groupBoxVitesTuru.Enabled = true;
            }
            else
                groupBoxVitesTuru.Enabled = false;
            if (comboBoxKayitSecim.SelectedIndex == 3)
            {
                groupBoxYakitTuru.Enabled = true;
            }
            else
                groupBoxYakitTuru.Enabled = false;
            if (comboBoxKayitSecim.SelectedIndex == 4)
            {
                groupBoxRenk.Enabled = true;
            }
            else
                groupBoxRenk.Enabled = false;
            if (comboBoxKayitSecim.SelectedIndex == 5)
            {
                groupBoxSehir.Enabled = true;
            }
            else
                groupBoxSehir.Enabled = false;
        }

        private void comboBoxGuncellemeSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGuncellemeSecim.SelectedIndex == 0)
            {
                groupBoxIlan_G.Enabled = true;
                listViewIlan_G.Enabled = true;
            }
            else
            {
                groupBoxIlan_G.Enabled = false;
                listViewIlan_G.Enabled = false;
            }
                
            if (comboBoxGuncellemeSecim.SelectedIndex == 1)
            {
                groupBoxAraba_G.Enabled = true;
                listViewAraba_G.Enabled = true;
            }
            else
            {
                groupBoxAraba_G.Enabled = false;
                listViewAraba_G.Enabled = false;
            }
                
            if (comboBoxGuncellemeSecim.SelectedIndex == 2)
            {
                groupBoxVT_G.Enabled = true;
                listViewVT_G.Enabled = true;
            }
            else
            {
                groupBoxVT_G.Enabled = false;
                listViewVT_G.Enabled = false;
            }
                
            if (comboBoxGuncellemeSecim.SelectedIndex == 3)
            {
                groupBoxYT_G.Enabled = true;
                listViewYT_G.Enabled = true;
            }
            else
            {
                groupBoxYT_G.Enabled = false;
                listViewYT_G.Enabled = false;
            }
                
            if (comboBoxGuncellemeSecim.SelectedIndex == 4)
            {
                groupBoxRenk_G.Enabled = true;
                listViewRenk_G.Enabled = true;
            }
            else
            {
                groupBoxRenk_G.Enabled = false;
                listViewRenk_G.Enabled = false;
            }
                
            if (comboBoxGuncellemeSecim.SelectedIndex == 5)
            {
                groupBoxSehir_G.Enabled = true;
                listViewSehir_G.Enabled = true;
            }
            else
            {
                groupBoxSehir_G.Enabled = false;
                listViewSehir_G.Enabled = false;
            }              
        }

        private void comboBoxSilmeSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSilmeSecim.SelectedIndex == 0)
            {
                groupBox1.Enabled = true;
            }
            else
                groupBox1.Enabled = false;
            if (comboBoxSilmeSecim.SelectedIndex == 1)
            {
                groupBox2.Enabled = true;
            }
            else
                groupBox2.Enabled = false;
            if (comboBoxSilmeSecim.SelectedIndex == 2)
            {
                groupBox5.Enabled = true;
            }
            else
                groupBox5.Enabled = false;
            if (comboBoxSilmeSecim.SelectedIndex == 3)
            {
                groupBox6.Enabled = true;
            }
            else
                groupBox6.Enabled = false;
            if (comboBoxSilmeSecim.SelectedIndex == 4)
            {
                groupBox4.Enabled = true;
            }
            else
                groupBox4.Enabled = false;
            if (comboBoxSilmeSecim.SelectedIndex == 5)
            {
                groupBox3.Enabled = true;
            }
            else
                groupBox3.Enabled = false;
        }
    }
}
