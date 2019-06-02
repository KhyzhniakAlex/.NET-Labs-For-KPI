using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Transactions;
using System.Web.UI.WebControls;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class OrdersPage : System.Web.UI.Page
    {
        private readonly IRepository<Order> Repository = Singleton.UnitOfWork.OrderRepository;
        private readonly AcademicServiceClient serviceClient = new AcademicServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = Repository.GetAllEntitiesAsync().Result;
                Repeater.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        serviceClient.RemoveGroup(e.CommandArgument.ToString());

                        scope.Complete();
                    }

                    Response.Redirect("orderspage");
                    break;
                case "Update":
                    Response.Redirect("orderCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("orderCreatePage");
        }
}
}