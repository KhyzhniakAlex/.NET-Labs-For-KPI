using DataAccess.Interfaces;
using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class CarCreatePage : System.Web.UI.Page
    {
        private readonly IRepository<Car> Repository = Singleton.UnitOfWork.CarRepository;
        private readonly IRepository<Manufacturer> RepoManufact = Singleton.UnitOfWork.ManufacturerRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
        private Guid _id;
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
                    var _loadedSubject = Repository.GetAllEntitiesAsync().Result.Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();
                    var manufactID = _loadedSubject.ManufacturerId;
                    var _loadedManufact = RepoManufact.GetAllEntitiesAsync().Result.Where(i => i.Id == manufactID).FirstOrDefault();

                    carBrand.Text = _loadedSubject.Brand;
                    carModel.Text = _loadedSubject.Model;
                    carSerialNumber.Text = _loadedSubject.SerialNumber;
                    carColor.Text = _loadedSubject.Color;
                    carPrice.Text = _loadedSubject.Price.ToString();
                    carManufacturerId.Text = _loadedManufact != null ? _loadedManufact.Name : "";

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
            Car car = new Car();
            car.Id = Guid.NewGuid();
            car.Brand = carBrand.Text;
            car.Model = carModel.Text;
            car.SerialNumber = carSerialNumber.Text;
            car.Color = carColor.Text;
            car.Price = int.Parse(carPrice.Text);

            var _loadedManufact = RepoManufact.GetAllEntitiesAsync().Result.Where(i => i.Name == carManufacturerId.Text).FirstOrDefault();
            car.ManufacturerId = _loadedManufact != null ? _loadedManufact.Id : Guid.Empty;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(car);
                serviceClient.CreateCar(serialized);
                scope.Complete();
            }

            Thread.Sleep(3000);

            Response.Redirect("carPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var car = Repository.GetAllEntitiesAsync().Result.Where(sub => sub.Id == _id).FirstOrDefault();

            car.Id = Guid.NewGuid();
            car.Brand = carBrand.Text;
            car.Model = carModel.Text;
            car.SerialNumber = carSerialNumber.Text;
            car.Color = carColor.Text;
            car.Price = int.Parse(carPrice.Text);

            var _loadedManufact = RepoManufact.GetAllEntitiesAsync().Result.Where(i => i.Name == carManufacturerId.Text).FirstOrDefault();
            if (_loadedManufact != null)
                car.ManufacturerId = _loadedManufact.Id;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(car);
                serviceClient.UpdateCar(serialized);
                scope.Complete();
            }

            Response.Redirect("carPage");
        }
    }
}