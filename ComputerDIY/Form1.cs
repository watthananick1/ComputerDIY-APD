using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Windows.UI.Xaml.Controls;
using Image = System.Drawing.Image;

namespace ComputerDIY
{
    public partial class Form1 : Form
    {
        APD65_63011212052Entities context = new APD65_63011212052Entities();
        Sproduct product = new Sproduct();

        int qc = 0;
        Form2 form2;
        decimal sumprice = 0;
        public Form1(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var results = context.Sstatus.OrderBy(s => s.Status_id).Select(s => new { s.Status_id, s.Status_name });
            foreach (var result in results)
            {
                comboBox1.Items.Add(new ComboBoxItem(result.Status_id.ToString(),
                    result.Status_name));
            }
            var typePd = context.View_1.ToList();
            foreach (var item in typePd)
            {
                comboBox2.Items.Add(item.Expr1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
            //HtmlWeb web = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            //var html = doc.DocumentNode.Descendants("meta");
            //var title = html.Where(m => m.GetAttributeValue("property", "") == "og:title").First();
            //textBox2.Text = title.GetAttributeValue("content", "");
            //var description = html.Where(m => m.GetAttributeValue("property", "") == "og:description").First();
            //textBox3.Text = description.GetAttributeValue("content", "");
            //var image = html.Where(m => m.GetAttributeValue("property", "") == "og:image").First();

            //pictureBox1.Image = LoadImage(image.GetAttributeValue("content", ""));

            //var priceblock = doc.DocumentNode.Descendants("div");
            //var price = priceblock.Where(p => p.GetAttributeValue("class", "") ==
            //"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block").First().InnerText;
            //price = new string(price.Where(c => char.IsDigit(c)).ToArray());
            //textBox4.Text = price;
            
        }
        private System.Drawing.Image LoadImage(string url)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
            //HtmlWeb web = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            //HtmlNode titleNode = doc.DocumentNode
            //    .SelectSingleNode("//meta[@property=\"og:title\"]");
            //textBox2.Text = titleNode.Attributes["content"].Value;

            //HtmlNode descriptionNode = doc.DocumentNode
            //    .SelectSingleNode("//meta[@property=\"og:description\"]");
            //textBox3.Text = descriptionNode.Attributes["content"].Value;

            //HtmlNode imageNode = doc.DocumentNode
            //    .SelectSingleNode("//meta[@property=\"og:image\"]");
            //pictureBox1.Image = LoadImage(imageNode.GetAttributeValue("content", ""));

            //HtmlNode priceNode = doc.DocumentNode
            //    .SelectSingleNode("//div[@class=" +
            //    "\"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block\"]");
            //String price = priceNode.InnerText;
            //price = new string(price.Where(c => char.IsDigit(c)).ToArray());
            //textBox4.Text = price;


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //try
            //{

            //    string url = textBox5.Text;
            //    HtmlWeb web = new HtmlWeb();
            //    HtmlAgilityPack.HtmlDocument document = web.Load(url);

            //    var numOfPageNode = document.DocumentNode
            //        .SelectNodes("//div[@class=\"col-md-6 col-sm-6 pad-0\"]//span");
            //    textBox6.Text = numOfPageNode[1].InnerText;
            //    string countItem = numOfPageNode[0].InnerText;
            //    textBox8.Text = new string(countItem.Where(c => char.IsDigit(c)).ToArray());

            //    var typeOfProductNode = document.DocumentNode.SelectNodes("//span[@class=\"en\"]");
            //    textBox7.Text = typeOfProductNode[1].InnerText;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Please enter URL");
            //}
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    int codepPage = 0;
            //    int countPage = 0;
            //    listView1.Items.Clear();
            //    while (true)
            //    {
            //        string url = textBox5.Text + "/" + codepPage;
            //        HtmlWeb web = new HtmlWeb();
            //        HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            //        var titleNode = doc.DocumentNode.SelectNodes("//div[@class=\"cart_modal buy_promo\"]");
            //        if (titleNode == null)
            //        {
            //            break;
            //        }
            //        foreach (HtmlNode node in titleNode)
            //        {
            //            string[] data = new string[]
            //            {
            //            node.Attributes["data-id"].Value,
            //            node.Attributes["data-name"].Value
            //            };
            //            listView1.Items.Add(new ListViewItem(data));
            //            countPage++;
            //        }
            //        Console.WriteLine(countPage);
            //        codepPage += 100;
            //    }
            //}
            //catch { }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    textBox1.Text = listView1.SelectedItems[0].Text;
            //    string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
            //    HtmlWeb web = new HtmlWeb();
            //    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            //    HtmlNode titleNode = doc.DocumentNode
            //        .SelectSingleNode("//meta[@property=\"og:title\"]");
            //    textBox2.Text = titleNode.Attributes["content"].Value;

            //    HtmlNode descriptionNode = doc.DocumentNode
            //        .SelectSingleNode("//meta[@property=\"og:description\"]");
            //    textBox3.Text = descriptionNode.Attributes["content"].Value;

            //    var typeNode = doc.DocumentNode
            //        .SelectNodes("//div[@class=\"step_nav\"]//a");
            //    textBox7.Text = typeNode[2].InnerText;

            //    HtmlNode imageNode = doc.DocumentNode
            //        .SelectSingleNode("//meta[@property=\"og:image\"]");
            //    pictureBox1.Image = LoadImage(imageNode.GetAttributeValue("content", ""));

            //    HtmlNode priceNode = doc.DocumentNode
            //        .SelectSingleNode("//div[@class=" +
            //        "\"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block\"]");
            //    String price = priceNode.InnerText;
            //    price = new string(price.Where(c => char.IsDigit(c)).ToArray());
            //    textBox4.Text = price;
            //}
            //catch (Exception)
            //{
            //    textBox1.Text = listView1.SelectedItems[0].Text;
            //    string url = "https://www.jib.co.th/web/product/readProduct/" + textBox1.Text;
            //    HtmlWeb web = new HtmlWeb();
            //    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            //    HtmlNode titleNode = doc.DocumentNode
            //        .SelectSingleNode("//meta[@property=\"og:title\"]");
            //    textBox2.Text = titleNode.Attributes["content"].Value;

            //    HtmlNode descriptionNode = doc.DocumentNode
            //        .SelectSingleNode("//meta[@property=\"og:description\"]");
            //    textBox3.Text = descriptionNode.Attributes["content"].Value;

            //    var typeNode = doc.DocumentNode
            //        .SelectNodes("//div[@class=\"step_nav\"]//a");
            //    textBox7.Text = typeNode[1].InnerText;

            //    HtmlNode imageNode = doc.DocumentNode
            //        .SelectSingleNode("//meta[@property=\"og:image\"]");
            //    pictureBox1.Image = LoadImage(imageNode.GetAttributeValue("content", ""));

            //    HtmlNode priceNode = doc.DocumentNode
            //        .SelectSingleNode("//div[@class=" +
            //        "\"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block\"]");
            //    String price = priceNode.InnerText;
            //    price = new string(price.Where(c => char.IsDigit(c)).ToArray());
            //    textBox4.Text = price;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            //foreach (ListViewItem item in listView1.Items)
            //{

            //    string id = item.SubItems[0].Text;
            //    try
            //    {

            //        string v = context.Sproducts.Where(s => s.Pd_ID == id).Select(s => s.Pd_ID).First();
            //        //Console.WriteLine(v);
            //        Console.WriteLine("Have data " + v);
            //        continue;
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine(id);
            //        string url = "https://www.jib.co.th/web/product/readProduct/" + id;
            //        HtmlWeb web = new HtmlWeb();
            //        HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            //        product.Pd_ID = id;
            //        product.Pd_name = item.SubItems[1].Text;
            //        Console.WriteLine(product.Pd_name);
            //        try
            //        {
            //            HtmlNode descriptionNode = doc.DocumentNode
            //                .SelectSingleNode("//meta[@property=\"og:description\"]");
            //            product.Pd_detail = descriptionNode.Attributes["content"].Value;
            //            Console.WriteLine(product.Pd_detail);
            //        }
            //        catch (Exception)
            //        {
            //            HtmlNode descriptionNode = doc.DocumentNode
            //                .SelectSingleNode("//meta[@property=\"og:description\"]");
            //            product.Pd_detail = descriptionNode.Attributes["content"].Value;
            //            Console.WriteLine(product.Pd_detail);
            //        }

            //        HtmlNode priceNode = doc.DocumentNode
            //            .SelectSingleNode("//div[@class=" +
            //            "\"col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center price_block\"]");
            //        String price = priceNode.InnerText;
            //        price = new string(price.Where(c => char.IsDigit(c)).ToArray());
            //        product.Pd_unitprice = decimal.Parse(price + ".00");
            //        Console.WriteLine(product.Pd_unitprice);

            //        HtmlNode imageNode = doc.DocumentNode
            //            .SelectSingleNode("//meta[@property=\"og:image\"]");
            //        product.Pd_img = imageNode.Attributes["content"].Value;
            //        Console.WriteLine(product.Pd_img);

            //        product.Pd_stock = 10;
            //        Console.WriteLine(product.Pd_stock);

            //        var typeNode = doc.DocumentNode
            //            .SelectNodes("//div[@class=\"step_nav\"]//a");
            //        product.Pd_type = typeNode[2].InnerText;
            //        Console.WriteLine(product.Pd_type);

            //        context.Sproducts.Add(product);
            //        qc += context.SaveChanges();
            //        Console.WriteLine(qc);
            //    }

            //}
            //MessageBox.Show("Save success " + qc + " record");

        }

        //public static byte[] ImageToByte(Image img)
        //{
        //    ImageConverter converter = new ImageConverter();
        //    return (byte[])converter.ConvertTo(img, typeof(byte[]));
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.form2.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            scustomerBindingSource1.DataSource = context.Scustomers.ToList();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            semployeeBindingSource.DataSource = context.Semployees.Where(s => s.Em_status > 1).ToList();
            int id = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            int statusid = context.Semployees.Where(s => s.Em_ID == id).Select(p => p.Em_status).First();
            comboBox1.Text = context.Sstatus.Where(s => s.Status_id == statusid).Select(p => p.Status_name).First();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            scustomerBindingSource1.DataSource = context.Scustomers.ToList();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            scustomerBindingSource1.DataSource = context.Scustomers.ToList();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                semployeeBindingSource.EndEdit();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pictureBox2 = null;
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int change = context.SaveChanges();
            MessageBox.Show("Change on " + change + " records");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox8.Text))
                {
                    string name = textBox8.Text;
                    sproductBindingSource.DataSource = context.Sproducts.Where(s => s.Pd_name == name || s.Pd_name.Contains(name)).ToList();
                }
                else
                {
                    sproductBindingSource.DataSource = context.Sproducts.ToList();
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    string detail = textBox3.Text;
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



        private void button14_Click(object sender, EventArgs e)
        {
            Semployee semployee = new Semployee();
            semployee.Em_firstname = textBox20.Text;
            semployee.Em_lastname = textBox19.Text;
            semployee.Em_phone = textBox18.Text;
            semployee.Em_email = textBox17.Text;
            semployee.Em_status = int.Parse(((ComboBoxItem)(comboBox1.SelectedItem)).Value);
            semployee.Em_username = textBox1.Text;
            semployee.Em_pssword = textBox2.Text;

            context.Semployees.Add(semployee);
            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records");

            semployeeBindingSource.DataSource = context.Semployees.Where(s => s.Em_status > 1).ToList();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            semployeeBindingSource.AddNew();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox21.Text);

            var result = context.Semployees
                .Where(p => p.Em_ID == id)
                .First();

            context.Semployees.Remove(result);
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Delete failed");
            }

