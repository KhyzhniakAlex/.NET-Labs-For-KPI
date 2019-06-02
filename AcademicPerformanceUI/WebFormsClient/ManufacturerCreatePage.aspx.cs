using System;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class ManufacturerCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<ManufacturerDto> webClient = new WebClientCrudService<ManufacturerDto>("ManufacturerService.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["Id"];

            if (id != null)
            {
                _id = Guid.Parse(id);
            }

            if (!IsPostBack)
            {
                if (id != null)
                {
                    var _loadedSubject = webClient.GetEntities().Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();

                    manufacturerName.Text = _loadedSubject.Name;
                    manufacturerOfficePhoneNumber.Text = _loadedSubject.OfficePhoneNumber;
                    manufacturerCountry.Text = _loadedSubject.Country;

                    btnCreate.Visible = false;
                    Label.Text = "Update manufacturer";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new manufacturer";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            ManufacturerDto manufacturer = new ManufacturerDto();
            manufacturer.Name = manufacturerName.Text;
            manufacturer.OfficePhoneNumber = manufacturerOfficePhoneNumber.Text;
            manufacturer.Country = manufacturerCountry.Text;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.CreateEntity(manufacturer);
                scope.Complete();
            }

            Response.Redirect("manufacturersPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var manufacturer = webClient.GetEntities().Where(sub => sub.Id == _id).FirstOrDefault();
            manufacturer.Name = manufacturerName.Text;
            manufacturer.OfficePhoneNumber = manufacturerOfficePhoneNumber.Text;
            manufacturer.Country = manufacturerCountry.Text;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.UpdateEntity(manufacturer);
                scope.Complete();
            }

            Response.Redirect("manufacturersPage");
        }
    }
}