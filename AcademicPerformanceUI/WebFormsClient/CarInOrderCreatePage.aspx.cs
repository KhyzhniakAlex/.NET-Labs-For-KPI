using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class CarInOrderCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<CarInOrderDto> webClientCarInOrder = new WebClientCrudService<CarInOrderDto>("CarInOrderService.svc");
        private WebClientCrudService<CarDto> webClientCar = new WebClientCrudService<CarDto>("CarService.svc");
        private WebClientCrudService<OrderDto> webClientOrder = new WebClientCrudService<OrderDto>("OrderService.svc");
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
                    var _loadedRoute = webClientCarInOrder.GetEntities().Where(x => x.Id == _id).FirstOrDefault();
                    dropdownOrder.SelectedValue = _loadedRoute.OrderId.ToString();
                    dropdownCar.SelectedValue = _loadedRoute.CarId.ToString();

                    btnCreate.Visible = false;
                    Label.Text = "Update car in order";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new car in order";
                }

                dropdownOrder.DataSource = webClientOrder.GetEntities().Select(item => item.Id);
                dropdownCar.DataSource = webClientCar.GetEntities().Select(item => item.Id);
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
                webClientCarInOrder.CreateEntity(route);
                scope.Complete();
            }

            Thread.Sleep(3000);
            Response.Redirect("CarInOrdersPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var route = webClientCarInOrder.GetEntities().Where(x => x.Id == _id).FirstOrDefault();

            route.OrderId = new Guid(dropdownOrder.SelectedValue);
            route.CarId = new Guid(dropdownCar.SelectedValue);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClientCarInOrder.UpdateEntity(route);
                scope.Complete();
            }

            Response.Redirect("CarInOrdersPage");
        }
    }
}