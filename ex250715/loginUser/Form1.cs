using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginUser
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            label1.Font = new Font("맑은 고딕", 30, FontStyle.Bold);
            label2.Font = new Font("맑은 고딕", 30, FontStyle.Bold);
            label3.Font = new Font("맑은 고딕", 30, FontStyle.Bold);

            button1.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
            button2.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
            button3.Font = new Font("맑은 고딕", 10, FontStyle.Bold);

            



        }


        private void button1_Click(object sender, EventArgs e)
        {
            registerPanel.BringToFront();
            loginPanel.SendToBack();
            myPagePanel.SendToBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginPanel.BringToFront();
            registerPanel.SendToBack(); 
            myPagePanel.SendToBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myPagePanel.BringToFront();
            registerPanel.SendToBack();
            loginPanel.SendToBack();
        }


        private async void materialButton1_Click(object sender, EventArgs e)
        {
            var email = textBox1.Text;
            var password = textBox2.Text;
            var nickname = textBox3.Text;

            HttpClient client = new HttpClient();

            var content = new StringContent($"{{\"email\":\"{email}\", \"password\":\"{password}\", \"nickname\":\"{nickname}\"}}", Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:3030/user/register", content);

            var json = new StringContent($"{{\"email\":\"{email}\", \"password\":\"{password}\", \"nickname\":\"{nickname}\"}}",
                Encoding.UTF8, "application/json");

            Console.WriteLine(response);
            Console.WriteLine(json);

            MessageBox.Show(response.ToString());
            MessageBox.Show("회원가입하였습니다.");


        }
    }
}
