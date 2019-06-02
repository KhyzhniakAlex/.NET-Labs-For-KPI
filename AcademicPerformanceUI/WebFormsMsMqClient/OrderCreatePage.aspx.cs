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

                    orderStartDate.Text = _loadedOrder.StartDate.ToString();
                    orderEndDate.Text = _loadedOrder.EndDate.ToString();
                    orderSum.Text = _loadedOrder.Sum.ToString();

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

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(subject);
                serviceClient.CreateGroup(serialized);
                scope.Complete();
            }
            Thread.Sleep(3000);

            Response.Redirect("ordersPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var group = Repository.GetAllEntitiesAsync().Result.Where(sub => sub.Id == _id).FirstOrDefault();
            group.GroupName = groupName.Text;
            group.MaxStudents = int.Parse(groupMaxStudents.Text);
            group.StudyYear = int.Parse(groupStudyYear.Text);

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var serialized = JsonConvert.SerializeObject(group);

                serviceClient.UpdateGroup(serialized);
                scope.Complete();
            }

            Response.Redirect("groupsPage");
        }
    }
}