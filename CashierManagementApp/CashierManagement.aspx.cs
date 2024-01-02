using CashierManagementApp.DAL;
using CashierManagementApp.Model;
using System;
using System.Web.UI;

namespace CashierManagementApp
{
    public partial class CashierManagement : Page
    {
        private readonly datalayer _dataLayer;
        private readonly CashierManagementApp.DAL.Interfaces.ICashierService _cashierService;

        public CashierManagement()
        {
            _dataLayer = new datalayer();
            _cashierService = new DAL.Services.CashierService(new DAL.Services.CashierRepository(new CashierManagementApp.DAL.CashierDbContext()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            var cashiers = _cashierService.GetAll();
            _dataLayer.fillgridView(cashiers, gv);
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = gv.SelectedRow.Cells[1].Text;
            // Retrieve the cashier details and populate the form
            var cashier = _cashierService.GetById(id);
            if (cashier != null)
            {
                txtFirstName.Text = cashier.FirstName;
                txtLastName.Text = cashier.LastName;
                txtDateOfBirth.Text = cashier.DateOfBirth.ToString("yyyy-MM-dd");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newCashier = new CashierModel
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = DateTime.Parse(txtDateOfBirth.Text)
            };

            _cashierService.Add();
            BindGridView();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            var existingCashier = _cashierService.GetById(id);

            if (existingCashier != null)
            {
                existingCashier.LastName = txtLastName.Text;
                existingCashier.FirstName = txtFirstName.Text;
                existingCashier.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);

                _cashierService.Update();
                BindGridView();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = gv.SelectedRow.Cells[1].Text.ToString();
            _cashierService.Delete();
            BindGridView();
        }
    }
}
