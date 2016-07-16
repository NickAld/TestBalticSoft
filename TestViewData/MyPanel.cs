using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TestBalticSoft.Enumerations;
using TestBalticSoft;


namespace TestViewData
{
    class MyPanel
    {
        const int XStartTextBox = 140;
        const int space = 10;
        Button bSave;
        EnumTypeOrder typeOrder;

        Panel parent;

        public MyPanel(Panel parent)
        {
            this.parent = parent;

            bSave = new Button();
            bSave.Name = "bSave";
            bSave.Text = "Сохранить";
            
            bSave.Width = 90;
            bSave.Location = new System.Drawing.Point(370, 40);
            bSave.Click += BSave_Click;


        }

        public Panel GetPanel(EnumTypeOrder typeOrder)
        {
            this.typeOrder = typeOrder;
            parent.Controls.Clear();
            switch(typeOrder)
            {
                case EnumTypeOrder.Person:
                    GetForPersons();
                    break;
                case EnumTypeOrder.Organization:
                    GetForOrg();
                    break;
            }
            bSave.Parent = parent;
            parent.Controls.Add(bSave);
            return parent;
        }

        void GetForPersons()
        {
            Label lFIO = new Label();
            lFIO.Name = "lFIO";
            lFIO.Parent = parent;
            lFIO.Text = "ФИО клиента";
            lFIO.Location = new System.Drawing.Point(10,10);
            parent.Controls.Add(lFIO);

            TextBox tbFiO = new TextBox();
            tbFiO.Name = "tbFiO";
            tbFiO.Parent = parent;
            tbFiO.Width = 200;
            tbFiO.Location = new System.Drawing.Point(XStartTextBox, 10);
            parent.Controls.Add(tbFiO);

            Label lAddress = new Label();
            lAddress.Name = "lAddress";
            lAddress.Parent = parent;
            lAddress.Text = "Адрес клиента";
            lAddress.Location = new System.Drawing.Point(10, tbFiO.Height + 20);
            parent.Controls.Add(lAddress);

            TextBox tbAddress = new TextBox();
            tbAddress.Name = "tbAddress";
            tbAddress.Parent = parent;
            tbAddress.Width = 200;
            tbAddress.Location = new System.Drawing.Point(XStartTextBox, tbFiO.Height + 20);
            parent.Controls.Add(tbAddress);



        }
        void GetForOrg()
        {
            Label lAddrFact = new Label();
            lAddrFact.Name = "lAddrFact";
            lAddrFact.Parent = parent;
            lAddrFact.Text = "Адрес фактический";
            lAddrFact.Width = 120;
            lAddrFact.Location = new System.Drawing.Point(0, 0);
            parent.Controls.Add(lAddrFact);

            TextBox tbAddrFack = new TextBox();
            tbAddrFack.Name = "tbAddrFack";
            tbAddrFack.Parent = parent;
            tbAddrFack.Width = 200;
            tbAddrFack.Location = new System.Drawing.Point(XStartTextBox, 0);
            parent.Controls.Add(tbAddrFack);

            Label lAddress = new Label();
            lAddress.Name = "lAddress";
            lAddress.Parent = parent;
            lAddress.Text = "Адрес юридический";
            lAddress.Width = 120;
            lAddress.Location = new System.Drawing.Point(0, tbAddrFack.Height + space);
            parent.Controls.Add(lAddress);

            TextBox tbAddress = new TextBox();
            tbAddress.Name = "tbAddress";
            tbAddress.Parent = parent;
            tbAddress.Width = 200;
            tbAddress.Location = new System.Drawing.Point(XStartTextBox, tbAddrFack.Height + space);
            parent.Controls.Add(tbAddress);


            Label lINN = new Label();
            lINN.Name = "lINN";
            lINN.Text = "ИНН";
            lINN.Parent = parent;
            lINN.Location = new System.Drawing.Point(0, tbAddress.Location.Y + tbAddress.Height + space);
            parent.Controls.Add(lINN);

            TextBox tbINN = new TextBox();
            tbINN.Name = "tbINN";
            tbINN.Parent = parent;
            tbINN.Width = 200;
            tbINN.Location = new System.Drawing.Point(XStartTextBox, tbAddress.Location.Y + tbAddress.Height + space);
            parent.Controls.Add(tbINN);

        }

        private void BSave_Click(object sender, EventArgs e)
        {
            mDbContext db = new mDbContext();
            switch (typeOrder)
            {
                case EnumTypeOrder.Person:
                    db.Persons.Add(GetPerson());
                    db.SaveChanges();
                    break;
                case EnumTypeOrder.Organization:
                    db.Organizations.Add(GetOrg());
                    db.SaveChanges();
                    break;
            }


        }

        Person GetPerson()
        {
            TextBox fio = (TextBox)parent.Controls.Find("tbFIO", true).FirstOrDefault();
            TextBox addr = (TextBox)parent.Controls.Find("tbAddress", true).FirstOrDefault();
            return new Person(fio.Text, addr.Text);
        }

        Organization GetOrg()
        {
            TextBox addrF = (TextBox)parent.Controls.Find("tbAddrFack", true).FirstOrDefault();
            TextBox addrU = (TextBox)parent.Controls.Find("tbAddress", true).FirstOrDefault();
            TextBox inn = (TextBox)parent.Controls.Find("tbINN", true).FirstOrDefault();

            return new Organization(addrF.Text, addrU.Text, inn.Text);
        }

    }
}
