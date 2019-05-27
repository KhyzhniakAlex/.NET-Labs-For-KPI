using System;
using System.Linq;
using System.Transactions;
using System.Web.UI.WebControls;
using WcfRestService.DTOModels;

namespace WebFormsClient
{
    public partial class OrderCreatePage : System.Web.UI.Page
    {
        private Guid _id;
        private WebClientCrudService<OrderDto> webClient = new WebClientCrudService<OrderDto>("OrderService.svc");
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

                    orderStartDate.Text = _loadedSubject.StartDate.ToString();
                    orderEndDate.Text = _loadedSubject.EndDate.ToString();
                    orderSum.Text = _loadedSubject.Sum.ToString();
                    //customer
                    //manager

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
            OrderDto order = new OrderDto();
            order.StartDate = DateTime.Parse(orderStartDate.Text);
            order.EndDate = DateTime.Parse(orderEndDate.Text);
            order.Sum = int.Parse(orderSum.Text);
            //customer
            //manager

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.CreateEntity(order);
                scope.Complete();
            }

            Response.Redirect("ordersPage");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var order = webClient.GetEntities().Where(sub => sub.Id == _id).FirstOrDefault();
            order.StartDate = DateTime.Parse(orderStartDate.Text);
            order.EndDate = DateTime.Parse(orderEndDate.Text);
            order.Sum = int.Parse(orderSum.Text);
            //customer
            //manager

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                webClient.UpdateEntity(order);
                scope.Complete();
            }

            Response.Redirect("ordersPage");
        }
    }
}