using System;
using System.Threading;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class CarInOrdersPage : System.Web.UI.Page
    {
        private WebClientCrudService<CarInOrderDto> webClient = new WebClientCrudService<CarInOrderDto>("CarInOrderService.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater.DataSource = webClient.GetEntities();
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
                        webClient.DeleteEntity(e.CommandArgument.ToString());

                        scope.Complete();
                    }

                    Thread.Sleep(3000);
                    Response.Redirect("carinorderspage");
                    break;
                case "Update":
                    Response.Redirect("carinorderCreatePage?ID=" + e.CommandArgument);
                    break;
            }
        }
        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("carinorderCreatePage");
        }
    }
}