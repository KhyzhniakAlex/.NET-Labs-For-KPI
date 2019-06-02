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
    public partial class OrderCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private readonly IRepository<Order> Repository = Singleton.UnitOfWork.OrderRepository;
        private readonly IRepository<Manager> RepoManager = Singleton.UnitOfWork.ManagerRepository;
        private readonly IRepository<Customer> RepoCustomer = Singleton.UnitOfWork.CustomerRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();
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
                    var _loadedOrder = Repository.GetAllEntitiesAsync().Result.Where(i => i.Id == Guid.Parse(id)).FirstOrDefault();
                    var managerID = _loadedOrder.ManagerId;
                    var _loadedManager = RepoManager.GetAllEntitiesAsync().Result.Where(i => i.Id == managerID).FirstOrDefault();
                    var customerID = _loadedOrder.CustomerId;
                    var _loadedCustomer = RepoCustomer.GetAllEntitiesAsync().Result.Where(i => i.Id == customerID).FirstOrDefault();

                    orderStartDate.Text = _loadedOrder.StartDate.ToString();
                    orderEndDate.Text = _loadedOrder.EndDate.ToString();
                    orderSum.Text = _loadedOrder.Sum.ToString();
                    orderManagerId.Text = _loadedManager != null ? _loadedManager.LastName : "";
                    orderCustomerId.Text = _loadedCustomer != null? _loadedCustomer.AccoutId : "";
                    
                    btnCreate.Visible = false;
                    Label.Text = "Update order";
                }
                else
                {
                    btnUpdate.Visible = false;
                    Label.Text = "Create new order";
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Order subject = new Order();
            subject.Id = Guid.NewGuid();
            subject.StartDate = DateTime.Parse(orderStartDate.Text);
            subject.EndDate = DateTime.Parse(orderEndDate.Text);
            subject.Sum = int.Parse(orderSum.Text);

            var _loadedManager = RepoManager.GetAllEntitiesAsync().Result.Where(i => i.LastName == orderManagerId.Text).FirstOrDefault();
            subject.ManagerId = _loadedManager != null ? _loadedManager.Id : Guid.Empty;

            var _loadedCustomer = RepoCustomer.GetAllEntitiesAsync().Result.Where(i => i.AccoutId == orderCustomerId.Text).FirstOrDefault();
            subject.CustomerId = _loadedCustomer != null ? _loadedCustomer.Id : Guid.Empty;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(subject);
                serviceClient.CreateOrder(serialized);
                scope.Complete();
            }
            Thread.Sleep(3000);

            Response.Redirect("orderPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var order = Repository.GetAllEntitiesAsync().Result.Where(sub => sub.Id == _id).FirstOrDefault();

            order.StartDate = DateTime.Parse(orderStartDate.Text);
            order.EndDate = DateTime.Parse(orderEndDate.Text);
            order.Sum = int.Parse(orderSum.Text);

            var _loadedManager = RepoManager.GetAllEntitiesAsync().Result.Where(i => i.LastName == orderManagerId.Text).FirstOrDefault();
            if (_loadedManager != null)
                order.ManagerId = _loadedManager.Id;

            var _loadedCustomer = RepoCustomer.GetAllEntitiesAsync().Result.Where(i => i.AccoutId == orderCustomerId.Text).FirstOrDefault();
            if (_loadedCustomer != null)
                order.CustomerId = _loadedCustomer.Id;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(order);

                serviceClient.UpdateOrder(serialized);
                scope.Complete();
            }

            Response.Redirect("orderPage");
        }
    }
}