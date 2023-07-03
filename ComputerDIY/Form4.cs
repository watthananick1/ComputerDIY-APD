using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerDIY
{
    public partial class Form4 : Form
    {
        APD65_63011212052Entities context = new APD65_63011212052Entities();
        Form2 form2;
        Sproduct product = new Sproduct();
        int qc = 0;
        string id;
        public Form4(Form2 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var typePd = context.View_1.ToList();
            foreach (var item in typePd)
            {
                comboBox1.Items.Add(item.Expr1);
                comboBox2.Items.Add(item.Expr1);
                comboBox3.Items.Add(item.Expr1);
            }
            spromotionBindingSource.DataSource = context.Spromotions.ToList();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form2.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox8.Text))
                {
                    string name = textBox10.Text;
                    sproductBindingSource.DataSource = context.Sproducts.Where(s => s.Pd_name == name || s.Pd_name.Contains(name)).ToList();
                }
                else
                {
                    sproductBindingSource.DataSource = context.Sproducts.ToList();
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    string detail = textBox9.Text;
                    sproductBindingSource.DataSource = context.Sproducts.Where(s => s.Pd_detail == detail || s.Pd_detail.Contains(detail)).ToList();
                }
                else
                {
                    sproductBindingSource.DataSource = context.Sproducts.ToList();
                }
                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    string type = comboBox2.Text;
                    sproductBindingSource.DataSource = context.Sproducts.Where(s => s.Pd_type == type || s.Pd_detail.Contains(type)).ToList();
                }
                else
                {
                    sproductBindingSource.DataSource = context.Sproducts.ToList();
                }

            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox5.Text;
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = web.Load(url);

                var numOfPageNode = document.DocumentNode
                    .SelectNodes("//div[@class=\"col-md-6 col-sm-6 pad-0\"]//span");
                textBox6.Text = numOfPageNode[1].InnerText;
                string countItem = numOfPageNode[0].InnerText;
                textBox8.Text = new string(countItem.Where(c => char.IsDigit(c)).ToArray());

                var typeOfProductNode = document.DocumentNode.SelectNodes("//span[@class=\"en\"]");
                textBox7.Text = typeOfProductNode[1].InnerText;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter URL");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int codepPage = 0;
                int countPage = 0;
                listView1.Items.Clear();
                while (true)
                {
                    string url = textBox5.Text + "/" + codepPage;
                    HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                    var titleNode = doc.DocumentNode.SelectNodes("//div[@class=\"cart_modal buy_promo\"]");
                    if (titleNode == null)
                    {
                        break;
                    }
                    foreach (HtmlNode node in titleNode)
                    {
                        string[] data = new string[]
                        {
                        node.Attributes["data-id"].Value,
                        node.Attributes["data-name"].Value
                        };
                        listView1.Items.Add(new ListViewItem(data));
                        countPage++;
                    }
                    Console.WriteLine(countPage);
                    codepPage += 100;
                }
            }
            catch { }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {

                string id = item.SubItems[0].Text;
                try
                {

                    string v = context.Sproducts.Where(s => s.Pd_ID == id).Select(s => s.Pd_ID).First();
                    //Console.WriteLine(v);
                    Console.WriteLine("Have data " + v);
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine(id);
                    string url = "https://www.jib.co.th/web/product/readProduct/" + id;
                    HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                    product.Pd_ID = id;
                    product.Pd_name = item.SubItems[1].Text;
                    Console.WriteLine(product.Pd_name);
                    try
                    {
                        HtmlNode descriptionNode = doc.DocumentNode
                            .SelectSingleNode("//meta[@property=\"og:description\"]");
                        product.Pd_detail = descriptionNode.Attributes["content"].Value;
                        Console.WriteLine(product.Pd_detail);
                    }
                    catch (Exception)
                    {
                        HtmlNode descriptionNode = doc.DocumentNode
                            .SelectSingleNode("//meta[@property=\"og:description\"]");
                        product.Pd_detail = descriptionNode.Attributes["content"].Value;
                        Console.WriteLine(product.Pd_detail);
                    }

                    HtmlNode priceNode = doc.DocumentNode
                        .SelectSingleNode("//div[@class=" +
                        "\"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block\"]");
                    String price = priceNode.InnerText;
                    price = new string(price.Where(c => char.IsDigit(c)).ToArray());
                    product.Pd_unitprice = decimal.Parse(price + ".00");
                    Console.WriteLine(product.Pd_unitprice);

                    HtmlNode imageNode = doc.DocumentNode
                        .SelectSingleNode("//meta[@property=\"og:image\"]");
                    product.Pd_img = imageNode.Attributes["content"].Value;
                    Console.WriteLine(product.Pd_img);

                    product.Pd_stock = 10;
                    Console.WriteLine(product.Pd_stock);

                    var typeNode = doc.DocumentNode
                        .SelectNodes("//div[@class=\"step_nav\"]//a");
                    product.Pd_type = typeNode[2].InnerText;
                    Console.WriteLine(product.Pd_type);

                    context.Sproducts.Add(product);
                    qc += context.SaveChanges();
                    Console.WriteLine(qc);
                }

            }
            MessageBox.Show("Save success " + qc + " record");
        }

        private Image LoadImage(string url)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.UserAgent = "Chrome/105.0.0.0";
            Bitmap bmp = null;
            HttpWebResponse myHttpWebResponse = null;
            try
            {
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                Stream streamResponse = myHttpWebResponse.GetResponseStream();
                Console.WriteLine("Error code: {0}", myHttpWebResponse.StatusCode);

                bmp = new Bitmap(streamResponse);
                if (streamResponse == null)
                {
                    bmp = null;
                }

                return bmp;
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
                return bmp = null;
            }
            return bmp;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = listView1.SelectedItems[0].Text;
                string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                HtmlNode titleNode = doc.DocumentNode
                    .SelectSingleNode("//meta[@property=\"og:title\"]");
                textBox2.Text = titleNode.Attributes["content"].Value;

                HtmlNode descriptionNode = doc.DocumentNode
                    .SelectSingleNode("//meta[@property=\"og:description\"]");
                textBox3.Text = descriptionNode.Attributes["content"].Value;

                var typeNode = doc.DocumentNode
                    .SelectNodes("//div[@class=\"step_nav\"]//a");
                textBox7.Text = typeNode[2].InnerText;

                HtmlNode imageNode = doc.DocumentNode
                    .SelectSingleNode("//meta[@property=\"og:image\"]");
                pictureBox1.Image = LoadImage(imageNode.GetAttributeValue("content", ""));

                HtmlNode priceNode = doc.DocumentNode
                    .SelectSingleNode("//div[@class=" +
                    "\"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block\"]");
                String price = priceNode.InnerText;
                price = new string(price.Where(c => char.IsDigit(c)).ToArray());
                textBox4.Text = price;
            }
            catch (Exception)
            {
                textBox1.Text = listView1.SelectedItems[0].Text;
                string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);
                HtmlNode titleNode = doc.DocumentNode
                    .SelectSingleNode("//meta[@property=\"og:title\"]");
                textBox2.Text = titleNode.Attributes["content"].Value;

                HtmlNode descriptionNode = doc.DocumentNode
                    .SelectSingleNode("//meta[@property=\"og:description\"]");
                textBox3.Text = descriptionNode.Attributes["content"].Value;

                var typeNode = doc.DocumentNode
                    .SelectNodes("//div[@class=\"step_nav\"]//a");
                textBox7.Text = typeNode[1].InnerText;

                HtmlNode imageNode = doc.DocumentNode
                    .SelectSingleNode("//meta[@property=\"og:image\"]");
                pictureBox1.Image = LoadImage(imageNode.GetAttributeValue("content", ""));

                HtmlNode priceNode = doc.DocumentNode
                    .SelectSingleNode("//div[@class=" +
                    "\"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block\"]");
                String price = priceNode.InnerText;
                price = new string(price.Where(c => char.IsDigit(c)).ToArray());
                textBox4.Text = price;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string f = comboBox1.SelectedItem.ToString();
            bindingSource3.DataSource = context.Sproducts.Where(s => s.Pd_type == f).ToList();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string f = comboBox3.SelectedItem.ToString();
            bindingSource2.DataSource = context.Sproducts.Where(s => s.Pd_type == f).ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = context.Sproducts.Where(s => s.Pd_ID == id).Select(s => s.Pd_type).First();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = context.Sproducts.Where(s => s.Pd_ID == id).Select(s => s.Pd_type).First();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            comboBox3.Text = context.Sproducts.Where(s => s.Pd_ID == id).Select(s => s.Pd_type).First();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            comboBox3.Text = context.Sproducts.Where(s => s.Pd_ID == id).Select(s => s.Pd_type).First();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string f = comboBox2.SelectedItem.ToString();
            sproductBindingSource.DataSource = context.Sproducts.Where(s => s.Pd_type == f).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Spromotion promotion = new Spromotion();

                promotion.Pm_PfirstID = textBox11.Text;
                Console.WriteLine("1 -- " + promotion.Pm_PfirstID);

                promotion.Pm_Pfirst = textBox12.Text;
                Console.WriteLine("1 -- " + promotion.Pm_Pfirst);

                promotion.Pm_PsecondID = textBox14.Text;
                Console.WriteLine("2 -- " + promotion.Pm_PsecondID);

                promotion.Pm_Psecond = textBox13.Text;
                Console.WriteLine("2 -- " + promotion.Pm_Psecond);

                promotion.Pm_rebate = 10;

                context.Spromotions.Add(promotion);
                qc += context.SaveChanges();
            }
            catch
            {

            }
            MessageBox.Show("Save success " + qc + " record");
            spromotionBindingSource.DataSource = context.Spromotions.ToList();

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.id = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.id.ToString());

            var result = context.Spromotions
                .Where(p => p.Pm_ID == id).First();

            context.Spromotions.Remove(result);
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Delete failed");
            }

            spromotionBindingSource.DataSource = context.Spromotions.ToList();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.id = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
