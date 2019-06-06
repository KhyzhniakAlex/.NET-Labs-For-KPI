using System;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Threading;
using DataAccess.Models;
using DataAccess.Interfaces;
using WebFormsMsMqClient.AcademicService;

namespace WebFormsMsMqClient
{
    public partial class CarPage : System.Web.UI.Page
    {
        private readonly IRepository<Car> Repository = Singleton.UnitOfWork.CarRepository;
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
                        serviceClient.RemoveCar(e.CommandArgument.ToString());
                        scope.Complete();
                    }
                    Thread.Sleep(3000);
                    Response.Redirect("carpage");
                    break;

                case "Update":
                    Response.Redirect("carCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("carCreatePage");
        }
    }
}