namespace ЦАД2
{
    public partial class Form1 : Form
    {
        const string connectionString =
           "USER ID = irasskazov; PASSWORD=GTHTGENMT8LJHJ; PERSIST SECURITY INFO=True; Data Source=10.20.25.231:1521/lim.tula.ffoms.ru;";
        readonly ViewFile[] viewFiles = {
            new(TypeFile.Else, "'H'", "serv.act_type12 not in (78968458, 78968472, 78968451, 78968465, 825477748, 78968430, 78968493, 166958421,78968438) and substr(r.servicecode,0,3) not in ('20V', '9V-','1V-','2V-') and substr(a.maindiagnosis,0,1) != 'C' and substr(a.maindiagnosis,2) != 'D0' and a.ds_onk != 1", "3.1", "'-'"),
            new(TypeFile.VMP,  "'T'", "a.conditid in (0101, 0201) and substr(r.servicecode,0,3) in ('20V', '9V-','1V-','2V-')", "3.1", "'-'"),
            new(TypeFile.DVN, "'DP'", "a.conditid in (0301) and a.medicalexam is not null and substr(r.servicecode,0,2) = 'DV' and substr(r.servicecode,3,1) != 'U'", "3.2", "'ДВ4'"),
            new(TypeFile.DVN, "'DO'", "a.conditid in (0301) and a.medicalexam is not null and substr(r.servicecode,0,2) = 'PV'", "3.2", "'ОПВ'"),
            new(TypeFile.DVN, "'DS'", "a.conditid in (0301) and a.medicalexam is not null and substr(r.servicecode,0,2) = 'DD' and p.statepatient = 10", "3.2", "'ДС1'"),
            new(TypeFile.DVN, "'DU'", "a.conditid in (0301) and a.medicalexam is not null and substr(r.servicecode,0,2) = 'DD' and p.statepatient = 11", "3.2", "'ДС2'"),
            new(TypeFile.DVN, "'DF'", "a.conditid in (0301) and a.medicalexam is not null and substr(r.servicecode,0,2) = 'PD'", "3.2", "'ПН1'"),
            new(TypeFile.DVN, "'DA'", "a.conditid in (0301) and a.medicalexam is not null and substr(r.servicecode,0,3) = 'DVU'", "3.2", "'УД1'"),
            new(TypeFile.DVN, "'DV'", "a.conditid in (0301) and a.medicalexam is not null and serv.act_type12 in (166958421)", "3.2", "'ДВ2'"),
            new(TypeFile.DVN, "'DB'", "a.conditid in (0301) and a.medicalexam is not null and serv.act_type12 in (825477748) and substr(r.servicecode,0,3) != 'DVU'", "3.2", "'УД2'"),
            new(TypeFile.ONK, "'C'", "(substr(a.maindiagnosis,0,1) = 'C' or a.maindiagnosis between 'D00' and 'D09' or a.ds_onk = 1) and substr(r.servicecode,0,3) not in ('20V', '9V-','1V-','2V-')", "3.1", "'-'")};
        

        public Form1()
        {
            InitializeComponent();
            textBox3.Text = DateTime.Now.Year.ToString();
            textBox1.Text = textBox2.Text = string.Format("{0:00}", DateTime.Now.Month - 1);
            textBox4.Text = DateTime.Now.Year.ToString() + "-" + string.Format("{0:00}", DateTime.Now.Month) + "-" + string.Format("{0:00}", DateTime.Now.Day);
            textBox5.Text = "1";
            radioButton1.Checked = true;
            label7.Visible = false;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            //button1.Enabled = false;
            List<ViewFile> viewFilesList = new List<ViewFile>();
            RadioButton? radioBtn = this.groupBox1.Controls.OfType<RadioButton>()
                                        .Where(x => x.Checked).FirstOrDefault();
            if (radioBtn != null)
            {
                switch (radioBtn.Name)
                {
                    case "radioButton1":
                        viewFilesList = viewFiles.ToList();
                        break;
                    case "radioButton2":
                        viewFilesList.Add(viewFiles[0]);
                        break;
                    case "radioButton3":
                        viewFilesList.Add(viewFiles[1]);
                        break;
                    case "radioButton4":
                        viewFilesList = viewFiles.ToList().GetRange(2, 8);
                        break;
                    case "radioButton5":
                        viewFilesList.Add(viewFiles[10]);
                        break;
                }
            }
            MainFileSerializer m = MainFileSerializer.Get(connectionString);
            EnableControls();
            for (int i = Int32.Parse(textBox1.Text); i <= Int32.Parse(textBox2.Text); i++)
            {
                foreach (ViewFile v in viewFilesList)
                {
                    label7.Text = "Выгружаю: \n" + v.Name + " за " + textBox3.Text + "-" + string.Format("{0:00}", i);
                    await Task.Run(() => m.SerializeWithMap(v, textBox3.Text, string.Format("{0:00}", i), textBox4.Text));
                    GC.Collect();
                }
            }
            EnableControls();
        }

        private void EnableControls()
        {
            label7.Visible = !label7.Visible;
            TextBox[] textBoxes = this.Controls.OfType<TextBox>().ToArray();
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Enabled = !textBox.Enabled;
            }
            button1.Enabled = !button1.Enabled;
            groupBox1.Enabled = !groupBox1.Enabled;
        }

    }
}