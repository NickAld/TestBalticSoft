using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Entity;


using TestBalticSoft;
using TestBalticSoft.Enumerations;

namespace TestViewData
{
    
    public partial class Form1 : Form
    {

        mDbContext dbContext;
        //private BindingList<Person> persons;
        private BindingSource pSource = new BindingSource();
        private BindingList<Person> pSourceListPersons;
        private BindingList<Organization> pSourceListOrganization;
        private BindingList<Order> pSourceListOrder;

        MyPanel workPanel;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            workPanel = new MyPanel(pControls);
            dbContext = new mDbContext();
            dbContext.Persons = dbContext.Set<Person>();
            dbContext.Persons.Load();
            dbContext.Organizations = dbContext.Set<Organization>();
            dbContext.Organizations.Load();
            dbContext.Orders = dbContext.Set<Order>();
            dbContext.Orders.Load();


            pSourceListPersons = new BindingList<Person>();
            pSourceListPersons = dbContext.Persons.Local.ToBindingList();
            dataGridView1.DataSource = pSourceListPersons;

            pSourceListOrganization = new BindingList<Organization>();
            pSourceListOrganization = dbContext.Organizations.Local.ToBindingList();
            dataGridView2.DataSource = pSourceListOrganization;

            pSourceListOrder = new BindingList<Order>();
            pSourceListOrder = dbContext.Orders.Local.ToBindingList();
            dataGridView3.DataSource = pSourceListOrder;


        }

        private void radioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                pControls = workPanel.GetPanel(EnumTypeOrder.Person);
            if (radioButton2.Checked)
                pControls = workPanel.GetPanel(EnumTypeOrder.Organization);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dbContext.Orders.Load();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbContext.Persons.Load();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dbContext.Organizations.Load();
        }

        private void добавитьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows!=null)
            {
                var row = dataGridView1.CurrentRow;
                int idPerson = Convert.ToInt32(row.Cells["PersonID"].Value.ToString());

                fOrder form = new fOrder();
                form.ShowDialog();
                if (form.DialogResult==DialogResult.OK)
                {
                    Order order = new Order(DateTime.Now, Convert.ToInt32(form.IDDoc), EnumTypeOrder.Person);
                    order.OrderSum = Convert.ToDouble(form.Sum);
                    ProcessOrders process = new ProcessOrders();
                    order = (Order)process.CalculateOrderSum(order);
                    order.idParent = idPerson;
                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                }
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {
                var row = dataGridView2.CurrentRow;
                int idOrg = Convert.ToInt32(row.Cells["OrganizationID"].Value.ToString());

                fOrder form = new fOrder();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    Order order = new Order(DateTime.Now, Convert.ToInt32(form.IDDoc), EnumTypeOrder.Organization);
                    ProcessOrders process = new ProcessOrders();
                    order.OrderSum = Convert.ToDouble(form.Sum);
                    order = (Order)process.CalculateOrderSum(order);
                    order.idParent = idOrg;
                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
