using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class CarCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<CarDto> client = new WebClientCrudService<CarDto>("CarService.svc");
        private WebClientCrudService<ManufacturerDto> forManufact = new WebClientCrudService<ManufacturerDto>("ManufacturerService.svc");
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
                    var _loadedCar = client.GetEntities().Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();
                    var manufactID = _loadedCar.ManufacturerId;
                    var _loadedManufact = forManufact.GetEntities().Where(i => i.Id == manufactID).FirstOrDefault();

                    carBrand.Text = _loadedCar.Brand;
                    carModel.Text = _loadedCar.Model;
                    carSerialNumber.Text = _loadedCar.SerialNumber;
                    carColor.Text = _loadedCar.Color;
                    carPrice.Text = _loadedCar.Price.ToString();
                    carManufacturer.Text = _loadedManufact != null ? _loadedManufact.Name : "";

                    btnCreate.Visible = false;
                    Label.Text = "Update car";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new car";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            CarDto car = new CarDto();

            car.Brand = carBrand.Text;
            car.Model = carModel.Text;
            car.SerialNumber = carSerialNumber.Text;
            car.Color = carColor.Text;
            car.Price = int.Parse(carPrice.Text);

            var _loadedManufact = forManufact.GetEntities().Where(i => i.Name == carManufacturer.Text).FirstOrDefault();
            car.ManufacturerId = _loadedManufact != null ? _loadedManufact.Id : Guid.Empty;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.CreateEntity(car);

                scope.Complete();
            }

            Thread.Sleep(3000);

            Response.Redirect("carPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var car = client.GetEntities().Where(sub => sub.Id == _id).FirstOrDefault();
            car.Brand = carBrand.Text;
            car.Model = carModel.Text;
            car.SerialNumber = carSerialNumber.Text;
            car.Color = carColor.Text;
            car.Price = int.Parse(carPrice.Text);

            var _loadedManufact = forManufact.GetEntities().Where(i => i.Name == carManufacturer.Text).FirstOrDefault();
            if (_loadedManufact != null)
                car.ManufacturerId = _loadedManufact.Id;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.UpdateEntity(car);
                scope.Complete();
            }

            Response.Redirect("carPage");
        }
    }
}