            semployeeBindingSource.DataSource = context.Semployees.Where(s => s.Em_status > 1).ToList();
        }

        internal class ComboBoxItem
        {
            public string Value { get; set; } //Supplier ID
            public string Text { get; set; } //Company Name
            public ComboBoxItem(string val, string text)
            {
                Value = val;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            int statusid = context.Semployees.Where(s => s.Em_ID == id).Select(p => p.Em_status).First();
            comboBox1.Text = context.Sstatus.Where(s => s.Status_id == statusid).Select(p => p.Status_name).First();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
            int statusid = context.Semployees.Where(s => s.Em_ID == id).Select(p => p.Em_status).First();
            comboBox1.Text = context.Sstatus.Where(s => s.Status_id == statusid).Select(p => p.Status_name).First();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            scustomerBindingSource1.AddNew();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox11.Text);

            var result = context.Scustomers
                .Where(p => p.Cm_id == id)
                .First();

            context.Scustomers.Remove(result);
            int change = context.SaveChanges();
            if (change > 0)
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Delete failed");
            }

            scustomerBindingSource1.DataSource = context.Scustomers.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int change = context.SaveChanges();
            MessageBox.Show("Change on " + change + " records");
            scustomerBindingSource1.DataSource = context.Scustomers.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Scustomer customer = new Scustomer();
            customer.Cm_firstname = textBox9.Text;
            customer.Cm_lastname = textBox10.Text;
            customer.Cm_phone = textBox11.Text;
            customer.Cm_email = textBox12.Text;

            context.Scustomers.Add(customer);
            int change = context.SaveChanges();
            MessageBox.Show("Change: " + change + " records");

            scustomerBindingSource1.DataSource = context.Scustomers.ToList();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string f = comboBox2.SelectedItem.ToString();
            sproductBindingSource.DataSource = context.Sproducts.Where(s => s.Pd_type == f).ToList();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            

            try
            {
                string name = textBox5.Text;
                int idc = context.Scustomers.Where(s => s.Cm_firstname.Contains(name)).Select(s => s.Cm_id).First();
                bindingSource1.DataSource = context.SOrders.Where(s => s.Or_CmID == idc).ToList();
            }
            catch
            {

            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            string name = textBox5.Text;
            string phone = textBox6.Text;
            string id = textBox7.Text;
            try
            {

            }
            catch
            {

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                string phone = textBox7.Text;
                int idc = context.Scustomers.Where(s => s.Cm_phone.Contains(phone)).Select(s => s.Cm_id).First();
                bindingSource1.DataSource = context.SOrders.Where(s => s.Or_CmID == idc).ToList();
            }
            catch
            {

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                int id = int.Parse(textBox7.Text);
                bindingSource1.DataSource = context.SOrders.Where(s => s.Or_CmID.Equals(id)).ToList();
            }
            catch
            {

            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                int id = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                sOrderItemBindingSource.DataSource = context.SOrderItems.Where(s => s.It_OrderID == id).ToList();
            }
            catch
            {

            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                int id = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                sOrderItemBindingSource.DataSource = context.SOrderItems.Where(s => s.It_OrderID == id).ToList();
            }
            catch
            {

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bindingSource2.Clear();
                this.sumprice = 0;
                string d2 = " 23:59:59";
                var ci = new CultureInfo("th-TH");
                var today = Convert.ToDateTime(dateTimePicker1.Value.Date
                    .ToString(DateFormat, ci));
                var todayend = Convert.ToDateTime(dateTimePicker1.Value.Date
                    .ToString(DateFormat, ci) + d2);
                Console.WriteLine(today.ToString());
                Console.WriteLine(todayend.ToString());
                var items = context.SOrders.ToList();
                foreach (var item in items)
                {
                    string eh;
                    var dt = Convert.ToDateTime(item.Or_date.ToString(DateFormat, ci));
                    Console.WriteLine("** {0}", dt);
                    var td1 = Convert.ToDateTime(today.ToString(DateFormat, ci));
                    var td1end = Convert.ToDateTime(todayend.ToString(DateFormat, ci));
                    Console.WriteLine("-*- {0}", dt);
                    //Console.WriteLine("-- {0}", today);
                    if (item.Or_date >= today || dt >= td1)
                    {
                        //Console.WriteLine(eh);
                        if (item.Or_date < todayend || dt < td1end)
                        {
                            //eh = item.Or_date.ToString();
                            //Console.WriteLine(-1);
                            //Console.WriteLine("== {0}", dt);
                            bindingSource2.Add(item);
                            this.sumprice += item.Or_totalamount;
                        }

                    }

                }
                label27.Text = this.sumprice.ToString();
            }
            catch
            {

            }
        }

        private const string DateFormat = "MM-dd-yyyy";

        private const string DateFormat2 = "dd-MM-yyyy";

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {

            //try
            //{
            //    bindingSource2.Clear();
            //    string d2 = " 23:59:59";
            //    var ci = new CultureInfo("th-TH");
            //    var today = Convert.ToDateTime(dateTimePicker1.Value.Date
            //        .ToString(DateFormat, ci));
            //    var todayend = Convert.ToDateTime(dateTimePicker1.Value.Date
            //        .ToString(DateFormat, ci)+d2);
            //    Console.WriteLine(today.ToString());
            //    Console.WriteLine(todayend.ToString());
            //    var items = context.SOrders.ToList();
            //    foreach(var item in items)
            //    {
            //        string eh ;
            //        if (item.Or_date >= today)
            //        {
            //            //eh = item.Or_date.ToString();
            //            //Console.WriteLine(eh);
            //            if (item.Or_date < todayend)
            //            {
            //                Console.WriteLine(1);
            //                //eh = item.Or_date.ToString();
            //                //Console.WriteLine(eh);
            //                bindingSource2.Add(item);
            //            }

            //        }
                    
            //    }
            //}
            //catch
            //{

            //}
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if(numericUpDown1.Value >= 0)
            //    {
            //        bindingSource2.Clear();
            //        this.sumprice = 0;
            //        int day = int.Parse(numericUpDown1.Value.ToString());
            //        string d2 = " 23:59:59";
            //        var ci = new CultureInfo("th-TH");

            //        var today = Convert.ToDateTime(DateTime.Now.AddDays(-day)
            //            .ToString(DateFormat, ci) + d2);

            //        var todayend = Convert.ToDateTime(DateTime.Now
            //            .ToString(DateFormat, ci));

            //        Console.WriteLine(today.ToString());
            //        Console.WriteLine(todayend.ToString());

            //        var items = context.SOrders.ToList();
            //        foreach (var item in items)
            //        {
            //            string eh;
            //            var dt = Convert.ToDateTime(item.Or_date.ToString(DateFormat, ci));
            //            Console.WriteLine("** {0}", dt);
            //            var td1 = Convert.ToDateTime(today.ToString(DateFormat, ci));
            //            var td1end = Convert.ToDateTime(todayend.ToString(DateFormat, ci));
            //            Console.WriteLine("-*- {0}", dt);
            //            //Console.WriteLine("-- {0}", today);
            //            if (item.Or_date >= today || dt >= td1)
            //            {
            //                //Console.WriteLine(eh);
            //                if (item.Or_date < todayend || dt < td1end)
            //                {
            //                    //eh = item.Or_date.ToString();
            //                    //Console.WriteLine(-1);
            //                    //Console.WriteLine("== {0}", dt);
            //                    bindingSource2.Add(item);
            //                    this.sumprice += item.Or_totalamount;
            //                }

            //            }

            //        }
            //        label27.Text = this.sumprice.ToString();
            //    }

            //}
            //catch
            //{

            //}
            try
            {
                bindingSource2.Clear();
                this.sumprice = 0;
                int day = int.Parse(numericUpDown1.Value.ToString());
                string d2 = " 23:59:59";
                string d1 = " 00:00:00";
                var ci = new CultureInfo("th-TH");
                var today1 = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString(DateFormat, ci) + d1);
                var today = Convert.ToDateTime(today1.AddDays(-day)
                    .ToString(DateFormat, ci) + d1);

                var todayend = Convert.ToDateTime(DateTime.Now
                    .ToString(DateFormat, ci)+ d2);
                Console.WriteLine(today.ToString());
                Console.WriteLine(todayend.ToString());
                var items = context.SOrders.ToList();
                foreach (var item in items)
                {
                    string eh;
                    var dt = Convert.ToDateTime(item.Or_date.ToString(DateFormat, ci));
                    Console.WriteLine("** {0}", dt);
                    var td1 = Convert.ToDateTime(today.ToString(DateFormat, ci));
                    var td1end = Convert.ToDateTime(todayend.ToString(DateFormat, ci));
                    Console.WriteLine("-*- {0}", dt);
                    //Console.WriteLine("-- {0}", today);
                    if (item.Or_date >= today)
                    {
                        //Console.WriteLine(eh);
                        if (item.Or_date < todayend)
                        {
                            //eh = item.Or_date.ToString();
                            //Console.WriteLine(-1);
                            //Console.WriteLine("== {0}", dt);
                            bindingSource2.Add(item);
                            this.sumprice += item.Or_totalamount;
                        }

                    }

                }
                label27.Text = this.sumprice.ToString();
            }
            catch
            {

            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }
}
