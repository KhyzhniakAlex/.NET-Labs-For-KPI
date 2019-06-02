using DataAccess.Interfaces;
using DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class CarInOrderCreatePage : System.Web.UI.Page
    {
        private readonly IRepository<Car> CarRepository = Singleton.UnitOfWork.CarRepository;
        private readonly IRepository<Order> OrderRepository = Singleton.UnitOfWork.OrderRepository;
        private readonly IRepository<CarInOrder> CarInOrderRepository = Singleton.UnitOfWork.CarInOrderRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
        private Guid _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["ID"];

            if (id != null)
            {
                _id = Guid.Parse(id);
            }

            if (!IsPostBack)
            {
                if (id != null)
                {
                    var _loadedRoute = CarInOrderRepository.GetAllEntitiesAsync().Result.Where(x => x.Id == _id).FirstOrDefault();
                    dropdownCar.SelectedValue = _loadedRoute.CarId.ToString();
                    dropdownOrder.SelectedValue = _loadedRoute.OrderId.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update car in order";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new car in order";
                }

                dropdownOrder.DataSource = OrderRepository.GetAllEntitiesAsync().Result.Select(item => item.Id);
                dropdownCar.DataSource = CarRepository.GetAllEntitiesAsync().Result.Select(item => item.Id);
                DataBind();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var route = new CarInOrderDto();
            route.Id = Guid.NewGuid();
            route.OrderId = new Guid(dropdownOrder.SelectedValue);
            route.CarId = new Guid(dropdownCar.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(route);
                serviceClient.CreateCiO(serialized);
                scope.Complete();
            }

            Thread.Sleep(3000);
            Response.Redirect("CarInOrdersPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var route = CarInOrderRepository.GetAllEntitiesAsync().Result.Where(x => x.Id == _id).FirstOrDefault();

            route.OrderId = new Guid(dropdownOrder.SelectedValue);
            route.CarId = new Guid(dropdownCar.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(route);
                serviceClient.UpdateCiO(serialized);
                scope.Complete();
            }

            Response.Redirect("CarInOrdersPage");
        }
    }
}